using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FundMeUp.Services;
using FundMeUpMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FundMeUpMVC.Controllers
{
    public class ProjectCreatorController : Controller
    {
        private readonly ILogger<ProjectController> logger;
        private IProjectCreatorManager projectCreatorManager;

        public ProjectCreatorController(ILogger<ProjectController> logger, IProjectCreatorManager projectCreatorManager)
        {
            this.logger = logger;
            this.projectCreatorManager = projectCreatorManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult AllProjectCreators()
        {
            var viewModel = new ProjectCreatorModel();
            viewModel.ProjectCreators = projectCreatorManager.GetAllProjectCreators();
            return View(viewModel);
        }
    }
}
