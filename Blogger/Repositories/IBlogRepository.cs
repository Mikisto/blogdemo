using Domains;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IBlogRepository : IDisposable
    {
        Task<IEnumerable<Blog>> GetBlogs();

        Task<Blog> Find(int id);

        Task Add(Blog blog);

        Task Update(Blog blog);

        Task Save();
    }
}