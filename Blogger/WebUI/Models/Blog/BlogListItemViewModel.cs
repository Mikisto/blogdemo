
using DataTransferObjects;
using System;

namespace WebUI.Models.Blog
{
    public class BlogListItemViewModel
    {
        #region Properties

        public int Id { get; set; }
        public string Author { get; set; }
        public DateTime Date { get; set; }
        public string Topic { get; set; }
        public int Likes { get; set; }

        #endregion

        #region Constructors

        public BlogListItemViewModel(BlogDetailsDto blogDetails)
        {
            Id = blogDetails.Id;
            Author = blogDetails.Author;
            Date = blogDetails.Date;
            Topic = blogDetails.Topic;
            Likes = blogDetails.Likes;
        }

        #endregion
    }
}