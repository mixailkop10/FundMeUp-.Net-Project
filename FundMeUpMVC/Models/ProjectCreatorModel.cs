using FundMeUp.Models;
using FundMeUp.Options;
using FundMeUp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundMeUpMVC.Models
{
    public class ProjectCreatorModel
    {
        public List<ProjectCreator> ProjectCreators { get; set; }
        public ProjectCreatorOption projectCreatorOption { get; set; }
    }
}
