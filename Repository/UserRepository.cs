using CRUDapplicationUsingLayers2.Data;
using CRUDapplicationUsingLayers2.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRUDapplicationUsingLayers2.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext applicationDbContext;

        public UserRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task<User> AddUser(User user)
        {
            var userentity = new User()
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Password = user.Password
            };
                
            applicationDbContext.Users.Add(userentity);
            await applicationDbContext.SaveChangesAsync();
            return userentity;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await applicationDbContext.Users.ToListAsync();
        }
    }
}
