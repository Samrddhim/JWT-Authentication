using CRUDapplicationUsingLayers2.Model.Entities;

namespace CRUDapplicationUsingLayers2.Service
{
    public interface IUserService
    {
        public Task<User> AddUser(User user);
        public Task<IEnumerable<User>> GetAllUsers();
    }
}
