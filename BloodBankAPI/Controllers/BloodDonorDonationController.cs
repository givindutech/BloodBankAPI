using BloodBankAPI.Helper;
using BloodBankAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BloodBankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloodDonorDonationController : ControllerBase
    {
        private readonly DataBaseContextcs _context;
        public BloodDonorDonationController(DataBaseContextcs context)
        {
            _context = context;
        }
        // GET: api/blooddonordonation
        [HttpGet("GetBloodDonorDonations")]
        public async Task<ActionResult<IEnumerable<BloodDonorDonation>>> GetBloodDonorDonations()
        {
            return await _context.BloodDonorDonations.ToListAsync();
        }
        // GET: api/blooddonordonation/{id}
        [HttpGet("GetBloodDonorDonation/{id}")]
        public async Task<ActionResult<BloodDonorDonation>> GetBloodDonorDonation(int id)
        {
            var bloodDonorDonation = await _context.BloodDonorDonations.FindAsync(id);

            if (bloodDonorDonation == null)
            {
                return NotFound();
            }

            return bloodDonorDonation;
        }

        // POST: api/blooddonordonation
        [HttpPost("CreateBloodDonorDonation")]
        public async Task<ActionResult<BloodDonorDonation>> CreateBloodDonorDonation(BloodDonorDonation bloodDonorDonation)
        {
            _context.BloodDonorDonations.Add(bloodDonorDonation);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBloodDonorDonation), new { id = bloodDonorDonation.BloodDonorDonationId }, bloodDonorDonation);
        }

        // PUT: api/blooddonordonation/{id}
        [HttpPut("UpdateBloodDonorDonation/{id}")]
        public async Task<IActionResult> UpdateBloodDonorDonation(int id, BloodDonorDonation bloodDonorDonation)
        {
            if (id != bloodDonorDonation.BloodDonorDonationId)
            {
                return BadRequest();
            }

            _context.Entry(bloodDonorDonation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BloodDonorDonationExists(id))
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

        // DELETE: api/blooddonordonation/{id}
        [HttpDelete("DeleteBloodDonorDonation/{id}")]
        public async Task<IActionResult> DeleteBloodDonorDonation(int id)
        {
            var bloodDonorDonation = await _context.BloodDonorDonations.FindAsync(id);
            if (bloodDonorDonation == null)
            {
                return NotFound();
            }

            _context.BloodDonorDonations.Remove(bloodDonorDonation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BloodDonorDonationExists(int id)
        {
            return _context.BloodDonorDonations.Any(e => e.BloodDonorDonationId == id);
        }
    }
}
