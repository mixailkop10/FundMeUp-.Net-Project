using FundMeUp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundMeUp.Options
{
  public class CategoryOption
  {
    public string Name { get; set; }
    public List<Project> Project { get; set; }
  }
}
