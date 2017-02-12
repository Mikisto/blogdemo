using DataTransferObjects;
using Moq;
using NUnit.Framework;
using RequestObjects;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebUI.Controllers;
using WebUI.Models.Blog;

namespace WebUI.Tests
{
    [TestFixture]
    public class HomeControllerTests
    {
        private Mock<IBlogService> _serviceMock;
        private HomeController _controller;

        [SetUp]
        public void Setup()
        {
            _serviceMock = new Mock<IBlogService>();
            _serviceMock.Setup(p => p.GetBlogList()).ReturnsAsync(new List<BlogDetailsDto>());
            _serviceMock.Setup(p => p.FindBlog(It.IsAny<int>(), It.IsAny<Guid>())).ReturnsAsync(new BlogDto() { Comments = new List<CommentDto>() });
            _serviceMock.Setup(p => p.AddComment(It.IsAny<AddCommentRequest>())).Returns(Task.CompletedTask);

            var userIdentity = new Mock<IIdentity>();
            userIdentity.Setup(p => p.Name).Returns("Torso");

            var userMock = new Mock<IPrincipal>();
            userMock.Setup(p => p.Identity).Returns(userIdentity.Object);

            var contextMock = new Mock<HttpContextBase>();
            contextMock.Setup(p => p.User).Returns(userMock.Object);            

            var controllerContextMock = new Mock<ControllerContext>();
            controllerContextMock.Setup(p => p.HttpContext).Returns(contextMock.Object);

            _controller = new HomeController(_serviceMock.Object);
            _controller.ControllerContext = controllerContextMock.Object;
        }

        [Test]
        public async Task GetsIndexPage()
        {
            var page = await _controller.Index();
            var result = page as ViewResult;

            Assert.IsInstanceOf<BlogListViewModel>(result.Model);
            _serviceMock.Verify(p => p.GetBlogList(), Times.Once);
        }

        [Test]
        public async Task GetsReadPage()
        {
            var page = await _controller.Read(1);
            var result = page as ViewResult;

            Assert.IsInstanceOf<BlogViewModel>(result.Model);
            _serviceMock.Verify(p => p.FindBlog(It.IsAny<int>(), It.IsAny<Guid>()), Times.Once);
        }

        // the tests below won't work due to User being empty. :P

        [Test]
        public async Task AddCommentSuccess()
        {
            var vm = new AddCommentViewModel
            {
                Id = 1,
                Comment = "StupidComment"
            };

            var page = await _controller.AddComment(vm);
            var result = page as PartialViewResult;

            Assert.IsInstanceOf<CommentViewModel>(result.Model);
            _serviceMock.Verify(p => p.AddComment(It.IsAny<AddCommentRequest>()), Times.Once);
        }

        [TestCase("", TestName="Adding too short comment fails")]
        [TestCase("123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901", TestName = "Adding too long comment fails")]
        public async Task AddCommentException(string comment)
        {
            var vm = new AddCommentViewModel
            {
                Id = 1,
                Comment = comment
            };
            
            Assert.ThrowsAsync<Exception>(async delegate { await _controller.AddComment(vm); });            
            _serviceMock.Verify(p => p.AddComment(It.IsAny<AddCommentRequest>()), Times.Never);
        }
    }
}
