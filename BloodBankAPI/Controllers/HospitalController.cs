using BloodBankAPI.Helper;
using BloodBankAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BloodBankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalController : ControllerBase
    {
        private readonly DataBaseContextcs _context;
        public HospitalController(DataBaseContextcs context)
        {
            _context = context;
        }
        // GET: api/hospital
        [HttpGet("GetHospitals")]
        public async Task<ActionResult<IEnumerable<Hospital>>> GetHospitals()
        {
            return await _context.Hospitals.ToListAsync();
        }
        // GET: api/hospital/{id}
        [HttpGet("GetHospital/{id}")]
        public async Task<ActionResult<Hospital>> GetHospital(int id)
        {
            var hospital = await _context.Hospitals.FindAsync(id);

            if (hospital == null)
            {
                return NotFound();
            }

            return hospital;
        }
        // POST: api/hospital
        [HttpPost("AddNewHospital")]
        public async Task<ActionResult<Hospital>> AddNewHospital(Hospital hospital)
        {
            _context.Hospitals.Add(hospital);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetHospital), new { id = hospital.HospitalId }, hospital);
        }

        // PUT: api/hospital/{id}
        [HttpPut("UpdateHospitalDetails/{id}")]
        public async Task<IActionResult> UpdateHospitalDetails(int id, Hospital hospital)
        {
            if (id != hospital.HospitalId)
            {
                return BadRequest();
            }

            _context.Entry(hospital).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalExists(id))
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

        // DELETE: api/hospital/{id}
        [HttpDelete("DeleteHospital/{id}")]
        public async Task<IActionResult> DeleteHospital(int id)
        {
            var hospital = await _context.Hospitals.FindAsync(id);
            if (hospital == null)
            {
                return NotFound();
            }

            _context.Hospitals.Remove(hospital);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HospitalExists(int id)
        {
            return _context.Hospitals.Any(e => e.HospitalId == id);
        }
    }
}
