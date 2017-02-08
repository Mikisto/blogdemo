using System;

namespace DataTransferObjects
{
    public class BlogDetailsDto
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public DateTime Date { get; set; }
        public string Topic { get; set; }
        public int Likes { get; set; }

        public BlogDetailsDto(int id, string author, DateTime date, string topic, int likes)
        {
            Id = id;            
            Author = author;
            Date = date;
            Topic = topic;
            Likes = likes;
        }
    }
}