namespace RequestObjects
{
    public class AddBlogRequest
    {
        public string Author { get; private set; }
        public string Topic { get; private set; }
        public string Body { get; set; }
    }
}