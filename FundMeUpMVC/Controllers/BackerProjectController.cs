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
using X.PagedList;

namespace FundMeUpMVC.Controllers
{
    public class BackerProjectController : Controller
    {
        private IBackerProjectManager bpMng;
        private IRewardManager rMng;
        private IProjectManager pMng;

        public BackerProjectController(IBackerProjectManager bpMng, IRewardManager rMng, IProjectManager pMng)
        {
            this.bpMng = bpMng;
            this.rMng = rMng;
            this.pMng = pMng;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("BackerProject/RewardPackageFund/{rewardid}/{backerid}")]
        public IActionResult RewardPackageFund([FromRoute] int rewardid, [FromRoute] int backerid)
        {
            var reward = rMng.FindRewardById(rewardid);
            var project = pMng.FindProjectById(reward.ProjectId);
            float percentage = project.Balance * 100 / project.BudgetGoal;

            FundingViewModel viewmodel = new FundingViewModel()
            {
                Reward = reward,
                ProjectProgressBar = percentage,
                //ProjectProgressBar = Convert.ToInt32((float)Math.Round(percentage, 0))
            };

            if (reward != null) 
            {
                viewmodel.BackerProjectOption.ProjectId = viewmodel.Reward.ProjectId;  //exei ylopoihthei constructor sto FundingViewModel pou dhmiourgei to Backerprojectoption
            }
            viewmodel.BackerProjectOption.BackerId = 1;
            return View(viewmodel);
        }

        // UI for Backer with project fundings
        [HttpGet("BackerProject/ProjectFundings/{id}")]
        public IActionResult ProjectFundings(int? page, [FromRoute] int id)
        {
            int pageSize = 2;
            int pageNumber = (page ?? 1);

            int projectId = 0;
            var project = pMng.FindProjectById(id);

            if (project != null)
            {
                projectId = project.Id;
            }

            ProjectFundingsViewModel pfviewmodel = new ProjectFundingsViewModel()
            {
                PendingBackerProjects = bpMng.GetPendingProjectFundings(projectId).ToList(), //Project - Startup
                AcceptedBackerProjects = bpMng.GetAcceptedProjectFundings(projectId).ToPagedList(pageNumber, pageSize),
                Project = project,
                ProjectProgressBar = project.Balance * 100 / project.BudgetGoal,
                FileName = project.FileName
            };
            return View(pfviewmodel);
        }

        //UI for backer - Search for Accepted Fundings
        [HttpPost("BackerProject/ProjectFundings/{id}")]
        public IActionResult ProjectFundings([FromBody] ProjectFundingsViewModel projfunds, int? page, [FromRoute] int id)
        {
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            int projectId = 0;
            var project = pMng.FindProjectById(id);

            if (project != null)
            {
                projectId = project.Id;
            }

            ProjectFundingsViewModel pfviewmodel = new ProjectFundingsViewModel()
            {
                PendingBackerProjects = bpMng.GetPendingProjectFundings(projectId).ToList(),
                AcceptedBackerProjects = bpMng.GetAcceptedProjectFundings(projectId)
                                .Where(f => f.DoF >= projfunds.SearchStartDate && f.DoF <= projfunds.SearchEndDate).ToPagedList(pageNumber, pageSize),
                Project = project,
                ProjectProgressBar = project.Balance * 100 / project.BudgetGoal,
                FileName = project.FileName,
                SearchStartDate = projfunds.SearchStartDate,
                SearchEndDate = projfunds.SearchEndDate
            };
            return PartialView("ProjectFundings", pfviewmodel);
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
            var projectid = bpMng.FindFundingById(id).ProjectId;
            if (StatusAccepted) 
            {
                bool update = pMng.UpdateBalance(projectid);
            }
            return Json(Url.Action("ProjectFundings", "BackerProject", new { id = projectid }));
        }
    }
}