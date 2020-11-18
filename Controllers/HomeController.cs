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
        private readonly ILogger<HomeController> _logger;
        private readonly string _apiPath;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _apiPath = "https://localhost:44306/";
        }

        public async Task<IActionResult> Index()
        {
            var indexModel = new IndexModel();
            List<Animal> animals = new List<Animal>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(_apiPath + "api/Animals"))
                {
                    
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    animals = JsonConvert.DeserializeObject<List<Animal>>(apiResponse);
                    foreach (var animal in animals)
                    {
                        Dictionary<string, bool> _getsAlongWith = new Dictionary<string, bool>()
                        {
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
            indexModel.Animals = animals;
            List<Shelter> shelterList = new List<Shelter>();
            using (var httpClient = new HttpClient()) 
            {
                using (var response = await httpClient.GetAsync(_apiPath + "api/Shelter")) 
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    shelterList = JsonConvert.DeserializeObject<List<Shelter>>(apiResponse);
                }
            }
            indexModel.Shelters = shelterList;
            return View(indexModel);
        }


        [Microsoft.AspNetCore.Authorization.Authorize]
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
        public async Task<IActionResult> Shelter(int id)
        {
            List<Animal> animalsList = new List<Animal>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(_apiPath + "Shelters/"  + id + "/Animals"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    animalsList = JsonConvert.DeserializeObject<List<Animal>>(apiResponse);
                    foreach (var animal in animalsList)
                    {
                        Dictionary<string, bool> _getsAlongWith = new Dictionary<string, bool>()
                        {
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
                        animal.GetsAlongWith = String.Join(", ", str);
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
            return View(filteredAnimals);
        }
        [Route("/see-all-shelters")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shelter>>> AllShelters()
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

        [Route("/see-all-animals")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Animal>>> SeeAllAnimals()
        {
            List<Animal> animals = new List<Animal>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(_apiPath + "api/Animals"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    animals = JsonConvert.DeserializeObject<List<Animal>>(apiResponse);
                    foreach (var animal in animals)
                    {
                        Dictionary<string, bool> _getsAlongWith = new Dictionary<string, bool>()
                        {
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
            return View(animals);
        }

        [HttpPost]
        [Consumes("application/json")]
        [Route("/my-perfect-pet")]
        public async Task<ActionResult<List<Animal>>> FilterAllAnimals([FromBody] FilteringItem filteringItem)
        {
            List<Animal> animals = new List<Animal>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(_apiPath + "api/Animals"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    animals = JsonConvert.DeserializeObject<List<Animal>>(apiResponse);
                    foreach (var animal in animals)
                    {
                        Dictionary<string, bool> _getsAlongWith = new Dictionary<string, bool>()
                        {
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
            if (filteringItem.Type[0] != "null")
            {
                foreach (var type in filteringItem.Type)
                {
                    animals = animals.Where(x => x.Type == type).ToList();
                }
            }
            if (filteringItem.Breed[0] != "false")
            {
                    animals = animals.Where(x => x.Breed != "Mixed" || x.Breed != "mixed" || x.Breed != "mix" || x.Breed != "Mix" || x.Breed != "corcitura").ToList();
            }
            if (filteringItem.Age[0] != "null")
            {
                var animalsByAge = new List<Animal>();
                var filteredByAge = new List<Animal>();
                foreach (var age in filteringItem.Age)
                {
                    animalsByAge = animals.Where(x => x.Age == age).ToList();

                    foreach (var animal in animalsByAge)
                    {
                        filteredByAge.Add(animal);
                    }
                }
                animals = filteredByAge;

            }
            if (filteringItem.EnergyLevel[0] != "null")
            {
                var animalsByEnergy = new List<Animal>();
                var filteredByEnergy = new List<Animal>();
                foreach (var energy in filteringItem.EnergyLevel)
                {
                    animalsByEnergy = animals.Where(x => x.EnergyLevel == energy).ToList();

                    foreach (var animal in animalsByEnergy)
                    {
                        filteredByEnergy.Add(animal);
                    }
                }
                animals = filteredByEnergy;
            }
            if (filteringItem.Size[0] != "null")
            {
                var animalsBySize = new List<Animal>();
                var filteredBySize = new List<Animal>();
                foreach (var size in filteringItem.Size)
                {
                    animalsBySize = animals.Where(x => x.Size == size).ToList();

                    foreach (var animal in animalsBySize)
                    {
                        filteredBySize.Add(animal);
                    }
                }
                animals = filteredBySize;
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
                using (var response = await httpClient.GetAsync(_apiPath + "api/Animals/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    animal = JsonConvert.DeserializeObject<Animal>(apiResponse);
                    Dictionary<string, bool> _getsAlongWith = new Dictionary<string, bool>()
                    {
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
