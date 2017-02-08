using System;
using System.Collections.Generic;
using System.Linq;

namespace Domains
{
    public class Blog
    {
        public int Id { get; private set; }
        public string Author { get; private set; }
        public DateTime Date { get; private set; }
        public string Topic { get; private set; }
        public string Body { get; private set; }
        public virtual IList<Comment> Comments { get; private set; }
        public virtual IList<Like> Likes { get; private set; }

        public Blog()
        {
            Comments = new List<Comment>();
            Likes = new List<Like>();
        }

        public Blog(string author, string topic, string body) : this()
        {
            Author = author;
            Date = DateTime.Now;
            Topic = topic;
            Body = body;
        }

        public void AddComment(Comment comment)
        {
            Comments.Add(comment);
        }

        public void AddLike(Like like)
        {
            if (Likes.Any(p => p.UserId == like.UserId))
                throw new NotSupportedException("Cannot re-add like");

            Likes.Add(like);
        }

        public void RemoveLike(Like like)
        {
            if (Likes.All(p => p.UserId != like.UserId))
                throw new ArgumentNullException("Like", "There's no like from that user");

            var removeMe = Likes.First(p => p.UserId == like.UserId);
            Likes.Remove(removeMe);
        }
    }
}