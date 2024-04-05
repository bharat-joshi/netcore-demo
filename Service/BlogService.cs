using BlogApp.Entity;
using BlogApp.IService;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Service
{
    public class BlogService : IBlogService
    {
        private readonly BlogDbContext _dbContext;
        public BlogService(BlogDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<Blog> AddBlog(Blog blog)
        {
            _dbContext.Add(blog);
            await _dbContext.SaveChangesAsync();
            return blog;
        }

        public async Task<bool> DeleteBlog(int id)
        {
            var blog = await _dbContext.Blogs.FirstOrDefaultAsync(x => x.Id == id);
            if (blog != null)
            {
                _dbContext.Remove(blog);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Blog> getBlogById(int id)
        {
            return await _dbContext.Blogs.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Blog> getBlogByUserId(int id)
        {
            return await _dbContext.Blogs.FirstOrDefaultAsync(x => x.UserId == id);
        }

        public async Task<List<Blog>> getBlogs()
        {
            return await _dbContext.Blogs.ToListAsync();
        }

        public async Task<Blog> UpdateBlog(Blog blog)
        {
            _dbContext.Update(blog);
            await _dbContext.SaveChangesAsync();
            return blog;
        }
    }
}
