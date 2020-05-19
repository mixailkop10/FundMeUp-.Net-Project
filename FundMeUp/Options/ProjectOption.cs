using FundMeUp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundMeUp.Options
{
  public class ProjectOption
  {
    //public int Id { get; set; } νομιζω δεν χρειαζεται
    public string Name { get; set; }
    public string Description { get; set; }
    public Category Category { get; set; } // εμενα αυτο χτυπαει !! 
    public decimal BudgetGoal { get; set; }
    public decimal BalanceGoal { get; set; }
    public DateTime DoA { get; set; }
    public Reward Reward { get; set; }
    public ProjectCreator ProjectCreator { get; set; }
  }
}
