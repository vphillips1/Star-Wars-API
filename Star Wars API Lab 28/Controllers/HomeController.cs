using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Star_Wars_API_Lab_28.Models;
using Star_Wars_API_Lab_28.Models.ViewModels;

namespace Star_Wars_API_Lab_28.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly StarWarsClient _starWarsClient;
        public HomeController(ILogger<HomeController> logger, StarWarsClient starWarsClient)
        {
            _logger = logger;
            _starWarsClient = starWarsClient;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {

            
            return View();
        }

        public async Task<IActionResult> People (string id )
        {
            var response = await _starWarsClient.GetPersonID(id);

            var viewModel = new PeopleViewModel();
            viewModel.name = response.name;
            viewModel.height = response.height;
            viewModel.mass = response.mass;
            viewModel.birth_year = response.birth_year;
            viewModel.hair_color = response.hair_color;
            viewModel.species = response.species;
            viewModel.gender = response.gender;
            viewModel.homeworld = response.homeworld;
            viewModel.starships = response.starships;
            viewModel.url = response.url;

            return View(viewModel);
        }

        public async Task<IActionResult> Planet(string id)
        {
            var response = await _starWarsClient.GetPlanetID(id);

            var viewModel = new PlanetViewModel();
            viewModel.name = response.name;
            viewModel.diameter = response.diameter;
            viewModel.climate = response.climate;
            viewModel.terrain = response.terrain;
            viewModel.gravity = response.gravity;
            viewModel.url = response.url;

            return View(viewModel);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
