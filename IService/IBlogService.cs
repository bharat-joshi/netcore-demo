using BlogApp.Entity;

namespace BlogApp.IService
{
    public interface IBlogService
    {
        Task<List<Blog>> getBlogs();
        Task<Blog> getBlogById(int id);
        Task<Blog> AddBlog(Blog blog);
        Task<Blog> UpdateBlog(Blog blog);
        Task<bool> DeleteBlog(int id);
        Task<Blog> getBlogByUserId(int id);
    }
}
