using DataAccessLayer;
using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repositories
{
    public class BlogRepository : IBlogRepository, IDisposable
    {
        private bool _disposed = false;
        private BlogContext _context;

        public BlogRepository(BlogContext context)
        {
            _context = context;
        }

        public async Task Add(Blog blog)
        {            
            await Task.Run(() => _context.Blogs.Add(blog));
            await Save();
        }

        public async Task<Blog> Find(int id)
        {
            return await _context.Blogs.FindAsync(id);
        }

        public async Task<IEnumerable<Blog>> GetBlogs()
        {            
            return await Task.Run(() => _context.Blogs.ToList());
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Update(Blog blog)
        {
            _context.Entry(blog).State = System.Data.Entity.EntityState.Modified;
            await Save();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed && disposing)
            {
                _context.Dispose();
            }
            this._disposed = true;
        }
    }
}