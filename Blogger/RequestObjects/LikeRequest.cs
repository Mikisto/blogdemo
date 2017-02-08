using System;

namespace RequestObjects
{
    public class LikeRequest
    {
        public int BlogId { get; private set; }
        public Guid UserId { get; private set; }

        public LikeRequest(int blogId, Guid userId)
        {
            BlogId = blogId;
            UserId = UserId;
        }
    }
}