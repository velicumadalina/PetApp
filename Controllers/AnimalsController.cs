using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PetApp.Data;
using PetApp.Models;

namespace PetApp.Controllers
{
    public class AnimalsController : Controller
    {
        private readonly PetAppDbContext _context;

        public AnimalsController(PetAppDbContext context)
        {
            _context = context;
        }


        [Route("/add-animal")]
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

        [Route("/set-adopted/{id}")]
        [HttpGet]
        public async Task<IActionResult> SetAdoptedAnimal(int id)
        {

            var animal = _context.Animal.Where(a => a.Id == id).FirstOrDefault();
            if (animal != null) { animal.IsAdopted = true; }
            else { return BadRequest(); }

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

        private bool AnimalExists(int id)
        {
            return _context.Animal.Any(e => e.Id == id);
        }
    }
}
