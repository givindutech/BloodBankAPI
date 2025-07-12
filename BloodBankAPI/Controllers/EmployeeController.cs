using BloodBankAPI.PublicClasses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloodBankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [HttpPost]
        public IActionResult UploadFile(IFormFile file)
        {
            return Ok(new UploadHandler().Upload(file));
        }

    }
}
