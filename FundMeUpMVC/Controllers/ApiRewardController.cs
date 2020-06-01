using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FundMeUp.Models;
using FundMeUp.Options;
using FundMeUp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FundMeUpMVC.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiRewardController : Controller
    {
        private IRewardManager rewardManager;
        private readonly ILogger<ApiRewardController> _logger;

        public ApiRewardController(ILogger<ApiRewardController> logger, IRewardManager _rewardManager)
        {
            rewardManager = _rewardManager;
            _logger = logger;
        }

        [HttpPost("AddReward")]
        public Reward CreateReward([FromBody] RewardOption projOpt)
        {
            return rewardManager.CreateReward(projOpt);
        }
    }
}
