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
    public string Category { get; set; } // τωρα με το using ολα κομπλε 
    public decimal BudgetGoal { get; set; }
    public decimal BalanceGoal { get; set; }
    public DateTime DoA { get; set; }
    


  }
}
