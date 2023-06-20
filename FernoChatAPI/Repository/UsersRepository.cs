using FernoChatAPI.Models;

namespace FernoChatAPI.Repository
{
    public class UserRepository
    {
        private readonly DatabaseContext _dbContext;

        public UserRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Users> GetAllUsers()
        {
            return _dbContext.Users.ToList();
        }

        public Users GetUserById(int userId)
        {
            return _dbContext.Users.FirstOrDefault(u => u.UserId == userId);
        }

        public void CreateUser(Users user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }

        public void UpdateUser(Users user)
        {
            _dbContext.Users.Update(user);
            _dbContext.SaveChanges();
        }

        public void DeleteUser(int userId)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.UserId == userId);
            if (user != null)
            {
                _dbContext.Users.Remove(user);
                _dbContext.SaveChanges();
            }
        }
    }
}
