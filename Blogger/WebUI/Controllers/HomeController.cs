using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DataTransferObjects;
using WebUI.Models.Blog;
using RequestObjects;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        #region Fields

        private readonly IBlogService _blogService;

        #endregion

        #region Constructors

        public HomeController(IBlogService blogService)
        {
            _blogService = blogService;
        }


        #endregion

        #region Public Methods

        public async Task<ActionResult> Index()
        {
            var blogs = await _blogService.GetBlogList();
            var viewModel = new BlogListViewModel(blogs);
            return View(viewModel);
        }

        public async Task<ActionResult> Read(int id)
        {
            var blog = await _blogService.FindBlog(id, Guid.NewGuid());
            var viewModel = new BlogViewModel(blog);
            return View(viewModel);
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddComment(AddCommentViewModel vm)
        {
            if (!ModelState.IsValid)
                throw new Exception("Don't be daft, fill in the comment");

            var user = User?.Identity?.Name;
            var request = new AddCommentRequest(vm.Id, user, vm.Comment);

            await _blogService.AddComment(request);

            var model = new CommentViewModel(user, DateTime.Now, vm.Comment);
            return PartialView(model);
        }

        #endregion
    }
}