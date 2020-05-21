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
  public class HomeController : Controller
  {
        private readonly ILogger<HomeController> _logger;
        private IProjectManager projManager;

        public HomeController(ILogger<HomeController> logger, IProjectManager _projManager)
        {
            _logger = logger;
            projManager = _projManager;
        }

        public IActionResult Index()
    {
      return View();
    }

    public IActionResult Privacy()
    {
      return View();
    }

    [HttpPost]
    public Project CreateProject ([FromBody] ProjectOption projOpt)
    {
            return projManager.CreateProject(projOpt);
    }

    public IActionResult CreateProject()
    {
        var viewModel = new CreateProjectViewModel()
        {
            Categories = new List<string>() { "Techology", "Enviroment", "Art", "Music", "Gaming" }
        };

        return View(viewModel);
    }
    

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
