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

        public List<Users> GetAllUsers()
        {
            return userRepository.GetAllUsers();
        }

        public Users GetUserById(int userId)
        {
            return userRepository.GetUserById(userId);
        }

        public void CreateUser(Users user)
        {
            userRepository.CreateUser(user);
        }

        public void UpdateUser(Users user)
        {
            userRepository.UpdateUser(user);
        }

        public void DeleteUser(int userId)
        {
            userRepository.DeleteUser(userId);
        }
    }
}
