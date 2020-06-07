using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FundMeUp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FundMeUpMVC.Models
{
    public class PCDashboardViewModel
    {

        // public IPagedList<Project> Projects { get; set; }
        public int ProjectId { get; set; }
        public DateTime SearchStartDate { get; set; }
        public DateTime SearchEndDate { get; set; }

        //fotis apo katw

        public int ProjectCreatorId { get; set; }

        public List<Project> Projects { get; set; }
        public ProjectCreator ProjectCreator { get; set; }


    }
}