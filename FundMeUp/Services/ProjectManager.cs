using FundMeUp.Models;
using FundMeUp.Options;
using FundMeUp.Repository;
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
            Project project = new Project
            {
                Name = projOption.Name,
                Description = projOption.Description,
                BudgetGoal = projOption.BudgetGoal,
                DoΑ = projOption.DoA,
                Category = projOption.Category,
                Available = true

            };

            db.Projects.Add(project);
            db.SaveChanges();

            return project;
        }

        //Search Results
        public Project FindProjectById(int projectId)
        {
            return db.Projects.Find(projectId);
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

        public List<Project> GetAll()
        {
            return db.Projects.ToList();
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
    }
}