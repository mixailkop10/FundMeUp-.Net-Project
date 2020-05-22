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
    class BackerProjectManager : IBackerProjectManager
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
                Project = project,
                Fund = backProj.Fund,
                DoF = DateTime.Now
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
    }
}
