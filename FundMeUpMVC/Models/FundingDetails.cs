using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundMeUpMVC.Models
{
    public class FundingDetails
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public float BudgetGoal { get; set; }
        public float Balance { get; set; }
        public string BackerFirstName { get; set; }
        public string BackerLastName { get; set; }
        public float Fund { get; set; }
        public string RewardName { get; set; }
        public DateTime DoF { get; set; }
    }
}
