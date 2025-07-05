using BloodBankAPI.Helper;
using BloodBankAPI.InterfaceRepository;
using BloodBankAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BloodBankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class LoginController : ControllerBase
    {
        public readonly IConfiguration _configuration;
        public readonly ILogin _login;
        public LoginController(ILogin login, IConfiguration configuration)
        {
            _login = login;
            _configuration = configuration;
            
        }
        [HttpPost("GetLogin")]
        public async Task<ActionResult<ResultResponse>> GetLogin(Login login)
        {
            try
            {
                var userDetails = await Task.FromResult(_login.GetUserDetailsTest(login));
                if (userDetails.name == login.name && userDetails.password == login.password && userDetails.name != null)
                {
                    //["JWT:Secret"]
                    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("JWT").GetSection("Key").Value));
                    var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                    var tokeOptions = new JwtSecurityToken(issuer: _configuration.GetSection("JWT").GetSection("Issuer").Value,
                        audience: _configuration.GetSection("JWT").GetSection("Audience").Value,
                        claims: new List<Claim>(), expires: DateTime.Now.AddMinutes(6), signingCredentials: signinCredentials);
                    var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                    return Ok(new JWTTokenResponse
                    {
                        Token = tokenString,
                        Status = true,
                        Message = "User Login Successfuly",
                        UserDetails = userDetails
                    });
                    // return ResultResponse.Success(UserDetails, "", "User Login Successfuly");
                }
                else
                {
                    return ResultResponse.Failed("User not existed Please Register");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        internal class JWTTokenResponse
        {
            public string Token { get; set; }
            public bool Status { get; set; }
            public string Message { get; set; }
            public Login UserDetails { get; set; }
        }
    }
}
