//using Microsoft.AspNetCore.Mvc;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using WebApi_PetApp.Models;

//namespace WebApi_PetApp.Controllers
//{
//    public class SheltersController : ControllerBase
//    {

//        List<Shelter> shelters = new List<Shelter>();

//        public SheltersController()
//        {
//            shelters.Add(new Shelter
//            {
//                Id = "a",
//                Name = "Lake County",
//                Image = "Lake_County.jpg",
//                Email = "lake_county@gmail.com",
//                Capacity = "100",
//                City = "Bucharest"
//            });
//            shelters.Add(new Shelter
//            {
//                Id = "b",
//                Name = "Safe Hands",
//                Image = "Safe_Hands.jpg",
//                Email = "safe_hands@gmail.com",
//                Capacity = "100",
//                City = "Cluj"
//            });
//            shelters.Add(new Shelter
//            {
//                Id = "c",
//                Name = "Last Hope",
//                Image = "Last_Hope.jpg",
//                Email = "last_hope@gmail.com",
//                Capacity = "100",
//                City = "Iasi"
//            });
//            shelters.Add(new Shelter
//            {
//                Id = "d",
//                Name = "Happy Tails Rescue",
//                Image = "Happy_Tails_Rescue.jpg",
//                Email = "happy_tails_rescue@gmail.com",
//                Capacity = "100",
//                City = "Brasov"
//            });
//            shelters.Add(new Shelter
//            {
//                Id = "e",
//                Name = "Gimmie Shelter",
//                Image = "Gimmie_Shelter.jpg",
//                Email = "gimmie_shelter@gmail.com",
//                Capacity = "100",
//                City = "Constanta"
//            });
//            shelters.Add(new Shelter
//            {
//                Id = "f",
//                Name = "Wollies",
//                Image = "Wollies.png",
//                Email = "wollies@gmail.com",
//                Capacity = "100",
//                City = "Bucharest"
//            });
//        }


//        // GET: api/Shelters
//        [Route("/shelters")]
//        [HttpGet]
//        public ActionResult<List<Shelter>> Get()
//        {
//            return shelters;
//        }


//        [Route("/shelters/{id}")]
//        [HttpGet ("{id}")]
//        // GET: api/Shelters/5
//        public ActionResult<Shelter> Get(string id)
//        {
//            return shelters.Where(x => x.Id == id).First();
//        }

//        //// POST: api/Shelters
//        //public void Post([FromBody]string value)
//        //{
//        //}

//        //// PUT: api/Shelters/5
//        //public void Put(int id, [FromBody]string value)
//        //{
//        //}

//        //// DELETE: api/Shelters/5
//        //public void Delete(int id)
//        //{
//        //}
//    }
//}
