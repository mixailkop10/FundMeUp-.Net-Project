using FundMeUp.Models;
using FundMeUp.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundMeUp.Services
{
    interface IProjectManager
    {
        public Project CreateProject(ProjectOption projOption);
        public Project FindProjectById(int id);
        public List<Project> GetAll();
        public List<Project> FindProjectByNameAndCategory(string name, Category category);
        public bool DeleteProjectById(int id);
        public bool SoftDeleteProjectById(int id);
    }
}