using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    public class BlogDto
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public DateTime Date { get; set; }
        public string Topic { get; set; }
        public string Body { get; set; }
        public virtual IList<CommentDto> Comments { get; set; }
        public int Likes { get; set; }

        public BlogDto(int id, string author, DateTime date, string topic, string body, IList<CommentDto> comments, int likes)
        {
            Id = id;
            Author = author;
            Date = date;
            Topic = topic;
            Body = body;
            Comments = comments;
            Likes = likes;
        }

        public BlogDto()
        {

        }
    }
}
