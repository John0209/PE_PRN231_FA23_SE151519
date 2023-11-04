using BusinessLogic.IService;
using BusinessLogic.Token;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Net;

namespace ControllerAPI.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserRoleControllers : ControllerBase
    {
        IUserRoleService _user;
        IConfiguration _config;

        public UserRoleControllers(IUserRoleService user, IConfiguration config)
        {
            _user = user;
            _config = config ?? throw new ArgumentNullException(nameof(config));
            ProvideToken.Initialize(_config);
        }

        [HttpPost("login")]
        public IActionResult Login(string username, string password)
        {
            var checkLogin= _user.Login(username, password);
            if (checkLogin != null)
            {
                var token= ProvideToken.Instance.GenerateToken(checkLogin);
                return Ok(token);
            }
            return Unauthorized("Username or password wrong, please try login!");
        }
    }
}
