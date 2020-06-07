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

        [HttpGet("AllProjectCreators")]
        public IActionResult AllProjectCreators()
        {
            var viewModel = new ProjectCreatorModel();
            viewModel.ProjectCreators = projectCreatorManager.GetAllProjectCreators();
            return View(viewModel);
        }
        [HttpGet("ProjectCreatorPage/{id}")]
        public IActionResult ProjectCreatorPage([FromRoute] int id)
        {
            var viewModel = projectCreatorManager.FindProjectCreatorById(id);
            return View(viewModel);
        }

        [HttpGet("Dashboard/{id}")]
        public IActionResult Dashboard( int? page, [FromRoute] int id)
        {
            int pageSize = 2;
            int pageNumber = (page ?? 1);

            int projectId=0;
            var project = projectMng.FindProjectByProjectCreator(id);
            if (project != null)
            {
                projectId = project.Id;
            }

            PCDashboardViewModel pcdash = new PCDashboardViewModel()
            {
                PendingBackerProjects = backerprojectMng.GetPendingProjectFundings(projectId).ToList(), //Project - Startup
                AcceptedBackerProjects = backerprojectMng.GetAcceptedProjectFundings(projectId).ToPagedList(pageNumber, pageSize),
                ProjectId = projectId
            };
            return View(pcdash);
        }

        //Search for Accepted Fundings
        [HttpPost("Dashboard /{pid}")]
        public IActionResult Dashboard([FromBody] PCDashboardViewModel pcdashboard, int? page,[FromRoute] int pid)
        {
            int pageSize = 2;
            int pageNumber = (page ?? 1);
            int projectId = projectMng.FindProjectByProjectCreator(pid).Id;

            PCDashboardViewModel pcdash = new PCDashboardViewModel()
            {
                PendingBackerProjects = backerprojectMng.GetPendingProjectFundings(projectId).ToList(),
                AcceptedBackerProjects = backerprojectMng.GetAcceptedProjectFundings(projectId)
                                .Where(f => f.DoF >= pcdashboard.SearchStartDate && f.DoF <= pcdashboard.SearchEndDate).ToPagedList(pageNumber, pageSize),
                ProjectId = projectId,
                SearchStartDate = pcdashboard.SearchStartDate,
                SearchEndDate = pcdashboard.SearchEndDate
            };
            return PartialView("Dashboard", pcdash);
        }
    }
}
