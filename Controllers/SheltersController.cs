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
    public class SheltersController : Controller
    {
        private readonly PetAppDbContext _context;

        public SheltersController(PetAppDbContext context)
        {
            _context = context;
        }
        [Route("/add-shelter")]
        [HttpPost]
        [Consumes("application/json")]
        public async Task<ActionResult<Relation>> PostShelter([FromBody]Relation relation)
        {
            var shelter = new Shelter();
            shelter.Name = relation.Name;
            shelter.Image = relation.Image;
            shelter.Email = relation.Email;
            shelter.Capacity = relation.Capacity;
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
            return Redirect("/add-relation/" + shelter.Id + "/" + relation.UserId);
        }

        [Route("/add-shelter")]
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

        private bool ShelterExists(int id)
        {
            return _context.Shelter.Any(e => e.Id == id);
        }
    }
}
