using System;

namespace Domains
{
    public class Like
    {
        public int Id { get; private set; }
        public Guid UserId { get; private set; }

        public Like()
        {

        }

        public Like(Guid userId)
        {
            UserId = userId;
        }
    }
}