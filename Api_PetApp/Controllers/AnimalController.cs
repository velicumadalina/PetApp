using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api_PetApp.Data;
using WebApi_PetApp.Models;
using Api_PetApp.Models;

namespace Api_PetApp.Controllers
{
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalRepository _repository;

        public AnimalController(IAnimalRepository repository) 
        {
            _repository = repository;
        }


        /// <summary>
        /// Gets all animals.
        /// </summary>
        // GET: api/Animals
        [Route("/api/Animals")]
        [HttpGet]
        public IEnumerable<Animal> GetAnimals()
        {
            return _repository.GetAllAnimals();
        }


        /// <summary>
        /// Gets an specific animal.
        /// </summary>
        /// <param name="id"></param>
        // GET: api/Animal/5
        [Route("/api/Animals/{id}")]
        [HttpGet]
        public ActionResult<Animal> GetAnimal(int id)
        {
            return _repository.GetAnimal(id);
        }


        /// <summary>
        /// Gets an specific animal.
        /// </summary>
        /// <param name="shelterId"></param>
        //GET: api/Shelters/5/Animals
       [Route("/Shelters/{shelterId}/Animals")]
       [HttpGet]
        public IEnumerable<Animal> GetShelterAnimals(int shelterId)
        {
            //var animals = _context.Animal.Where(x => x.ShelterId == shelterId).ToList();
            return _repository.GetShelterAnimals(shelterId);
        }


        /// <summary>
        /// Edits an specific animal.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="animal"></param>
        /// PUT: api/Animals/5
        [Route("/api/Animals/{id}")]
        [HttpPut]
        public async Task<IActionResult> PutAnimal(int id, Animal animal)
        {
            if (id != animal.Id)
            {
                return BadRequest();
            }

            try
            {
                _repository.Update(id, animal);
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
            try
            {
                _repository.Add(animal);
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
        public async Task<ActionResult<Animal>> DeleteAnimal(int id)
        {
            var animal = _repository.GetAnimal(id);
            if (animal == null)
            {
                return NotFound();
            }



            return _repository.Delete(id);
        }

        private bool AnimalExists(int id)
        {
            return _repository.AnimalExists(id);
        }
    }
}
