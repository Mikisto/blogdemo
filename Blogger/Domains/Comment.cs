using System;

namespace Domains
{
    public class Comment
    {
        public int Id { get; private set; }
        public string Author { get; private set; } // needs to be changed to the user that actually put in the comment.
        public DateTime Date { get; private set; }
        public string Body { get; private set; }

        public Comment()
        {
        }

        public Comment(string author, string body)
        {
            Author = author;
            Date = DateTime.Now;
            Body = body;
        }
    }
}