using Microsoft.AspNetCore.Mvc;
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
                Name = "Lake County",
                Image = "data:image/png;base64,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",
                Email = "lake_county@gmail.com",
                Capacity = 100,
                City = "Bucharest"
            });
            shelters.Add(new Shelter
            {
                Id = "b",
                Name = "Safe Hands",
                Image = "https://imagecdn.mightycause.com/3b04d28f-696d-499f-8265-f49b69fd146b/",
                Email = "safe_hands@gmail.com",
                Capacity = 100,
                City = "Cluj"
            });
            shelters.Add(new Shelter
            {
                Id = "c",
                Name = "Last Hope",
                Image = "https://mms.businesswire.com/media/20190422005146/en/717229/23/LastHope_Edited_Logo_Black_%26_Red_Writing_Final.jpg",
                Email = "last_hope@gmail.com",
                Capacity = 100,
                City = "Iasi"
            });
            shelters.Add(new Shelter
            {
                Id = "d",
                Name = "Happy Tails Rescue",
                Image = "https://s3.amazonaws.com/imagesroot.rescuegroups.org/webpages/s1333nert2wiero3.jpg",
                Email = "happy_tails_rescue@gmail.com",
                Capacity = 100,
                City = "Brasov"
            });
            shelters.Add(new Shelter
            {
                Id = "e",
                Name = "Gimmie Shelter",
                Image = "https://gimmeshelteranimalrescue.org/wp-content/uploads/2015/12/Gimme-Shelter-logo.jpg",
                Email = "gimmie_shelter@gmail.com",
                Capacity = 100,
                City = "Constanta"
            });
            shelters.Add(new Shelter
            {
                Id = "f",
                Name = "Wollies",
                Image = "https://wollies.org/images/nicepage-images/wolliesanimalshelterlogo.png",
                Email = "wollies@gmail.com",
                Capacity = 100,
                City = "Bucharest"
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
