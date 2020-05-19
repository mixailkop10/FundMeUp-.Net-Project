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
    public class ProjectCreatorManager : IProjectCreatorManager
    {
        private FundMeUpDbContext _db;

        public ProjectCreatorManager(FundMeUpDbContext db)
        {
            _db = db;
        }



        //CRUD

        public ProjectCreator CreateProjectCreator(ProjectCreatorOption PCrOption)
        {
            ProjectCreator projectCreator = new ProjectCreator
            {
                FirstName = PCrOption.FirstName,
                LastName = PCrOption.LastName,
                Password = PCrOption.Password,
                Address = PCrOption.Address,
                Email = PCrOption.Email,
                Active = true,
                TrustPoints = 100

            };

            _db.ProjectCreators.Add(projectCreator);
            _db.SaveChanges();
            return projectCreator;
        }

        public ProjectCreator FindProjectCreatorById(int projectCreatorId)
        {

            return _db.ProjectCreators.Find(projectCreatorId);
        }

        public List<ProjectCreator> FindProjectCreatorByName(ProjectCreatorOption PCrOption)
        {
            return _db.ProjectCreators
                .Where(cust => cust.LastName == PCrOption.LastName)
                .Where(cust => cust.FirstName == PCrOption.FirstName)
                .ToList();
        }


        public ProjectCreator Update(ProjectCreatorOption PCrOption, int projectCreatorId)
        {

            ProjectCreator projectCreator = _db.ProjectCreators.Find(projectCreatorId);

            if (PCrOption.FirstName != null)
                projectCreator.FirstName = PCrOption.FirstName;
            if (PCrOption.LastName != null)
                projectCreator.LastName = PCrOption.LastName;
            if (PCrOption.Password != null)
                projectCreator.Password = PCrOption.Password;
            if (PCrOption.Email != null)
                projectCreator.Email = PCrOption.Email;
            if (PCrOption.Address != null)
                projectCreator.Address = PCrOption.Address;
           

            _db.SaveChanges();
            return projectCreator;
        }

        public bool DeleteProjectCreatorById(int id)
        {
            ProjectCreator projectCreator= _db.ProjectCreators.Find(id);
            if (projectCreator != null)
            {
                _db.ProjectCreators.Remove(projectCreator);
                _db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool SoftDeleteProjectCreatorById(int id)
        {
            ProjectCreator projectCreator = _db.ProjectCreators.Find(id);
            if (projectCreator != null)
            {
                projectCreator.Active = false;
                _db.SaveChanges();
                return true;
            }
            return false;
        }

        public List<ProjectCreator> GetAllProjectCreators()
        {
            return _db.ProjectCreators.ToList();
        }

    }


}

