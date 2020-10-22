using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PetApp.Models;
using RestSharp;
using WebApplication1.Models;

namespace PetApp.Controllers
{
    public class HomeController : Controller
    {
        private static List<Animal> filteredAnimals = new List<Animal>();
        private bool x;

        private readonly ILogger<HomeController> _logger;
        private readonly string _apiPath;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _apiPath = "https://localhost:44306/";
        }

        public async Task<IActionResult> Index()
        {
            List<Shelter> shelterList = new List<Shelter>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(_apiPath + "api/Shelter"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    shelterList = JsonConvert.DeserializeObject<List<Shelter>>(apiResponse);
                }
            }
            return View(shelterList);
        }



        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Quiz()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Route("Shelter/{id}")]
        public async Task<IActionResult> Shelter(string id)
        {
            List<Animal> animalsList = new List<Animal>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(_apiPath + "Shelter/"  + id + "/Animals"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    animalsList = JsonConvert.DeserializeObject<List<Animal>>(apiResponse);
                    foreach (var animal in animalsList)
                    {
                        Dictionary<string, bool> _getsAlongWith = new Dictionary<string, bool>(){
            { "Dogs", animal.FriendlyWithDogs },
            { "Cats", animal.FriendlyWithCats },
            { "Kids", animal.FriendlyWithKids }
        };


                        var str = new List<string>();
                        foreach (KeyValuePair<string, bool> kv in _getsAlongWith)
                        {
                            if (kv.Value == true)
                            {
                                str.Add(kv.Key);
                            }
                        }
                        animal.GetsAlongWith = String.Join(",", str);
                    }

                }
            }
            return View(animalsList);

        }

        [Route("/my-perfect-pets")]
        [HttpGet]
        public ActionResult<IEnumerable<Animal>> AllAnimals()
        {
            var animals = filteredAnimals;
            Console.WriteLine(x);
            return View(filteredAnimals);
        }

        [HttpPost]
        [Consumes("application/json")]
        [Route("/my-perfect-pet")]
        public async Task<ActionResult<List<Animal>>> FilterAllAnimals([FromBody] FilteringItem filteringItem)
        {
           
            List<Animal> animals = new List<Animal>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(_apiPath + "api/Animal"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    animals = JsonConvert.DeserializeObject<List<Animal>>(apiResponse);
                    foreach (var animal in animals)
                    {
                        Dictionary<string, bool> _getsAlongWith = new Dictionary<string, bool>(){
            { "Dogs", animal.FriendlyWithDogs },
            { "Cats", animal.FriendlyWithCats },
            { "Kids", animal.FriendlyWithKids }
        };
                        var str = new List<string>();
                        foreach (KeyValuePair<string, bool> kv in _getsAlongWith)
                        {
                            if (kv.Value == true)
                            {
                                str.Add(kv.Key);
                            }
                        }
                        animal.GetsAlongWith = String.Join(",", str);
                    }
                }
            }
            Console.WriteLine(animals);
            if (filteringItem.Type[0] != "null")
            {
                foreach (var type in filteringItem.Type)
                {
                    animals = animals.Where(x => x.Type == type).ToList();
                }
            }
            if (filteringItem.Breed[0] != "false")
            {
                    animals = animals.Where(x => x.Breed != "Mixed").ToList();
            }
            if (filteringItem.Age[0] != "null")
            {
                foreach (var age in filteringItem.Age)
                {
                    animals = animals.Where(x => x.Age == age).ToList();
                }
            }
            if (filteringItem.EnergyLevel[0] != "null")
            {
                foreach (var energy in filteringItem.EnergyLevel)
                {
                    animals = animals.Where(x => x.EnergyLevel == energy).ToList();
                }
            }
            if (filteringItem.Size[0] != "null")
            {
                foreach (var size in filteringItem.Size)
                {
                    animals = animals.Where(x => x.Size == size).ToList();
                }
            }
            if (filteringItem.Gender[0] != "null")
            {
                foreach (var gender in filteringItem.Gender)
                {
                    animals = animals.Where(x => x.Gender == gender).ToList();
                }
            }
            if (filteringItem.FriendlyWithDogs[0] != "false")
            {
                    animals = animals.Where(x => x.FriendlyWithDogs == true).ToList();
            }
            if (filteringItem.FriendlyWithCats[0] != "false")
            {
                    animals = animals.Where(x => x.FriendlyWithCats == true).ToList();

            }
            if (filteringItem.FriendlyWithKids[0] != "false")
            {
                    animals = animals.Where(x => x.FriendlyWithDogs == true).ToList();
            }
            if (filteringItem.SpecialNeeds[0] != "false")
            {
                animals = animals.Where(x => x.SpecialNeeds == true).ToList();
            }
            filteredAnimals = animals;

            return Ok(animals);
        }


        [Route("Animal/{id}")]
        public async Task<IActionResult> Animal(int id)
        {
            Animal animal;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(_apiPath + "api/Animal/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    //var json = JObject.Parse(apiResponse);
                    animal = JsonConvert.DeserializeObject<Animal>(apiResponse);
                    Dictionary<string, bool> _getsAlongWith = new Dictionary<string, bool>(){
            { "Dogs", animal.FriendlyWithDogs },
            { "Cats", animal.FriendlyWithCats },
            { "Kids", animal.FriendlyWithKids }
        };


                    var str = new List<string>();
                    foreach (KeyValuePair<string, bool> kv in _getsAlongWith)
                    {
                        if (kv.Value == true)
                        {
                            str.Add(kv.Key);
                        }
                    }
                    animal.GetsAlongWith = String.Join(",", str);

                }
            }
            return View(animal);
        }
    }
}
