using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FundMeUp.Services;
using FundMeUpMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using X.PagedList;

namespace FundMeUpMVC.Controllers
{
    [Route("[controller]")]
    public class ProjectCreatorController : Controller
    {
        private readonly ILogger<ProjectController> logger;
        private IProjectCreatorManager projectCreatorManager;
        private IProjectManager projectMng;
        private IBackerProjectManager  backerprojectMng;

        public ProjectCreatorController(ILogger<ProjectController> logger, IProjectCreatorManager projectCreatorManager,
            IProjectManager projectMng, IBackerProjectManager backerprojectMng)
        {
            this.logger = logger;
            this.projectCreatorManager = projectCreatorManager;
            this.projectMng = projectMng;
            this.backerprojectMng = backerprojectMng;
        }
       
        public IActionResult AllProjectCreators()
        {
            var viewModel = new ProjectCreatorModel();
            viewModel.ProjectCreators = projectCreatorManager.GetAllProjectCreators();
            return View(viewModel);
        }
    }
}
