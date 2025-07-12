using BloodBankAPI.InterfaceRepository;
using BloodBankAPI.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//using moq

namespace BloodBankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class UserDetailsController : ControllerBase
    {
        private readonly IUserDetails _userDetails;
        public UserDetailsController(IUserDetails userDetails)
        {
            _userDetails = userDetails;
        }
        [HttpGet("getBloodBankDetails")]
        public async Task<ActionResult<IEnumerable<BloodBank>>> getBloodBankDetails()
        {
            return await Task.FromResult(_userDetails.getBloodBankDetails());
        }
        //[HttpGet("GetBloodBankDetailsByDistrict")]
        //public async Task<ActionResult<IEnumerable<User>>> GetBloodBankDetailsByDistrict(string? DistrictName)
        //{
        //    var stateDetails = await Task.FromResult(_userDetails.GetBloodBankDetailsByDistrict(DistrictName));
        //    return stateDetails;
        //}
    }
}
