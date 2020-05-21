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
        Project FindProjectById(int projectId);
        List<Project> FindProjectByName(ProjectOption projectOption);
        List<Project> FindProjectByCategory(ProjectOption projectOption);
        List<Project> FindProjectByNameAndCategory(ProjectOption projectOption);
        bool DeleteProjectById(int id);
        bool SoftDeleteProjectById(int id);
        List<Project> GetAll();
    }
}