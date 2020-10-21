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

        private List<Animal> filteredAnimals;
        public AnimalController(Api_PetAppAnimalsContext context)
        {
            _context = context;
        }




        // GET: api/Animal
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
        [Route("/api/Animal/{id}")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Animal>> GetAnimal(string id)
        {
            var animal = await _context.Animal.ToListAsync();
            return animal.Where(x => x.Id == id).First();
        }

        /// <summary>
        /// Gets an specific animal.
        /// </summary>
        /// <param name="shelterId"></param>
        // GET: api/Shelter/5/Animals
        [Route("/Shelter/{shelterId}/Animals")]
        [HttpGet("{shelterId}")]
        public ActionResult<List<Animal>> GetShelterAnimals(string shelterId)
        {
            var animals = _context.Animal.Where(x => x.ShelterId == shelterId).ToList();
            return animals;
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
        //[Route("/")]
        //[HttpPost]
        //public async Task<ActionResult<Animal>> FilterAnimal(ICollection<KeyValuePair<string,string[]>> dict)
        //{
        //    return Ok();
        //}

        //[Route("/my-perfect-pet")]
        //[HttpPost]
        //public ActionResult<List<Animal>> AllAnimals([FromBody] FilteringItem filteringItem)
        //{

        //    var animals = _context.Animal.ToList();
        //    if (filteringItem.Type[0] != "null")
        //    {
        //        foreach (var type in filteringItem.Type)
        //        {
        //            animals = animals.Where(x => x.Type == type).ToList();
        //        }
        //    }
        //    if (filteringItem.Breed[0]!= "true")
        //    {
        //        animals = animals.Where(x => x.Breed != "Mixed").ToList();
        //    }
        //    if (filteringItem.Age[0] != "null")
        //    {
        //        foreach (var age in filteringItem.Age)
        //        {
        //            animals = animals.Where(x => x.Age == age).ToList();
        //        }
        //    }
        //    if (filteringItem.EnergyLevel[0] != "null")
        //    {
        //        foreach (var energy in filteringItem.EnergyLevel)
        //        {
        //            animals = animals.Where(x => x.EnergyLevel == energy).ToList();
        //        }
        //    }
        //    if (filteringItem.Size[0] != "null")
        //    {
        //        foreach (var size in filteringItem.Size)
        //        {
        //            animals = animals.Where(x => x.Size == size).ToList();
        //        }
        //    }
        //    if (filteringItem.Gender[0] != "null")
        //    {
        //        foreach (var gender in filteringItem.Gender)
        //        {
        //            animals = animals.Where(x => x.Gender == gender).ToList();
        //        }
        //    }
        //    if (filteringItem.FriendlyWithDogs[0] != null)
        //    {
        //        animals = animals.Where(x => x.FriendlyWithDogs == true).ToList();
        //    }
        //    if (filteringItem.FriendlyWithCats[0] != "null")
        //    {
        //        animals = animals.Where(x => x.FriendlyWithCats == true).ToList();

        //    }
        //    if (filteringItem.FriendlyWithKids[0] != "null")
        //    {
        //        animals = animals.Where(x => x.FriendlyWithDogs == true).ToList();
        //    }

        //    return animals;
        //}
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
