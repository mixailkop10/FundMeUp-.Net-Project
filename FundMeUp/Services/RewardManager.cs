using FundMeUp.Models;
using FundMeUp.Options;
using FundMeUp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FundMeUp.Services
{
    public class RewardManager:IRewardManager
    {
        private FundMeUpDbContext db;

        public RewardManager(FundMeUpDbContext db)
        {
            this.db = db;
        }

        public Reward CreateReward(RewardOption rewardOpt)
        {
            Reward reward = new Reward
            {
                Name = rewardOpt.Name,
                Description = rewardOpt.Description,
                Price = rewardOpt.Price,
                ProjectId = rewardOpt.ProjectId
               

            };

            db.Rewards.Add(reward);
            db.SaveChanges();

            return reward;
        }


        public bool DeleteAllRewards(int projectId)
        {
            List<Reward> rewards = db.Rewards
                .Where(r => r.ProjectId == projectId)
                .ToList();
            if (rewards != null)
            { 
            db.Rewards.RemoveRange(rewards);
            db.SaveChanges();
            return true;
            }
            return false;

        }

        public List<Reward> GetRewards(int projectId)
        {
            List<Reward> rewards = db.Rewards
                .Where(r => r.ProjectId == projectId)
                .ToList();
            return rewards;
        }

        

    }
}
