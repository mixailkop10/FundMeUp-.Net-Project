using FundMeUp.Models;
using FundMeUp.Options;
using FundMeUp.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FundMeUp.Services
{
    public class BackerProjectManager : IBackerProjectManager
    {
        private FundMeUpDbContext _db;

        public BackerProjectManager(FundMeUpDbContext db)
        {
            _db = db;
        }

        public BackerProject FindFundingById(int id)
        {
            return _db.BackerProjects
                .Include(bp => bp.Project)
                .Include(bp => bp.Backer)
                .Include(bp => bp.Reward)
                .Where(bp => bp.Id == id)
                .FirstOrDefault();
        }

        public BackerProject CreateFunding(BackerProjectOption backProjOption)
        {
            float tempfund = 0;
            float finalfund = 0;
            var reward = _db.Rewards.Find(backProjOption.RewardId);
            var project = _db.Projects.Find(backProjOption.ProjectId);
            
            if (backProjOption.Fund == 0) tempfund = reward.Price;
            else tempfund = backProjOption.Fund + reward.Price;

            float tempTotalSum = tempfund + project.Balance;
            if (tempTotalSum < project.BudgetGoal)
                finalfund = tempfund;
            else
                finalfund = tempfund - (tempTotalSum - project.BudgetGoal);


            BackerProject backerProject = new BackerProject
            {
                BackerId = backProjOption.BackerId,
                Backer = _db.Backers.Find(backProjOption.BackerId),
                RewardId = backProjOption.RewardId,
                Reward = reward,
                ProjectId = backProjOption.ProjectId,
                Project = project,
                Fund = finalfund,
                DoF = DateTime.Now,
                Status = Status.Pending
            };

            _db.BackerProjects.Add(backerProject);
            _db.SaveChanges();
            return backerProject;
        }

        public List<BackerProject> GetProjectFundings(int projectId)
        {
            return _db.BackerProjects
                .Include(bp => bp.Project)
                .Include(bp => bp.Backer)
                .Where(bp => bp.ProjectId == projectId)
                .ToList();
        }

        public IQueryable<BackerProject> GetPendingProjectFundings(int projectId)
        {
            return _db.BackerProjects
                .Include(bp => bp.Project)
                .Include(bp => bp.Backer)
                .Where(bp => bp.ProjectId == projectId && bp.Status == Status.Pending);
        }

        public IQueryable<BackerProject> GetAcceptedProjectFundings(int projectId)
        {
            return _db.BackerProjects
                .Include(bp => bp.Project)
                .Include(bp => bp.Backer)
                .Where(bp => bp.ProjectId == projectId && bp.Status == Status.Accepted)
                .OrderByDescending(bp => bp.DoF);
        }

        public List<BackerProject> GetBackerFundings(int backerId)
        {
            return _db.BackerProjects
                .Include(bp => bp.Project)
                .Include(bp => bp.Backer)
                .Include(bp => bp.Reward)
                .Where(bp => bp.BackerId == backerId)
                .ToList();
        }

        public bool CancelFundingByBacker(int? backProjId)
        {
            BackerProject backProj = _db.BackerProjects.Find(backProjId);

            if (backProjId != null)
            {
                if (backProj.Status == Status.Pending)
                {
                    backProj.Status = Status.Canceled;
                    _db.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public bool StatusUpdate(int backProjId, bool accept = false)
        {
            if (accept)
            {
                BackerProject backerProject = _db.BackerProjects
                    .Include(bp => bp.Project)
                    .Include(bp => bp.Backer)
                    .Where(bp => bp.Id == backProjId)
                    .FirstOrDefault();

                if (backerProject != null)
                {
                    backerProject.Status = Status.Accepted;
                    _db.Entry(backerProject).State = EntityState.Modified;
                    _db.SaveChanges();
                    return true;
                }
            }
            return false;
        }
    }
}
