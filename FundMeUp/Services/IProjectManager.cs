using FundMeUp.Models;
using FundMeUp.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundMeUp.Services
{
    public interface IProjectManager
    {
        Project CreateProject(ProjectOption projOption);
        Project FindProjectById(int id);
        List<Project> GetAll();
       // List<Project> FindProjectByNameAndCategory(string name, Category category);
        bool DeleteProjectById(int id);
        bool SoftDeleteProjectById(int id);
    }
}