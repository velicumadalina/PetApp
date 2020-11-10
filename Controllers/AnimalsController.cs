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
        public async Task<ActionResult<Animal>> PostAnimal([FromBody]Animal animal)
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


        private bool AnimalExists(int id)
        {
            return _context.Animal.Any(e => e.Id == id);
        }
    }
}
