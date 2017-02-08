namespace RequestObjects
{
    public class AddCommentRequest
    {
        public int BlogId { get; private set; }
        public string Author { get; private set; }
        public string Comment { get; private set; }

        public AddCommentRequest(int blogId, string author, string comment)
        {
            BlogId = blogId;
            Author = author;
            Comment = comment;
        }
    }
}