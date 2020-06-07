using FundMeUp.Models;
using FundMeUp.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundMeUp.Services
{
    public interface IRewardManager
    {
        public Reward CreateReward(RewardOption rewardOpt);
        public bool DeleteAllRewards(int projectId);
        public List<Reward> GetRewards(int projectId);
        Reward FindRewardById(int id);
    }
}
