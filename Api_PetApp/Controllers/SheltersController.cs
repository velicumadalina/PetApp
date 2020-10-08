﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_PetApp.Models;

namespace WebApi_PetApp.Controllers
{
    public class SheltersController : ControllerBase
    {

        List<Shelter> shelters = new List<Shelter>();

        public SheltersController()
        {
            shelters.Add(new Shelter
            {
                Id = "a",
                Name = "sh1",
                Image = "data:image/jpeg;base64,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",
                URL = "aaa",
                Email = "sh1@gmail.com",
                Capacity = 100,
                City = "Bucharest",
            });
            shelters.Add(new Shelter
            {
                Id = "b",
                Name = "sh2",
                Image = "data:image/jpeg;base64,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"
            });

        }
        // GET: api/Shelters
        [Route("/shelters")]
        [HttpGet]
        public ActionResult<List<Shelter>> Get()
        {
            return shelters;
        }


        [Route("/shelters/{id}")]
        [HttpGet ("{id}")]
        // GET: api/Shelters/5
        public ActionResult<Shelter> Get(string id)
        {
            return shelters.Where(x => x.Id == id).First();
        }

        //// POST: api/Shelters
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/Shelters/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Shelters/5
        //public void Delete(int id)
        //{
        //}
    }
}
