using System;
using System.Collections.Generic;
using System.Text;

namespace FundMeUp.Models
{
  public class Category
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Project> Project { get; set; }
  }
}
