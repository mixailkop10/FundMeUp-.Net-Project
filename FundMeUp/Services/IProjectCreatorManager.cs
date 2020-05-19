using FundMeUp.Models;
using FundMeUp.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundMeUp.Services
{
    interface IProjectCreatorManager
    {
        ProjectCreator CreateProjectCreator(ProjectCreatorOption PCrOption);
        ProjectCreator FindProjectCreatorById(int projectCreatorId);
        List<ProjectCreator> FindProjectCreatorByName(ProjectCreatorOption PCrOption);
        ProjectCreator Update(ProjectCreatorOption PCrOption, int projectCreatorId);
        bool DeleteProjectCreatorById(int id);
        bool SoftDeleteProjectCreatorById(int id);
        List<ProjectCreator> GetAllProjectCreators();
        

    }


}
}
