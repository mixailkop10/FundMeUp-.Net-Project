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
        private FundMeUpDbContext _db;

        public ProjectManager(FundMeUpDbContext db)
        {
            _db = db;
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

            _db.Projects.Add(project);
            _db.SaveChanges();

            return project;
        }

        public Project FindProjectById(int id)
        {
            return _db.Projects.Find(id);
        }

        //Search Results
        //public List<Project> FindProjectByNameAndCategory(string name, Category category)
        //{
        //    return _db.Projects
        //        .Where(p =>
        //          (String.IsNullOrEmpty(name) || p.Name.Contains(name)) &&
        //          (category.Equals(Category.None) || p.Category.Equals(category))
        //         ).ToList();

        //}

        public List<Project> GetAll()
        {
            return _db.Projects.ToList();
        }

        public bool DeleteProjectById(int id)
        {
            Project project = _db.Projects.Find(id);
            if (project != null)
            {
                _db.Projects.Remove(project);
                _db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool SoftDeleteProjectById(int id)
        {
            Project project = _db.Projects.Find(id);
            if (project != null)
            {
                project.Available = false;
                _db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}