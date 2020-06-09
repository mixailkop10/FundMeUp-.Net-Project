using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FundMeUp.Models;
using FundMeUp.Options;
using FundMeUp.Services;
using Microsoft.AspNetCore.Mvc;

namespace FundMeUpMVC.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiBackerProjectController : Controller
    {
        private IBackerProjectManager bpMng;
        private IProjectManager pMng;
        public ApiBackerProjectController(IBackerProjectManager bpMng, IProjectManager pMng)
        {
            this.bpMng = bpMng;
            this.pMng = pMng;
        }

        [HttpPost("CreateBackerProject")]
        public BackerProject CreateBackerProject([FromBody] BackerProjectOption backerProjectOption)
        {
            return bpMng.CreateFunding(backerProjectOption);
        }
    }
}