using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models.Blog
{
    public class CommentViewModel
    {
        #region Properties

        public string Author { get; set; }
        public DateTime Date { get; set; }
        public string Body { get; set; }

        #endregion

        #region Constructors

        public CommentViewModel(CommentDto dto)
        {
            Author = dto.Author;
            Date = dto.Date;
            Body = dto.Body;
        }

        #endregion

    }
}