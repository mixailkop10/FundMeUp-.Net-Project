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
        List < Project> FindProjectsByProjectCreator(int pid);
        bool DeleteProjectById(int id);
        bool SoftDeleteProjectById(int id);
        List<Project> GetAll();
        Project Update(ProjectOption projOption, int projectId);
        List<Project> GetRecentProjects();
        List<Project> GetFamousProjects();
        IEnumerable<Project> GetRecProjects();
        IEnumerable<Project> GetFamProjects();
    }
}