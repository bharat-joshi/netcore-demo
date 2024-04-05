using BlogApp.Entity;
using BlogApp.IService;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Service
{
    public class UserService : IUserService
    {
        private readonly BlogDbContext _blogDbContext;
        public UserService(BlogDbContext blogDbContext) {
            _blogDbContext = blogDbContext;
        }
        public async Task<User> AddUser(User user)
        {
            _blogDbContext.Users.Add(user);
           await  _blogDbContext.SaveChangesAsync();
            return user;
        }

        public async Task<bool> DeleteUser(int id)
        {
            var user = await _blogDbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user != null)
            {
                _blogDbContext.Users.Remove(user);
                await _blogDbContext.SaveChangesAsync();
                return true;
            }
            return false;
          
        }

        public async Task<User> getUserById(int id)
        {
            return await _blogDbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<User>> GetUsers()
        {
            return await _blogDbContext.Users.ToListAsync();
        }

        public async Task<User> Login(string username, string password)
        {
            var user = await _blogDbContext.Users.FirstOrDefaultAsync(x => x.UserName == username && x.Password == password);
            if (user != null)
            {
                return user;
            }
            return null;
        }

        public async Task<User> UpdateUser(User user)
        {
             _blogDbContext.Users.Update(user);
            await _blogDbContext.SaveChangesAsync();
            return user;
        }
    }
}
