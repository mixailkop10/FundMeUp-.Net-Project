using FundMeUp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundMeUp.Options
{
  public class BackerProjectOption
  {
    public int BackerId { get; set; }
    public int ProjectId { get; set; }
    public decimal Fund { get; set; }
    public int RewardId { get; set; }
  }
}
