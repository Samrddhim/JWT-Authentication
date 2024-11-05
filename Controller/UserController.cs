using CRUDapplicationUsingLayers2.Model.Entities;
using CRUDapplicationUsingLayers2.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDapplicationUsingLayers2.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost]
        public async Task<User> AddUser(User user)
        {
            return await userService.AddUser(user);
        }

        [HttpGet]
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await userService.GetAllUsers();
        }
    }
}
