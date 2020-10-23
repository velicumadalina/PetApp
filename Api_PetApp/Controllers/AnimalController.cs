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
        // GET: api/Animals
        [Route("/api/Animals")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Animal>>> GetAnimals()
        {
            return await _context.Animal.ToListAsync();
        }


        /// <summary>
        /// Gets an specific animal.
        /// </summary>
        /// <param name="id"></param>
        // GET: api/Animal/5
        [Route("/api/Animals/{id}")]
        [HttpGet]
        public async Task<ActionResult<Animal>> GetAnimal(int id)
        {
            var animal = await _context.Animal.ToListAsync();
            return animal.Where(x => x.Id == id.ToString()).First();
        }


        /// <summary>
        /// Gets an specific animal.
        /// </summary>
        /// <param name="shelterId"></param>
        //GET: api/Shelters/5/Animals
       [Route("/Shelters/{shelterId}/Animals")]
       [HttpGet]
        public ActionResult<List<Animal>> GetShelterAnimals(string shelterId)
        {
            var animals = _context.Animal.Where(x => x.ShelterId == shelterId).ToList();
            return animals;
        }


        /// <summary>
        /// Edits an specific animal.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="animal"></param>
        /// PUT: api/Animals/5
        [Route("/api/Animals/{id}")]
        [HttpPut]
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
        // POST: api/Animals
        [Route("/api/Animals")]
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
        // DELETE: api/Animals/5
        [Route("/api/Animals/{id}")]
        [HttpDelete]
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
