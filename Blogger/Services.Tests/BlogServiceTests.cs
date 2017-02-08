using DataTransferObjects;
using Domains;
using Moq;
using NUnit.Framework;
using Repositories;
using RequestObjects;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Tests
{
    [TestFixture]
    public class BlogServiceTests
    {
        #region Fields

        private Mock<IBlogRepository> _repositoryMock;
        private IBlogService _service;

        private Blog _blog;
        private IList<Blog> _blogs;

        #endregion Fields

        #region Setup

        [SetUp]
        public void Setup()
        {
            _blog = new Blog("Janne", "Kuinka juoda olutta", "Siit vaan huitaset pullosta suoraan naamariin");
            _blogs = new List<Blog> { _blog };

            _repositoryMock = new Mock<IBlogRepository>();
            _repositoryMock.Setup(p => p.Add(It.IsAny<Blog>())).Callback<Blog>(blog => { _blogs.Add(blog); }).Returns(Task.CompletedTask);
            _repositoryMock.Setup(p => p.Find(It.IsAny<int>())).Returns(CreateBlog());
            _repositoryMock.Setup(p => p.Update(It.IsAny<Blog>())).Callback<Blog>(blog => { _blog = blog; }).Returns(Task.CompletedTask);
            _repositoryMock.Setup(p => p.GetBlogs()).Returns(CreateBlogs());

            _service = new BlogService(_repositoryMock.Object);
        }

        private async Task<Blog> CreateBlog()
        {
            return await Task.Run(() => _blog);
        }

        private async Task<IEnumerable<Blog>> CreateBlogs()
        {
            return await Task.Run(() => _blogs);
        }

        #endregion Setup

        #region Tests

        [Test]
        public async Task GetBlogListTest()
        {
            var blogList = await _service.GetBlogList();

            Assert.AreEqual(1, blogList.Count());
            Assert.IsInstanceOf<BlogDetailsDto>(blogList.First());

            _repositoryMock.Verify(p => p.GetBlogs(), Times.Once);
        }


        [Test]
        public async Task FindBlogTest()
        {
            var blog = await _service.FindBlog(0, Guid.NewGuid());

            Assert.IsNotNull(blog);

            _repositoryMock.Verify(p => p.Find(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public async Task AddLikeTest()
        {
            var like = new LikeRequest(0, Guid.NewGuid());

            await _service.AddLike(like);

            Assert.AreEqual(1, _blog.Likes.Count);
        }

        [Test]
        public async Task RemoveLikeTest()
        {
            var like = new LikeRequest(0, Guid.NewGuid());            
            await _service.AddLike(like);

            await _service.RemoveLike(like);

            Assert.AreEqual(0, _blog.Likes.Count);
        }

        [Test]
        public async Task AddCommentTest()
        {
            var comment = new AddCommentRequest(0, "mikke", "Ei vttu, et o tosissas?!");

            await _service.AddComment(comment);

            Assert.AreEqual(1, _blog.Comments.Count);
        }

        [Test]
        public async Task AddBlogTest()
        {
            var blog = new AddBlogRequest("W", "Varasto ja sen tyhjennys", "vie kamat vittuun sielt.");

            await _service.AddBlog(blog);

            Assert.AreEqual(2, _blogs.Count);
        }
        #endregion Tests
    }
}