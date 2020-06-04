using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FundMeUp.Models;
using FundMeUp.Services;
using FundMeUpMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FundMeUpMVC.Controllers
{
    public class BackerProjectController : Controller
    {
        private readonly ILogger<ProjectController> logger;
        private IBackerProjectManager bpMng;

        public BackerProjectController(ILogger<ProjectController> logger, IBackerProjectManager bpMng)
        {
            this.logger = logger;
            this.bpMng = bpMng;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult StatusUpdate(int id)
        {
            BackerProject backerproject = bpMng.FindFundingById(id);

            FundingDetails funding = new FundingDetails()
            {
                Id = backerproject.Id,
                ProjectName = backerproject.Project.Name,
                BudgetGoal = backerproject.Project.BudgetGoal,
                Balance = backerproject.Project.Balance,
                BackerFirstName = backerproject.Backer.FirstName,
                BackerLastName = backerproject.Backer.LastName,
                Fund = backerproject.Fund,
                RewardName = backerproject.Reward.Name,
                DoF = backerproject.DoF
            };

            return View(funding);
        }

        public JsonResult PostStatus(int id, bool accept)
        {
            var StatusAccepted = bpMng.StatusUpdate(id, accept);

            return Json(Url.Action("Dashboard", "ProjectCreator"));
        }
    }
}