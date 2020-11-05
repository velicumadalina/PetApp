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
        private readonly PetAppContext _context;

        public ShelterController(PetAppContext context)
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
            var result = await _context.Shelter.Include(s => s.Animals).ToListAsync();
            return result;
        }


        /// <summary>
        /// Gets an specific shelter.
        /// </summary>
        /// <param name="id"></param>
        // GET: api/Shelter/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Shelter>> GetShelter(int id)
        {
            var shelter = await _context.Shelter.FindAsync(id);

            if (shelter == null)
            {
                return NotFound();
            }

            return shelter;
        }


        /// <summary>
        /// Edits an specific shelter.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="shelter"></param>
        // PUT: api/Shelter/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShelter(int id, Shelter shelter)
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
        /// Creates a new shelter.
        /// </summary>
        // POST: api/Shelter
        [HttpPost]
        public async Task<ActionResult<Shelter>> PostShelter([FromBody]Shelter shelter)
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


        private bool ShelterExists(int id)
        {
            return _context.Shelter.Any(e => e.Id == id);
        }
    }
}
