using FernoChatAPI.Models;
using FernoChatAPI.Repository;

namespace FernoChatAPI.Service
{
    public class UserService
    {
        private readonly UserRepository userRepository;

        public UserService(UserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public List<User> GetAllUsers()
        {
            return userRepository.GetAllUsers();
        }

        public User GetUserById(int userId)
        {
            return userRepository.GetUserById(userId);
        }

        public void CreateUser(User user)
        {
            userRepository.CreateUser(user);
        }

        public void UpdateUser(User user)
        {
            userRepository.UpdateUser(user);
        }

        public void DeleteUser(int userId)
        {
            userRepository.DeleteUser(userId);
        }
    }
}
