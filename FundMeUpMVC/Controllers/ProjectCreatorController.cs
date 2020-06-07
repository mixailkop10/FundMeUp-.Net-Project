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

        //[HttpGet("Dashboard/{pcid}/{pid}")]
        //public IActionResult Dashboard( int? page, [FromRoute] int pcid, [FromRoute] int pid)
        //{
        //    int pageSize = 2;
        //    int pageNumber = (page ?? 1);

        //    int projectId=0;
        //    var project = projectMng.FindProjectById(pid);
        //    if (project != null)
        //    {
        //        projectId = project.Id;
        //    }

        //    PCDashboardViewModel pcdash = new PCDashboardViewModel()
        //    {
        //        PendingBackerProjects = backerprojectMng.GetPendingProjectFundings(projectId).ToList(), //Project - Startup
        //        AcceptedBackerProjects = backerprojectMng.GetAcceptedProjectFundings(projectId).ToPagedList(pageNumber, pageSize),
        //        ProjectId = projectId,
        //        ProjectCreatorId = pcid
        //    };
        //    return View(pcdash);
        //}

        ////Search for Accepted Fundings
        //[HttpPost("Dashboard /{pcid}/{pid}")]
        //public IActionResult Dashboard([FromBody] PCDashboardViewModel pcdashboard, int? page,[FromRoute] int pcid,[FromRoute] int pid)
        //{
        //    int pageSize = 2;
        //    int pageNumber = (page ?? 1);
        //    int projectId = projectMng.FindProjectById(pid).Id;
        //  //  int projectcreatorId = pcid;

        //    PCDashboardViewModel pcdash = new PCDashboardViewModel()
        //    {
        //        PendingBackerProjects = backerprojectMng.GetPendingProjectFundings(projectId).ToList(),
        //        AcceptedBackerProjects = backerprojectMng.GetAcceptedProjectFundings(projectId)
        //                        .Where(f => f.DoF >= pcdashboard.SearchStartDate && f.DoF <= pcdashboard.SearchEndDate).ToPagedList(pageNumber, pageSize),
        //        ProjectId = projectId,
        //        SearchStartDate = pcdashboard.SearchStartDate,
        //        SearchEndDate = pcdashboard.SearchEndDate,
        //        ProjectCreatorId=pcid

        //    };
        //    return PartialView("Dashboard", pcdash);
        //}

        [HttpGet("IndexDashboard/{id}")]
        public IActionResult IndexDashboard([FromRoute] int id)
        {

            PCDashboardViewModel indexDash = new PCDashboardViewModel()
            {
                Projects = projectMng.FindProjectsByProjectCreator(id),
                ProjectCreator = projectCreatorManager.FindProjectCreatorById(id)

            };
            return View(indexDash);
        }
    }
}
