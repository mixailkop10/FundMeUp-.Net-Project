using System;
using System.Collections.Generic;
using System.Text;

namespace FundMeUp.Options
{
    public class RewardOption
    {
        public string Name { get; set; }
        public int ProjectId { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
