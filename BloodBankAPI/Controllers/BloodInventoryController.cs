using BloodBankAPI.Helper;
using BloodBankAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BloodBankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloodInventoryController : ControllerBase
    {
        private readonly DataBaseContextcs _context;
        public BloodInventoryController(DataBaseContextcs context)
        {
            _context = context;
        }
        // GET: api/bloodinventory
        [HttpGet("GetBloodInventories")]
        public async Task<ActionResult<IEnumerable<BloodInventory>>> GetBloodInventories()
        {
            return await _context.BloodInventories.ToListAsync();
        }

        // GET: api/bloodinventory/{id}
        [HttpGet("GetBloodInventorybyID/{id}")]
        public async Task<ActionResult<BloodInventory>> GetBloodInventory(int id)
        {
            var bloodInventory = await _context.BloodInventories.FindAsync(id);

            if (bloodInventory == null)
            {
                return NotFound();
            }

            return bloodInventory;
        }

        // POST: api/bloodinventory
        [HttpPost("CreateBloodInventory")]
        public async Task<ActionResult<BloodInventory>> CreateBloodInventory(BloodInventory bloodInventory)
        {
            _context.BloodInventories.Add(bloodInventory);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBloodInventory), new { id = bloodInventory.BloodInventoryID }, bloodInventory);
        }

        // PUT: api/bloodinventory/{id}
        [HttpPut("UpdateBloodInventory/{id}")]
        public async Task<IActionResult> UpdateBloodInventory(int id, BloodInventory bloodInventory)
        {
            if (id != bloodInventory.BloodInventoryID)
            {
                return BadRequest();
            }

            _context.Entry(bloodInventory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BloodInventoryExists(id))
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

        // DELETE: api/bloodinventory/{id}
        [HttpDelete("DeleteBloodInventory/{id}")]
        public async Task<IActionResult> DeleteBloodInventory(int id)
        {
            var bloodInventory = await _context.BloodInventories.FindAsync(id);
            if (bloodInventory == null)
            {
                return NotFound();
            }

            _context.BloodInventories.Remove(bloodInventory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BloodInventoryExists(int id)
        {
            return _context.BloodInventories.Any(e => e.BloodInventoryID == id);
        }

    }
}
