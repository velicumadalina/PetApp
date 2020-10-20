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
    public class AnimalController : ControllerBase
    {
        private readonly Api_PetAppAnimalsContext _context;

        public AnimalController(Api_PetAppAnimalsContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets all animals.
        /// </summary>
        // GET: api/Animal
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Animal>>> GetAnimal()
        {
            return await _context.Animal.ToListAsync();
        }

        /// <summary>
        /// Gets an specific animal.
        /// </summary>
        /// <param name="id"></param>
        // GET: api/Animal/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Animal>> GetAnimal(string id)
        {
            var animal = await _context.Animal.FindAsync(id);

            if (animal == null)
            {
                return NotFound();
            }

            return animal;
        }

        /// <summary>
        /// Edits an specific animal.
        /// </summary>
        /// <param name="id"></param>
        // PUT: api/Animal/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnimal(string id, Animal animal)
        {
            if (id != animal.Id)
            {
                return BadRequest();
            }

            _context.Entry(animal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnimalExists(id))
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
        /// Creates a new animal.
        /// </summary>
        // POST: api/Animal
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Animal>> PostAnimal(Animal animal)
        {
            _context.Animal.Add(animal);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AnimalExists(animal.Id))
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
        /// Deletes an specific animal.
        /// </summary>
        /// <param name="id"></param>
        // DELETE: api/Animal/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Animal>> DeleteAnimal(string id)
        {
            var animal = await _context.Animal.FindAsync(id);
            if (animal == null)
            {
                return NotFound();
            }

            _context.Animal.Remove(animal);
            await _context.SaveChangesAsync();

            return animal;
        }

        private bool AnimalExists(string id)
        {
            return _context.Animal.Any(e => e.Id == id);
        }
    }
}
