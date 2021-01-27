using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api_PetApp.Data;
using WebApi_PetApp.Models;
using Microsoft.AspNetCore.Cors;
using Api_PetApp.Models;

namespace Api_PetApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShelterController : ControllerBase
    {
        private readonly IShelterRepository _repository;

        public ShelterController(IShelterRepository repository)
        {
            _repository = repository;
        }


        /// <summary>
        /// Gets all shelters.
        /// </summary>
        // GET: api/Shelter
        [HttpGet]
        public IEnumerable<Shelter> GetShelter()
        {
            return _repository.GetShelter();
        }


        /// <summary>
        /// Gets an specific shelter.
        /// </summary>
        /// <param name="id"></param>
        // GET: api/Shelter/5
        [HttpGet("{id}")]
        public ActionResult<Shelter> GetShelter(int id)
        {
            var shelter = _repository.GetShelter(id);

            if (shelter == null)
            {
                return NotFound();
            }

            return shelter;
        }

        //[HttpGet("{email}")]
        //[Route("/get-shelter-by-email/{email}")]
        //public async Task<ActionResult<Shelter>> GetShelterByEmail(string email)
        //{
        //    var shelter = await _context.Shelter.Where(s => s.Email == email).FirstOrDefaultAsync();

        //    if (shelter == null)
        //    {
        //        return NotFound();
        //    }

        //    return shelter;
        //}

        /// <summary>
        /// Edits an specific shelter.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="shelter"></param>
        // PUT: api/Shelter/5
        [HttpPut("{id}")]
        public ActionResult PutShelter(int id, Shelter shelter)
        {
            if (id != shelter.Id)
            {
                return BadRequest();
            }

           

            try
            {
                _repository.EditShelter(id, shelter);
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
        [Consumes("application/json")]
        public async Task<ActionResult<Shelter>> PostShelter(Shelter shelter)
        {
            
            try
            {
                _repository.AddShelter(shelter);
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

        [HttpPost]
        [Route("/api/shelter/add")]
        [Consumes("application/json")]
        public async Task<ActionResult<Shelter>> AddShelter(Shelter shelter)
        {
            try
            {
                _repository.AddShelter(shelter);
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
        public async Task<ActionResult<Shelter>> DeleteShelter(int id)
        {
            var shelter = _repository.DeleteShelter(id);
            if (shelter == null)
            {
                return NotFound();
            }

            return shelter;
        }


        private bool ShelterExists(int id)
        {
            return _repository.ShelterExists(id);
        }
    }
}
