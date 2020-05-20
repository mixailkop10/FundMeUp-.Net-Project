using FundMeUp.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundMeUpMVC.Models
{
    public class CreateProjectViewModel
    {
        public ProjectOption projectOption { get; set; }

        public List<string> Categories { get; set; }

    }
}
