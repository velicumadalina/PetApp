using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api_PetApp.Data;
using WebApi_PetApp.Models;

namespace Api_PetApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShelterController : ControllerBase
    {
        private readonly Api_PetAppShelterContext _context;

        public ShelterController(Api_PetAppShelterContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets all shelters.
        /// </summary>
        // GET: api/Shelter
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shelter>>> GetShelter()
        {
            return await _context.Shelter.ToListAsync();
        }

        /// <summary>
        /// Gets an specific shelter.
        /// </summary>
        /// <param name="id"></param>
        // GET: api/Shelter/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Shelter>> GetShelter(string id)
        {
            var shelter = await _context.Shelter.FindAsync(id);

            if (shelter == null)
            {
                return NotFound();
            }

            return shelter;
        }

        /// <summary>
        /// Edit an specific shelter.
        /// </summary>
        /// <param name="id"></param>
        // PUT: api/Shelter/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShelter(string id, Shelter shelter)
        {
            if (id != shelter.Id)
            {
                return BadRequest();
            }

            _context.Entry(shelter).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShelterExists(id))
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

        /// <summary>
        /// Adds shelter.
        /// </summary>
        // POST: api/Shelter
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Shelter>> PostShelter(Shelter shelter)
        {
            _context.Shelter.Add(shelter);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ShelterExists(shelter.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            //return CreatedAtAction("GetShelter", new { id = shelter.Id }, shelter);
            return Ok();
        }

        /// <summary>
        /// Deletes an specific shelter.
        /// </summary>
        /// <param name="id"></param>
        // DELETE: api/Shelter/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Shelter>> DeleteShelter(string id)
        {
            var shelter = await _context.Shelter.FindAsync(id);
            if (shelter == null)
            {
                return NotFound();
            }

            _context.Shelter.Remove(shelter);
            await _context.SaveChangesAsync();

            return shelter;
        }

        private bool ShelterExists(string id)
        {
            return _context.Shelter.Any(e => e.Id == id);
        }
    }
}
