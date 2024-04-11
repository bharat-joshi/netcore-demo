using BlogApp.Entity;
using BlogApp.IService;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

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
            try
            {
                _blogDbContext.Users.Add(user);
                await _blogDbContext.SaveChangesAsync();
                return user;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
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

        public async Task<string> Login(string username, string password)
        {
            var user = await _blogDbContext.Users.FirstOrDefaultAsync(x => x.UserName == username && x.Password == password);
            if (user != null)
            {

                string token = GenerateAccessToken(user, "your_strong_secret_key_here_with_at_least_16_characters");
                return token;
            }
            return null;
        }

        public async Task<User> UpdateUser(User user)
        {
             _blogDbContext.Users.Update(user);
            await _blogDbContext.SaveChangesAsync();
            return user;
        }

        public static string GenerateAccessToken(User user, string secret)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddMinutes(15), // Token expiration time
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
