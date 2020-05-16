﻿using FundMeUp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundMeUp.Options
{
  public class ProjectOption
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal BudgetGoal { get; set; }
    public decimal BalanceGoal { get; set; }
    public DateTime DoA { get; set; }
    public Reward Reward { get; set; }
    public Category Category { get; set; }
    public ProjectCreator ProjectCreator { get; set; }
  }
}
