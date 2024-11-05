using CRUDapplicationUsingLayers2.Model.Entities;
using CRUDapplicationUsingLayers2.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDapplicationUsingLayers2.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }

        [HttpPost]
        public async Task<string> Login(Login login)
        {
            var result = await authService.Login(login);
            return result;
        }
    }
}
