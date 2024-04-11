using BlogApp.Entity;

namespace BlogApp.IService
{
    public interface IUserService
    {
        Task<List<User>> GetUsers();
        Task<User> getUserById(int id);
        Task<User> AddUser(User user);
        Task<User> UpdateUser(User user);
        Task<bool> DeleteUser(int id);
        Task<string> Login(string username,string password);
    }
}
