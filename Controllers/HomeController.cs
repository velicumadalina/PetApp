using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private readonly ILogger<HomeController> _logger;
        
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public string GetAccessToken()
        {
            var client = new RestClient("https://api.petfinder.com/v2/oauth2/token");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("grant_type", "client_credentials");
            request.AddParameter("client_id", "F30u0MQ5a5l02c1twWg8WobIz3c4mHwGrzrgVJY7qcx2XijKO9");
            request.AddParameter("client_secret", "vYqdi2iayMYBhUt84R6uod5pnYkN52ElGxKWK2cP");
            IRestResponse response = client.Execute(request);
            var json = JObject.Parse(response.Content);
            string token = json.GetValue("access_token").ToString();
            return token;
        }
        public async Task<IActionResult> Index()
        {
            string token = GetAccessToken();
            List<Shelter> shelterList = new List<Shelter>();
            List<String> photosList = new List<String>();
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization
                         = new AuthenticationHeaderValue("Bearer", token);
                using (var response = await httpClient.GetAsync("https://api.petfinder.com/v2/organizations"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var json = JObject.Parse(apiResponse);
                    shelterList = JsonConvert.DeserializeObject<List<Shelter>>(JsonConvert.SerializeObject(json.GetValue("organizations")));
                    foreach (var shelter in shelterList) 
                    {
                        var photoLinks = JsonConvert.SerializeObject(shelter.Photos);
                        var photoArray = JArray.Parse(photoLinks);
                        foreach (var photo in photoArray) 
                        {
                            var smallerList = JsonConvert.SerializeObject(photo);
                            shelter.Photo = JObject.Parse(smallerList).GetValue("medium").ToString();
                        }

                    }
                }
            }
            return View(shelterList);
        }



        public IActionResult Privacy()
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
            string token = GetAccessToken();
            List<Animal> animalsList = new List<Animal>();
            List<String> photosList = new List<String>();
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization
                         = new AuthenticationHeaderValue("Bearer", token);
                using (var response = await httpClient.GetAsync("https://api.petfinder.com/v2/animals?organization=" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var json = JObject.Parse(apiResponse);
                    animalsList = JsonConvert.DeserializeObject<List<Animal>>(JsonConvert.SerializeObject(json.GetValue("animals")));
                    foreach (var animal in animalsList)
                    {
                        var photoLinks = JsonConvert.SerializeObject(animal.Photos);
                        var photoArray = JArray.Parse(photoLinks);
                        foreach (var photo in photoArray)
                        {
                            var smallerList = JsonConvert.SerializeObject(photo);
                            animal.Photo = JObject.Parse(smallerList).GetValue("medium").ToString();
                        }

                    }
                }
            }
            return View(animalsList);
        }
    }
}
