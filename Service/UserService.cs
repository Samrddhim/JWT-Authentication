using CRUDapplicationUsingLayers2.Model.Entities;
using CRUDapplicationUsingLayers2.Repository;

namespace CRUDapplicationUsingLayers2.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public Task<User> AddUser(User user)
        {
            return userRepository.AddUser(user);
        }

        public Task<IEnumerable<User>> GetAllUsers()
        {
            return userRepository.GetAllUsers();
        }
    }
}
