using CRUDapplicationUsingLayers2.Model.Entities;

namespace CRUDapplicationUsingLayers2.Service
{
    public interface IAuthService
    {
       
        public Task<string> Login(Login login);
    }
}
