using FundMeUp.Models;
using FundMeUp.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FundMeUp.Services;

namespace FundMeUpMVC.Models
{
    public class ProjectViewModel
    {
        public ProjectOption ProjectOption { get; set; }

        public List<string> Categories { get; set; }

        public Project Project { get; set; }


    }

    public class CategoryOption
    {
        public string Category { get; set; }

        public List<Project> Projects { get; set; }
    }

    public class RewardsByProject
    {
        public List<Reward> Rewards { get; set; }
    }

    public class ProjectModel
    {
        public int ProjectId { get; set; }
        public List<Project> Projects { get; set; }
    }
}   

