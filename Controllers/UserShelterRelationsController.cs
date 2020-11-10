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
    public class UserShelterRelationsController : Controller
    {
        private readonly PetAppDbContext _context;

        public UserShelterRelationsController(PetAppDbContext context)
        {
            _context = context;
        }

        [Route("/add-relation/{shelterId}/{userId}")]
        [HttpGet]
        [Consumes("application/json")]
        public async Task<ActionResult<Shelter>> AddRelation(int userId, int shelterId)
        {
            var relation = new UserShelterRelation();
            relation.ShelterId = shelterId;
            relation.UserId = userId;

        _context.UserShelterRelations.Add(relation);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserShelterRelationExists(relation.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction("Login", "User");
        }

        private bool UserShelterRelationExists(int id)
        {
            return _context.UserShelterRelations.Any(e => e.Id == id);
        }
    }
}
