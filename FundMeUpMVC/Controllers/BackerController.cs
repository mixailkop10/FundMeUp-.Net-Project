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
    public class BackerController : Controller
    {
        private readonly ILogger<ProjectController> logger;
        private IBackerManager backerManager;

        public BackerController(ILogger<ProjectController> logger, IBackerManager backerManager)
        {
            this.logger = logger;
            this.backerManager = backerManager;
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
    }
}
