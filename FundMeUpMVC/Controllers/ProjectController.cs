using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FundMeUp.Models;
using FundMeUp.Options;
using FundMeUp.Services;
using FundMeUpMVC.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using static FundMeUpMVC.Models.ModelViews;

namespace FundMeUpMVC.Controllers
{


    [Route("[controller]")]
    public class ProjectController : Controller
    {
        private IProjectManager projManager;
        private IProjectCreatorManager pcManager;
        private IRewardManager rewardManager;
        private readonly ILogger<ProjectController> _logger;
        private readonly IWebHostEnvironment hostingEnvironment;

    public ProjectController(ILogger<ProjectController> logger,IProjectManager _projManager,
                             IRewardManager _rewardManager, IWebHostEnvironment environment, IProjectCreatorManager _projectCreatorManager)
        {
            hostingEnvironment = environment;
            rewardManager = _rewardManager;
            projManager = _projManager;
            pcManager = _projectCreatorManager;
            _logger = logger;
        }

        [HttpGet("CreateProject")]
        public IActionResult CreateProject()
        {
            var viewModel = new ProjectViewModel()
            {
                Categories = new List<string>() { "Technology", "Environment", "Art", "Music", "Gaming","Health","Sports","Food" }
            };

            return View(viewModel);
        }

        [HttpGet("AllProjects")]
        public IActionResult AllProjects()
        {
            return View();
        }

        [HttpGet("AllProjectsCards")]
        public IActionResult AllProjectsCards()
        {
            var viewModel = new ProjectModel();
            viewModel.Projects = projManager.GetAll();
            return View(viewModel);
        }
        [HttpGet("TrendingProjects")]
        public IActionResult TrendingProjects()
        {
            var viewModel = new ProjectModel();
            viewModel.Projects = projManager.GetFamProjects();
            return View(viewModel);
        }

        [HttpGet("RecentProjects")]
        public IActionResult RecentProjects()
        {
            var viewModel = new ProjectModel();
            viewModel.Projects = projManager.GetRecProjects();
            return View(viewModel);
        }

        [HttpGet("ProjectPage/{id}")]
        public IActionResult ProjectPage()
        {
            var viewModel = new ProjectViewModel()
            {
                Categories = new List<string>() { "Technology", "Environment", "Art", "Music", "Gaming", "Health", "Sports", "Food" }
            };

            return View(viewModel);

        }

        [HttpGet("Project/{id}")]
        public IActionResult Project([FromRoute] int id)
        {
            
            RewardsByProject rewards = new RewardsByProject
            {
                ProjectCreator= projManager.FindProjectById(id).ProjectCreator,
                Rewards = rewardManager.GetRewards(id)
            };
            return View(rewards);
        }
  }
}
