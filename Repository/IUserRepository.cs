using CRUDapplicationUsingLayers2.Model.Entities;

namespace CRUDapplicationUsingLayers2.Repository
{
    public interface IUserRepository
    {
        public Task<User> AddUser(User user);
        public Task<IEnumerable<User>> GetAllUsers(); 
       
    }
}
