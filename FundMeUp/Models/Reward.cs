using System;
using System.Collections.Generic;
using System.Text;

namespace FundMeUp.Models
{
  public class Reward
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public int ProjectId { get; set; }
    public string Description { get; set; }
    public Project Project { get; set; }
    public float Price { get; set; }
    public List<BackerProject> BackerProjects { get; set; }
  }
}
