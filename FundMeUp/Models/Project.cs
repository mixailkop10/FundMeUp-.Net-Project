using System;
using System.Collections.Generic;
using System.Text;

namespace FundMeUp.Models
{
  public class Project
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string StatusUpdate { get; set; }
    public decimal BudgetGoal { get; set; }
    public decimal BalanceGoal { get; set; }
    public List<BackerProject> BackerProject { get; set; }
    public DateTime DoΑ { get; set; }
    public List<Reward> Reward { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    public ProjectCreator ProjectCreator { get; set; }
    public bool Available { get; set; }
    public bool Funded { get; set; }

  }
}
