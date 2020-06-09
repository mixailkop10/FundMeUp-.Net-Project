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
        private IProjectManager projManager;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IProjectManager _projManager)
        {
            projManager = _projManager;
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

        [HttpGet("Privacy")]
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
            ProjectOption projOpt = new ProjectOption
            {
                Category = category
            };
            CategoryOption catOpt = new CategoryOption
            {
                Category = category,
                Projects = projManager.FindProjectByCategory(projOpt)

            };

            return View(catOpt);
        }

        [HttpGet("SignUp")]
        public IActionResult SignUp()
        {
            var viewModel = new BackerModel();
            return View(viewModel);
        }

        [HttpGet("Login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet("LoginBacker")]
        public IActionResult LoginBacker()
        {
            return View();
        }
        [HttpGet("LoginProjectCreator")]
        public IActionResult LoginProjectCreator()
        {
            return View();
        }
        [HttpGet("AllofLists")]
        public IActionResult AllofLists()
        {
            return View();
        }
        [HttpGet("AdminPage")]
        public IActionResult AdminPage()
        {
            return View();
        }
        [HttpGet("Error")]

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
