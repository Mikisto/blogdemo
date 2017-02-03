using NUnit.Framework;
using System;

namespace Domains.Tests
{
    [TestFixture]
    public class BlogTests
    {
        private Blog _blog;

        [SetUp]
        public void Setup()
        {
            _blog = new Blog("Me", "Test Blog", "Nothing to see here.");
        }

        [Test]
        public void AddsComment()
        {
            var comment = new Comment("Me", "You suck");

            _blog.AddComment(comment);

            Assert.AreEqual(1, _blog.Comments.Count);
        }

        [Test]
        public void AddsLike()
        {
            var like = new Like(Guid.NewGuid());

            _blog.AddLike(like);

            Assert.AreEqual(1, _blog.Likes.Count);
        }

        [Test]
        public void DoesntReAddLike()
        {
            var like = new Like(Guid.NewGuid());

            _blog.AddLike(like);

            Assert.Throws<NotSupportedException>(delegate { _blog.AddLike(like); });
        }

        [Test]
        public void RemovesLike()
        {
            var like = new Like(Guid.NewGuid());
            _blog.AddLike(like);

            _blog.RemoveLike(like);

            Assert.AreEqual(0, _blog.Likes.Count);
        }

        [Test]
        public void DoesntRemoveLikeThatIsNotThere()
        {
            var like = new Like(Guid.NewGuid());
            _blog.AddLike(like);

            _blog.RemoveLike(like);

            Assert.Throws<ArgumentNullException>(delegate { _blog.RemoveLike(like); });
        }
    }
}