using CRUDapplicationUsingLayers2.Model.Entities;
using CRUDapplicationUsingLayers2.Repository;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace CRUDapplicationUsingLayers2.Service
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository userRepository;
        private readonly IConfiguration configuration;

        public AuthService(IUserRepository userRepository, IConfiguration configuration)
        {
            this.userRepository = userRepository;
            this.configuration = configuration;
        }
        

        public async Task<string> Login(Login login)
        {
            if (login.Username != null && login.Password != null)
            {
                //getting all the list of users
                var users = await userRepository.GetAllUsers();
                //see if the logged in user exist and is a valid user
                var user = users.SingleOrDefault(x => x.Email == login.Username && x.Password == login.Password);
                if (user != null)
                {
                    // Define claims for JWT token
                    var claims = new[]
                    {
                     new Claim(JwtRegisteredClaimNames.Sub, configuration["Jwt:Subject"]),
                     new Claim("Id", user.Id.ToString()),
                     new Claim("UserName", user.Name),
                     new Claim("Email", user.Email)
                };

                    // Generate a symmetric security key using the secret key in appsettings.json
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    // Create the token
                    var token = new JwtSecurityToken(
                        issuer: configuration["Jwt:Issuer"],
                        audience: configuration["Jwt:Audience"],
                        claims: claims,
                        expires: DateTime.UtcNow.AddMinutes(100),  // Set token expiration time
                        signingCredentials: signIn
                    );

                    // Return the token as a string
                    var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
                    return jwtToken;

                }
                else
                {
                    throw new Exception("User is not valid");
                }
            }
            else
            {
                throw new Exception("Credentials are not valid");
            }

        }

    }
}


