using BloodBankAPI.Helper;
using BloodBankAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BloodBankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloodDonorController : ControllerBase
    {
        private readonly DataBaseContextcs _context;
        public BloodDonorController(DataBaseContextcs context)
        {
            _context = context;
        }
        // GET: api/blooddonor
        [HttpGet("GetBloodDonors")]
        public async Task<ActionResult<IEnumerable<BloodDonor>>> GetBloodDonors()
        {
            return await _context.BloodDonors.ToListAsync();
        }
        // GET: api/blooddonor/{id}
        [HttpGet("GetBloodDonor/{id}")]
        public async Task<ActionResult<BloodDonor>> GetBloodDonor(int id)
        {
            var bloodDonor = await _context.BloodDonors.FindAsync(id);

            if (bloodDonor == null)
            {
                return NotFound();
            }

            return bloodDonor;
        }
        // POST: api/blooddonor
        [HttpPost("CreateBloodDonor")]
        public async Task<ActionResult<BloodDonor>> CreateBloodDonor(BloodDonor bloodDonor)
        {
            _context.BloodDonors.Add(bloodDonor);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBloodDonor), new { id = bloodDonor.BloodDonorId }, bloodDonor);
        }
        // PUT: api/blooddonor/{id}
        [HttpPut("UpdateBloodDonor/{id}")]
        public async Task<IActionResult> UpdateBloodDonor(int id, BloodDonor bloodDonor)
        {
            if (id != bloodDonor.BloodDonorId)
            {
                return BadRequest();
            }

            _context.Entry(bloodDonor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BloodDonorExists(id))
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
        // DELETE: api/blooddonor/{id}
        [HttpDelete("DeleteBloodDonor/{id}")]
        public async Task<IActionResult> DeleteBloodDonor(int id)
        {
            var bloodDonor = await _context.BloodDonors.FindAsync(id);
            if (bloodDonor == null)
            {
                return NotFound();
            }

            _context.BloodDonors.Remove(bloodDonor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BloodDonorExists(int id)
        {
            return _context.BloodDonors.Any(e => e.BloodDonorId == id);
        }
    }
}
