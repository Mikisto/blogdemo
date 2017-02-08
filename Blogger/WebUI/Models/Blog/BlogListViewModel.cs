using DataTransferObjects;
using System.Collections.Generic;
using System.Linq;

namespace WebUI.Models.Blog
{
    public class BlogListViewModel
    {
        #region Properties

        public IEnumerable<BlogListItemViewModel> Blogs { get; set; }

        #endregion

        #region Constructors

        public BlogListViewModel(IEnumerable<BlogDetailsDto> blogDetails)
        {
            Blogs = blogDetails.Select(p => new BlogListItemViewModel(p));
        }

        #endregion
    }
}