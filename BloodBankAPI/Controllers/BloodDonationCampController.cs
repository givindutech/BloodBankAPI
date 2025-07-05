using BloodBankAPI.Helper;
using BloodBankAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BloodBankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloodDonationCampController : ControllerBase
    {
        private readonly DataBaseContextcs _context;
        public BloodDonationCampController(DataBaseContextcs context)
        {
            _context = context;
        }
        // GET: api/blooddonationcamp
        [HttpGet("GetBloodDonationCamps")]
        public async Task<ActionResult<IEnumerable<BloodDonationCamp>>> GetBloodDonationCamps()
        {
            return await _context.BloodDonationCamps.ToListAsync();
        }
        // GET: api/blooddonationcamp/{id}
        [HttpGet("BloodDonationCampbyID/{id}")]
        public async Task<ActionResult<BloodDonationCamp>> GetBloodDonationCamp(int id)
        {
            var bloodDonationCamp = await _context.BloodDonationCamps.FindAsync(id);

            if (bloodDonationCamp == null)
            {
                return NotFound();
            }

            return bloodDonationCamp;
        }
        // POST: api/blooddonationcamp
        [HttpPost("CreateBloodDonationCamp")]
        public async Task<ActionResult<BloodDonationCamp>> PostBloodDonationCamp(BloodDonationCamp bloodDonationCamp)
        {
            _context.BloodDonationCamps.Add(bloodDonationCamp);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBloodDonationCamp), new { id = bloodDonationCamp.BloodDonationCampId }, bloodDonationCamp);
        }
        // PUT: api/blooddonationcamp/{id}
        [HttpPut("UpdateBloodDonationCamp/{id}")]
        public async Task<IActionResult> PutBloodDonationCamp(int id, BloodDonationCamp bloodDonationCamp)
        {
            if (id != bloodDonationCamp.BloodDonationCampId)
            {
                return BadRequest();
            }

            _context.Entry(bloodDonationCamp).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BloodDonationCampExists(id))
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

        // DELETE: api/blooddonationcamp/{id}
        [HttpDelete("DeleteBloodDonationCamp/{id}")]
        public async Task<IActionResult> DeleteBloodDonationCamp(int id)
        {
            var bloodDonationCamp = await _context.BloodDonationCamps.FindAsync(id);
            if (bloodDonationCamp == null)
            {
                return NotFound();
            }

            _context.BloodDonationCamps.Remove(bloodDonationCamp);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BloodDonationCampExists(int id)
        {
            return _context.BloodDonationCamps.Any(e => e.BloodDonationCampId == id);
        }
    }
}
