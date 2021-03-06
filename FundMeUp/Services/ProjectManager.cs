﻿using FundMeUp.Models;
using FundMeUp.Options;
using FundMeUp.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace FundMeUp.Services
{
    public class ProjectManager : IProjectManager
    {
        private FundMeUpDbContext db;

        public ProjectManager(FundMeUpDbContext db)
        {
            this.db = db;
        }

        //CRUD
        // create read update delete
        public Project CreateProject(ProjectOption projOption)
        {
            if (projOption.Name == null) return null;
            if (projOption.Description == null) return null;
            if (projOption.DateOfCreation == null) return null;
            if (projOption.StatusUpdate == null) return null;

            //var projectcreator = db.ProjectCreators.Find(projOption.ProjectCreatorId);
            //if (projectcreator == null) return null;

            Project project = new Project
            {
                Name = projOption.Name,
                Description = projOption.Description,
                BudgetGoal = projOption.BudgetGoal,
                DateOfCreation = projOption.DateOfCreation,
                FileName = projOption.ImagePath,
                Category = projOption.Category,
                StatusUpdate=projOption.StatusUpdate,
                Available = true,
                ProjectCreatorId= projOption.ProjectCreatorId
                
              

            };

            db.Projects.Add(project);
            db.SaveChanges();

            return project;
        }

        //Search Results
        public Project FindProjectById(int projectId)
        {
            return db.Projects.Include(p => p.ProjectCreator).Where(p => p.Id == projectId).FirstOrDefault();
        }

        public List<Project> FindProjectByName(ProjectOption projectOption)
        {
            return db.Projects
                .Where(p => p.Name == projectOption.Name)
                .ToList();
        }

        public List<Project> FindProjectByCategory(ProjectOption projectOption)
        {
            return db.Projects
                .Where(p => p.Category == projectOption.Category)
                .ToList();
        }

        public List<Project> FindProjectByNameAndCategory(ProjectOption projectOption) //string name , Category category
        {
            //return db.Projects
            //    .Where(p =>
            //      (String.IsNullOrEmpty(name) || p.Name.Contains(name)) &&
            //      (category.Equals(Category.None) || p.Category.Equals(category))
            //     ).ToList();
            return db.Projects
                .Where(p => p.Name == projectOption.Name)
                .Where(p => p.Category == projectOption.Category)
                .ToList();
        }

        public List< Project> FindProjectsByProjectCreator(int pcid)
        {
            return db.Projects
                .Include(p => p.ProjectCreator)
                .Where(p => p.ProjectCreator.Id == pcid)
               // .FirstOrDefault();
               .ToList();
        }

        public List<Project> GetAll()
        {
            return db.Projects.ToList();
        }

        public List<Project> GetRecentProjects()
        {
            //Projects for the week
            return db.Projects
                .Where(p=>p.DateOfCreation.AddDays(-(int)p.DateOfCreation.DayOfWeek) ==  DateTime.Now.AddDays(-(int)DateTime.Now.DayOfWeek))
                .ToList();
        }
        public IEnumerable<Project> GetRecProjects()
        {
            return db.Projects
                .OrderByDescending(x => x.DateOfCreation)
                .Take(5)
                //.ThenByDescending(x => x.DateOfCreation.Date)
                //.ThenByDescending(x => x.DateOfCreation.Year)
                .ToList();
        }

        public List<Project> GetFamousProjects() 
        {
            //projects approaching target - BudgetGoal 
            var filterBalances =  db.Projects.OrderBy(p => p.BudgetGoal - p.Balance).Take(10).Select(p=>p.Id).ToList();

            //projects with most fundings
            var mostFundings = from project in db.Projects
                                from backerproject in db.BackerProjects
                                    .Where(bp => bp.ProjectId == project.Id)
                                    .GroupBy(bp => bp.ProjectId)
                                    .Select(bp => new { Total = bp.Count() })
                                    .OrderByDescending(bp => bp.Total).Take(10)
                               select new
                               {
                                    project.Id,
                               };

            var filterFundings = mostFundings.Select(x => x.Id).ToList();

            var projects = db.Projects.Where(p => filterBalances.Contains(p.Id) || filterFundings.Contains(p.Id)).ToList();

            return projects;
        }

        public IEnumerable<Project> GetFamProjects()
        {
            var filterBalance = db.Projects
                .OrderByDescending(p => p.BudgetGoal - p.Balance)
                .Take(6)
                .ToList();
            return db.Projects
                .Where(x => x.Funded == true)
                .OrderBy(x => x.BudgetGoal - x.Balance)
                .Take(6)
                .ToList();
        }

        public bool DeleteProjectById(int id)
        {
            Project project = db.Projects.Find(id);
            if (project != null)
            {
                db.Projects.Remove(project);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool SoftDeleteProjectById(int id)
        {
            Project project = db.Projects.Find(id);
            if (project != null)
            {
                project.Available = false;
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public Project Update(ProjectOption projOption, int projectId)
        {

            Project project = db.Projects.Find(projectId);

            if (projOption.Name != null)
                project.Name = projOption.Name;
            if (projOption.Description != null)
                project.Description = projOption.Description;
            if (projOption.StatusUpdate != null)
                project.StatusUpdate = projOption.StatusUpdate;
            if (projOption.BudgetGoal != 0.0)
                project.BudgetGoal = projOption.BudgetGoal;
            if (projOption.Category != null)
                project.Category = projOption.Category;

            db.SaveChanges();
            return project;
        }

        public bool UpdateBalance(int projectId)
        {
            Project project = db.Projects.Find(projectId);
            float sumbackerprojects = db.BackerProjects
                .Where(bp => bp.ProjectId == projectId)
                .Where(bp => bp.Status == Status.Accepted)
                .Sum(bp => bp.Fund);

            if (sumbackerprojects > 0)
            { 
                project.Balance = sumbackerprojects;
                db.Entry(project).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}