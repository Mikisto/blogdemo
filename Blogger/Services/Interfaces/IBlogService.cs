using DataTransferObjects;
using RequestObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IBlogService
    {
        Task<IEnumerable<BlogDetailsDto>> GetBlogList();

        Task<BlogDto> FindBlog(int id, Guid userId);

        Task AddLike(LikeRequest request);

        Task RemoveLike(LikeRequest request);

        Task AddComment(AddCommentRequest request);

        Task AddBlog(AddBlogRequest request);
    }
}