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
    public class BackerProjectController : Controller
    {
        private readonly ILogger<ProjectController> logger;
        private IBackerProjectManager bpMng;
        private IRewardManager rMng;

        public BackerProjectController(ILogger<ProjectController> logger, IBackerProjectManager bpMng, IRewardManager rMng)
        {
            this.logger = logger;
            this.bpMng = bpMng;
            this.rMng = rMng;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("BackerProject/RewardPackageFund/{rewardid}/{backerid}")]
        public IActionResult RewardPackageFund([FromRoute] int rewardid, [FromRoute] int backerid)
        {
            var reward = rMng.FindRewardById(rewardid);

            FundingViewModel viewmodel = new FundingViewModel()
            {
                Reward = reward
            };

            if (reward != null) 
            {
                viewmodel.BackerProjectOption.ProjectId = viewmodel.Reward.ProjectId;  //exei ylopoihthei constructor sto FundingViewModel pou dhmiourgei to Backerprojectoption
            }
            viewmodel.BackerProjectOption.BackerId = 1;
            return View(viewmodel);
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