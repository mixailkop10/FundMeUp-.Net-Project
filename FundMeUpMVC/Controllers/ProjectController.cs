using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FundMeUp.Models;
using FundMeUp.Options;
using FundMeUp.Services;
using FundMeUpMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FundMeUpMVC.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ProjectController : Controller
    {
        private IProjectManager projManager;
        private readonly ILogger<ProjectController> _logger;

        public ProjectController(ILogger<ProjectController> logger,IProjectManager _projManager)
        {
            projManager = _projManager;
            _logger = logger;
        }

        public IActionResult CreateProject()
        {
            var viewModel = new CreateProjectViewModel()
            {
                Categories = new List<string>() { "Techology", "Enviroment", "Art", "Music", "Gaming" }
            };

            return View(viewModel);
        }

        [HttpPost("CreateProject")]
        public Project CreateProject([FromBody] ProjectOption projOpt)
        {
            return projManager.CreateProject(projOpt);
        }

    }
}
