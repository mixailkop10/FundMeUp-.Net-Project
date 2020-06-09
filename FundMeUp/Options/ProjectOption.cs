using FundMeUp.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundMeUp.Options
{
  public class ProjectOption
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public string Category { get; set; } 
    public float BudgetGoal { get; set; }
    public float Balance { get; set; }
    public DateTime DateOfCreation { get; set; }
    public string StatusUpdate { get; set; }
    public int ProjectCreatorId { get; set; }
    public IFormFile MyImage { set; get; }
    public string ImagePath { get; set; }
  }
}
