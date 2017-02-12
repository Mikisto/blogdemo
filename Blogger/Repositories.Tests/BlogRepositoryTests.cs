using DataAccessLayer;
using Domains;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Repositories.Tests
{
    [TestFixture]
    public class BlogRepositoryTests
    {
        private Mock<BlogContext> _mockContext;
        private Mock<DbSet<Blog>> _mockDbSet;

        private IBlogRepository _repository;

        [SetUp]
        public void Setup()
        {
            var blogs = new List<Blog>().AsQueryable();

            _mockDbSet = new Mock<DbSet<Blog>>();
            _mockDbSet.As<IQueryable<Blog>>().Setup(m => m.Provider).Returns(blogs.Provider);
            _mockDbSet.As<IQueryable<Blog>>().Setup(m => m.Expression).Returns(blogs.Expression);
            _mockDbSet.As<IQueryable<Blog>>().Setup(m => m.ElementType).Returns(blogs.ElementType);
            _mockDbSet.As<IQueryable<Blog>>().Setup(m => m.GetEnumerator()).Returns(blogs.GetEnumerator());

            _mockContext = new Mock<BlogContext>();            
            _mockContext.Setup(p => p.Blogs).Returns(_mockDbSet.Object);            

            _repository = new BlogRepository(_mockContext.Object);
        }

        [Test]
        public async Task GetBlogsTest()
        {
            var blogs = await _repository.GetBlogs();
                        
            _mockContext.Verify(p => p.SaveChangesAsync(), Times.Never);
        }

        [Test]
        public async Task FindTest()
        {
            var blog = await _repository.Find(0);

            _mockDbSet.Verify(p => p.FindAsync(It.IsAny<int>()), Times.Once);
            _mockContext.Verify(p => p.SaveChangesAsync(), Times.Never);
        }

        [Test]
        public async Task AddTest()
        {
            var blog = new Blog("meh", "blah", "hem");

            await _repository.Add(blog);

            _mockDbSet.Verify(p => p.Add(blog), Times.Once);
            _mockContext.Verify(p => p.SaveChangesAsync(), Times.Once);
        }

        [Test]
        public async Task UpdateTest()
        {
            var blog = new Blog("meh", "blah", "hem");

            await _repository.Update(blog);
            _mockContext.Verify(p => p.SaveChangesAsync(), Times.Once);
        }
    }
}