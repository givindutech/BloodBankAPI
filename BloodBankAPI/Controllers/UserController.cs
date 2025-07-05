using BloodBankAPI.Helper;
using BloodBankAPI.InterfaceRepository;
using BloodBankAPI.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloodBankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpPost("BloodBankUserRegistration")]
        public async  Task<ActionResult<ResultResponse>> BloodBankUserRegistration([FromBody]User user)
        {
            try
            {
                if (_userRepository.UserExists(user.UserId, user.Password))
                {
                    return ResultResponse.Success("","User Already Exists");
                }
                _userRepository.AddUseregistration(user);
                return ResultResponse.Success("", "Inserted Successfully");
            }catch(Exception ex)
            {
                return ResultResponse.Failed("", ex.Message);
            }
        }
    }
}
