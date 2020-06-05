using FundMeUp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace FundMeUpMVC.Models
{
    public class BDashboardViewModel
    {
        public IPagedList<BackerProject> BackerProjects { get; set; }
    }
}
