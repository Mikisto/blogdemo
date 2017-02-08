namespace RequestObjects
{
    public class AddBlogRequest
    {
        public string Author { get; private set; }
        public string Topic { get; private set; }
        public string Body { get; set; }

        public AddBlogRequest(string author, string topic, string body)
        {
            Author = author;
            Topic = topic;
            Body = body;
        }
    }
}