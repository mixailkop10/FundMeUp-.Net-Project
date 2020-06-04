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
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateBacker()
        {
            var viewModel = new BackerModel();
            return View(viewModel);
        }
        public IActionResult AllBackers()
        {
            var viewModel = new BackerModel();
            viewModel.Backers = backerManager.GetBackers();
            return View(viewModel);
        }

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
