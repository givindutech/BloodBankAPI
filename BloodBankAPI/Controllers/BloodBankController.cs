using BloodBankAPI.Helper;
using BloodBankAPI.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BloodBankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BloodBankController : ControllerBase
    {
        // Static list to simulate a database
        //private static List<BloodBank> _bloodBanks = new List<BloodBank>
        //{
        //    new BloodBank { BloodBankID = 1, BloodBankName = "City Blood Bank", Address = "123 Main St", City = "New York", ContactNumber = "123-456-7890", UserId = "admin", Password = "admin123" },
        //    new BloodBank { BloodBankID = 2, BloodBankName = "Green Valley Blood Bank", Address = "456 Oak Rd", City = "Los Angeles", ContactNumber = "987-654-3210", UserId = "user1", Password = "password1" }
        //};
        private readonly DataBaseContextcs _context;

        public BloodBankController(DataBaseContextcs context)
        {
            _context = context;
        }
        // GET: api/bloodbank
        [HttpGet("GetBloodBanks")]
        public async Task<ActionResult<IEnumerable<BloodBank>>> GetBloodBanks()
        {
            var ss= await _context.BloodBanks.ToListAsync();
            return ss;
        }
        // GET: api/bloodbank/{id}
        [HttpGet("GetBloodBankbyID/{id}")]
        public async Task<ActionResult<BloodBank>> GetBloodBank(int id)
        {
            var bloodBank = await _context.BloodBanks.FindAsync(id);

            if (bloodBank == null)
            {
                return NotFound();
            }

            return bloodBank;
        }
        // POST: api/bloodbank
        [HttpPost("CreateBloodBank")]
        public async Task<ActionResult<BloodBank>> CreateBloodBank(BloodBank bloodBank)
        {
            _context.BloodBanks.Add(bloodBank);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBloodBank), new { id = bloodBank.BloodBankID }, bloodBank);
        }
        // PUT: api/bloodbank/{id}
        [HttpPut("UpdateBloodBank/{id}")]
        public async Task<IActionResult> UpdateBloodBank(int id, BloodBank bloodBank)
        {
            if (id != bloodBank.BloodBankID)
            {
                return BadRequest();
            }

            _context.Entry(bloodBank).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BloodBankExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        // DELETE: api/bloodbank/{id}
        [HttpDelete("DeleteBloodBank/{id}")]
        public async Task<IActionResult> DeleteBloodBank(int id)
        {
            var bloodBank = await _context.BloodBanks.FindAsync(id);
            if (bloodBank == null)
            {
                return NotFound();
            }

            _context.BloodBanks.Remove(bloodBank);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // GET: api/bloodbank/city/{city}
        [HttpGet("BloodBankByCity/{city}")]
        public async Task<ActionResult<IEnumerable<BloodBank>>> GetBloodBanksByCity(string city)
        {
            var bloodBanks = await _context.BloodBanks
                .Where(b => b.City.Equals(city, StringComparison.OrdinalIgnoreCase))
                .ToListAsync();

            if (!bloodBanks.Any())
            {
                return NotFound();
            }

            return Ok(bloodBanks);
        }

        private bool BloodBankExists(int id)
        {
            return _context.BloodBanks.Any(e => e.BloodBankID == id);
        }
    }
}
