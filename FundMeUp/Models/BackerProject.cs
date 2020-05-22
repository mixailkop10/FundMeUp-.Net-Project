using System;

namespace FundMeUp.Models
{
  public enum Status
  {
      Pending, Accepted, Declined, Expired, Canceled
  }
  public class BackerProject
  {
    public int Id { get; set; }
    public Backer Backer { get; set; }
    public int BackerId { get; set;}
    public Project Project { get; set; }
    public int ProjectId { get; set; }
    public DateTime DoF { get; set; }
    public decimal Fund { get; set; }
    public Status Status { get; set; }
    public Reward Reward { get; set;}
    public int RewardId { get; set; }
  }
}
