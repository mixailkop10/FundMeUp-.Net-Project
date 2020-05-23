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
                .Where(bp => bp.Id == id)
                .FirstOrDefault();
        }

        public BackerProject CreateFunding(BackerProjectOption backProj)
        {
            Project project = _db.Projects.Find(backProj.ProjectId);

            BackerProject backerProject = new BackerProject
            {
                Backer = _db.Backers.Find(backProj.BackerId),
                Reward = _db.Rewards.Find(backProj.RewardId),
                Project = project,
                Fund = backProj.Fund,
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

        public List<BackerProject> GetBackerFundings(int backerId)
        {
            return _db.BackerProjects
                .Include(bp => bp.Project)
                .Include(bp => bp.Backer)
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
