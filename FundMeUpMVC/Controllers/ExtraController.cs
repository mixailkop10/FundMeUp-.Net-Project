using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FundMeUp.Options;
using FundMeUp.Services;
using FundMeUpMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FundMeUpMVC.Controllers
{
    [Route("[controller]")]
    public class ExtraController : Controller
    {
        private IProjectManager projManager;
        private readonly ILogger<ExtraController> _logger;

        public ExtraController(ILogger<ExtraController> logger, IProjectManager _projManager)
        {
            projManager = _projManager;
            _logger = logger;
        }


        [HttpGet("Index")]
        public IActionResult Index()
        {
            return View("Index", "_UserLayout");
        }

        [HttpGet("Categories")]
        public IActionResult Categories()
        {
            return View("Categories", "_UserLayout");
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

            return ViewBag("Category","_UserLayout",catOpt);
        }

        [HttpGet("CreateProject")]
        public IActionResult CreateProject()
        {
            var viewModel = new ProjectViewModel()
            {
                Categories = new List<string>() { "Technology", "Environment", "Art", "Music", "Gaming", "Health", "Sports", "Food" }
            };

            return ViewBag("CreateProject", "_UserLayout",viewModel);
        }
    }
}
