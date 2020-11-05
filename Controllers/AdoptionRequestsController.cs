using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PetApp.Data;
using PetApp.Models;
using EmailHelper;
using System.Net.Mail;
using System.Net.Http;
using Newtonsoft.Json;

namespace PetApp.Controllers
{
    public class AdoptionRequestsController : Controller
    {
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        private readonly PetAppDbContext _context;
        private readonly string _apiPath = "https://localhost:44306/";


        public AdoptionRequestsController(PetAppDbContext context, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // GET: AdoptionRequests

        [Route("/requests")]
        public async Task<IActionResult> UserRequests()
        {
            var requests = new List<AdoptionRequest>();
            try
            {
                requests = await _context.adoptionRequests.Where(x => x.UserId == int.Parse(_userManager.GetUserId(User))).ToListAsync();
            }
            catch
            {
            }
            return View(requests);
        }

        [Route("/shelter/animal-requests")]
        public async Task<IActionResult> AnimalRequests()
        {
            var requests = new List<AdoptionRequest>();
            var user = _context.appUsers.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();
            Shelter shelter;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(_apiPath + "get-shelter-by-email/"+ user.Email))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    shelter = JsonConvert.DeserializeObject<Shelter>(apiResponse);
                }
            }

            try
            {
                requests = await _context.adoptionRequests.Where(r => r.ShelterId == shelter.Id).Where(a => a.AdoptionStatus != "Approved").ToListAsync();
            }
            catch
            {
            }
            return View(requests);
        }

        [Route("/favorites")]
        public async Task<IActionResult> Favorites()
        {
            var favorites = new List<FavoriteAnimal>();
            try
            {
                favorites = await _context.Favorites.Where(x => x.UserId == int.Parse(_userManager.GetUserId(User))).ToListAsync();
            }
            catch
            {
            }
            return View(favorites);
        }

        // GET: AdoptionRequests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adoptionRequest = await _context.adoptionRequests
                .FirstOrDefaultAsync(m => m.Id == id);
            if (adoptionRequest == null)
            {
                return NotFound();
            }

            return View(adoptionRequest);
        }

        // GET: AdoptionRequests/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdoptionRequests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("/adopt-pet")]
        [Consumes("application/json")]
        [HttpPost]
        public async Task<ActionResult<AdoptionRequest>> AddAdoptionRequest([FromBody] AdoptionRequest adoptionRequest)
        {
            _context.adoptionRequests.Add(adoptionRequest);
            try
            {
                EmailHelper.EmailHelper helper = new EmailHelper.EmailHelper();

                helper.sendEmail(new MailAddress("pet.application.1@gmail.com"), "pet.application.1@gmail.com", "Pet Adoption", adoptionRequest.AdoptionMessasge);

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AdoptionRequestExists(adoptionRequest.Id))
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

        [Route("/favorite-pet")]
        [Consumes("application/json")]
        [HttpPost]
        public async Task<ActionResult<AdoptionRequest>> AddFavoritePet([FromBody] FavoriteAnimal favorite)
        {
            _context.Favorites.Add(favorite);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FavoriteAnimalExists(favorite.Id))
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


        // GET: AdoptionRequests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adoptionRequest = await _context.adoptionRequests.FindAsync(id);
            if (adoptionRequest == null)
            {
                return NotFound();
            }
            return View(adoptionRequest);
        }

        // POST: AdoptionRequests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpGet]
        [Route("/confirm-adoption/{id}")]
        public async Task<IActionResult> ConfirmAdoption(int id)
        {
            var request = _context.adoptionRequests.Where(a => a.AnimalId == id).FirstOrDefault();
            if (request != null) 
            {
                request.AdoptionStatus = "Approved";
            }
                try
                {
                    _context.Update(request);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdoptionRequestExists(request.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
        }

        //// GET: AdoptionRequests/Delete/5
        [Route("/adoptionrequests/delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adoptionRequest = await _context.adoptionRequests.Where(a => a.AnimalId == id).FirstOrDefaultAsync();
            _context.adoptionRequests.Remove(adoptionRequest);
            await _context.SaveChangesAsync();
            return RedirectToAction("AnimalRequests");
        }

        // POST: AdoptionRequests/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var adoptionRequest = await _context.adoptionRequests.Where(a => a.AnimalId == id).FirstOrDefaultAsync();
        //    _context.adoptionRequests.Remove(adoptionRequest);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool AdoptionRequestExists(int id)
        {
            return _context.adoptionRequests.Any(e => e.Id == id);
        }

        private bool FavoriteAnimalExists(int id)
        {
            return _context.Favorites.Any(e => e.Id == id);
        }
    }
}
