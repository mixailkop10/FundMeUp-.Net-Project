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
    public class BackerController : Controller
    {
        private readonly ILogger<ProjectController> logger;
        private IBackerManager backerManager;
        private IBackerProjectManager backerprojectMng;

        public BackerController(ILogger<ProjectController> logger, IBackerManager backerManager, IBackerProjectManager backerprojectMng)
        {
            this.logger = logger;
            this.backerManager = backerManager;
            this.backerprojectMng = backerprojectMng;
        }

        [HttpGet("AllBackers")]
        public IActionResult AllBackers()
        {
            var viewModel = new BackerModel();
            viewModel.Backers = backerManager.GetBackers();
            return View(viewModel);
        }

        [HttpGet("BackerPage/{id}")]
        public IActionResult BackerPage()
        {
            return View();
        }
        [HttpGet("Dashboard")]
        public IActionResult Dashboard(int? page)
        {
            int pageSize = 2;
            int pageNumber = (page ?? 1);

            BDashboardViewModel bdash = new BDashboardViewModel()
            {
                BackerProjects = backerprojectMng.GetBackerFundings(1).ToPagedList(pageNumber, pageSize)
            };
            return View(bdash);
        }
    }
}
