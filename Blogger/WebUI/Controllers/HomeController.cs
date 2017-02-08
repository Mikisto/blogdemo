using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DataTransferObjects;
using WebUI.Models.Blog;

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

        #endregion
    }
}