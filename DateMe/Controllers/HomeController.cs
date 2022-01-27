using DateMe.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DateMe.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MovieDbContext dbContext { get; set; }

        public HomeController(ILogger<HomeController> logger, MovieDbContext moviedb)
        {
            _logger = logger;
            dbContext = moviedb;
        }

        [HttpGet]
        public IActionResult MovieForm()
        {
         
            return View();
        }

        [HttpPost]
        public IActionResult MovieForm(ApplicationResponse ar)
        {
            //This is where the all for information is saved to the DB after cliking the submit button from the Movie Form. If some labels (i.e. Title, year, etc.) are not put,
            //It will stop at line 37 with an error and show it on the page because the input must not be NULL. 
            dbContext.Add(ar);
            dbContext.SaveChanges();
            return View("Confirmation", ar);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MyPodCasts()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
