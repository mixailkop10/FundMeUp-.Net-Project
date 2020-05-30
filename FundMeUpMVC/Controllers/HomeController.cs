using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FundMeUpMVC.Models;
using FundMeUp.Models;
using FundMeUp.Options;
using FundMeUp.Services;

namespace FundMeUpMVC.Controllers
{
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

      
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;

        }
        [HttpGet("Index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("")]
        public IActionResult Home()
        {
            return View("Index");
        }

        

        [HttpGet("Privacy22")]
        public IActionResult Privacy()
        {
            return View();
        }
       
        [HttpGet("Categories")]
        public IActionResult Categories()
        {
            return View();
        }

        [HttpGet("Category/{category}")]
        public IActionResult Category([FromRoute] string category)
        {
            CategoryOption catOpt = new CategoryOption
            {
                Category = category
            };
            return View(catOpt);
        }

        

        [HttpGet("Error")]

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
