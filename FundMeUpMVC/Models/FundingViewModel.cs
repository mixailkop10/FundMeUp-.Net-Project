using FundMeUp.Models;
using FundMeUp.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundMeUpMVC.Models
{
    public class FundingViewModel
    {
        public FundingViewModel()
        {
            this.BackerProjectOption = new BackerProjectOption();
        }
        public BackerProjectOption BackerProjectOption { get; set; }
        public Reward Reward { get; set; }
    }
}
