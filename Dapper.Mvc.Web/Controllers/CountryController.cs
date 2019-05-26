using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Dapper.Mvc.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;

namespace Dapper.Mvc.Web.Controllers
{
    public class CountryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CountryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;

        }

        public async Task<IActionResult> Index()
        {
            //var client = new RestClient("https://restcountries.eu/rest/v2/name/india");
            //var request = new RestRequest();
            //IRestResponse response = client.Execute(request, Method.GET);
            //Console.WriteLine(response.Content);
            //return View();

            var client = _httpClientFactory.CreateClient();
            var response = await client.GetStringAsync("http://www.boredapi.com/api/activity/");

            var result = JsonConvert.DeserializeObject< Board>(response);
            

         //   Console.WriteLine(result);
            return View(result);

        }

        public async Task<IActionResult> List()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetStringAsync("https://restcountries.eu/rest/v2");

            var result = JsonConvert.DeserializeObject<List<Country>>(response);


            //   Console.WriteLine(result);
            return View(result);

        }
    }
}