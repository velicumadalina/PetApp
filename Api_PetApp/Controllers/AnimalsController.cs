using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi_PetApp.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api_PetApp.Controllers
{
    public class AnimalsController : ControllerBase
    {
        List<Animal> animals = new List<Animal>();

        public AnimalsController()
        {
            animals.Add(new Animal {
            Id = 1,
            Name = "an1",
            ShelterId = "a",
            Characteristics = new string[] { "very", "nice" } ,
            Gender = "female",
            Type = "Cat",
            Age = "Junior",
            EnergyLevel = "High",
            Size="small",
            Hair ="long",
            FriendlyWithCats = true,
            FriendlyWithDogs = true,
            FriendlyWithKids = false,
            SpecialNeeds = false,
            Description = "very nice",
            Breed = "mixed"
            });
        }


        // GET: api/<AnimalsController>
        [Route("/animals")]
        [HttpGet]
        public ActionResult<List<Animal>> Get()
        {
            return animals;
        }

        // GET api/<AnimalsController>/5
        [Route("/animals/{id}")]
        [HttpGet("{id}")]
        public ActionResult<Animal> Get(int id)
        {
            return animals.Where(x => x.Id == id).First();
        }

        [Route("/animals/shelter/{shelter_id}")]
        [HttpGet("{shelter_id}")]
        public ActionResult<List<Animal>> Get(string shelter_id)
        {
            return animals.Where(x => x.ShelterId == shelter_id).ToList();
        }







        //// POST api/<AnimalsController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<AnimalsController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<AnimalsController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
