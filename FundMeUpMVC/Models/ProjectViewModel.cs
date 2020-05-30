using FundMeUp.Models;
using FundMeUp.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
