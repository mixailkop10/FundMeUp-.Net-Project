using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FundMeUp.Models
{
    //public enum Category
    //{
    //    [Display(Name = "-- Select category --")]
    //    None = 0,
    //    [Display(Name = "Arts")]
    //    Art,
    //    [Display(Name = "Robotics")]
    //    Robotic,
    //    [Display(Name = "Technology")]
    //    Tech,
    //    [Display(Name = "Social Entrepreneurship")]
    //    Social,
    //    [Display(Name = "Education")]
    //    Education,
    //    [Display(Name = "Media & Communications")]
    //    Media,
    //    [Display(Name = "Health & Fitness")]
    //    Health

    //}
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string StatusUpdate { get; set; }
        public float BudgetGoal { get; set; }
        public float Balance { get; set; }
        public List<BackerProject> BackerProject { get; set; }
        public DateTime DoΑ { get; set; }
        public List<Reward> Reward { get; set; }
        public string Category { get; set; }
        public ProjectCreator ProjectCreator { get; set; }
        public bool Available { get; set; }
        public bool Funded { get; set; }

    }
}
