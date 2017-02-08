using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models.Blog
{
    public class BlogViewModel
    {
        #region Properties

        public int Id { get; set; }
        public string Author { get; set; }
        public DateTime Date { get; set; }
        public string Topic { get; set; }
        public string Body { get; set; }
        public virtual IEnumerable<CommentViewModel> Comments { get; set; }
        public int Likes { get; set; }

        #endregion

        #region Constructors

        public BlogViewModel(BlogDto dto)
        {
            Id = dto.Id;
            Author = dto.Author;
            Date = dto.Date;
            Topic = dto.Topic;
            Body = dto.Body;
            Comments = dto.Comments.Select(p => new CommentViewModel(p));
            Likes = dto.Likes;
        }

        #endregion
    }
}