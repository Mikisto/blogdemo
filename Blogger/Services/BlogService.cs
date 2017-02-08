using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataTransferObjects;
using Repositories;
using RequestObjects;
using Services.Interfaces;
using Domains;
using System.Linq;

namespace Services
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _repository;

        public BlogService(IBlogRepository repository)
        {
            _repository = repository;
        }

        public async Task AddBlog(AddBlogRequest request)
        {
            var blog = new Blog(request.Author, request.Topic, request.Body);
            await _repository.Add(blog);
        }

        public async Task AddComment(AddCommentRequest request)
        {
            var blog = await _repository.Find(request.BlogId);

            var comment = new Comment(request.Author, request.Comment);

            blog.AddComment(comment);

            await _repository.Update(blog);
        }

        public async Task AddLike(LikeRequest request)
        {
            var blog = await _repository.Find(request.BlogId);

            var like = new Like(request.UserId);

            blog.AddLike(like);

            await _repository.Update(blog);
        }

        public async Task<BlogDto> FindBlog(int id, Guid userId)
        {
            var blog = await _repository.Find(id);

            var dto = new BlogDto(
                id,
                blog.Author,
                blog.Date,
                blog.Topic,
                blog.Body,
                blog.Comments.Select(p => new CommentDto(p.Author, p.Date, p.Body)).ToList(),
                blog.Likes.Count(p => p.UserId != userId));

            return dto;
        }

        public async Task<IEnumerable<BlogDetailsDto>> GetBlogList()
        {
            var blogs = await _repository.GetBlogs();

            var dtos = blogs.Select(p => new BlogDetailsDto(p.Id, p.Author, p.Date, p.Topic, p.Likes.Count));
            return dtos;
        }

        public async Task RemoveLike(LikeRequest request)
        {
            var blog = await _repository.Find(request.BlogId);

            var like = new Like(request.UserId);

            blog.RemoveLike(like);
        }
    }
}