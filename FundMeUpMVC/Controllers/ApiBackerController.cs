using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FundMeUp.Models;
using FundMeUp.Options;
using FundMeUp.Services;
using FundMeUpMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FundMeUpMVC.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiBackerController : Controller
    {
        
        private readonly ILogger<ApiBackerController> logger;
        private IBackerManager backerManager;

        public ApiBackerController (ILogger<ApiBackerController> logger, IBackerManager backerManager)
        {
            this.logger = logger;
            this.backerManager = backerManager;
        }

        [HttpPost("CreateBacker")]
        public Backer CreateBacker([FromBody] BackerOption backerOption)
        {
            return backerManager.CreateBacker(backerOption);
        }

        [HttpGet("AllBackers")]
        public List<Backer> GetAll()
        {
            return backerManager.GetBackers();
        }

        [HttpGet("Backer/{id}")]
        public Backer GetBacker(int id)
        {
            return backerManager.FindBackerById(id);
        }

        [HttpPut("EditBacker/{id}")]
        public Backer EditBacker([FromBody] BackerOption backerOption, int backerId)
        {
            return backerManager.UpdateBacker(backerOption, backerId);
        }

        //[HttpDelete("DeleteBacker/{id}")]
        //public bool DeleteBacker(int backerId)
        //{
        //    return backerManager.DeleteBackerById(backerId);
        //}
        [HttpDelete("DeleteBacker")]
        public bool DeleteBacker([FromBody] DeleteModel delModel)
        {
            if (delModel != null)
                return backerManager.DeleteBackerById(delModel.Id);
            else return false;
        }

        [HttpPut("EditActivityStatus")]
        public Backer EditActivityStatus([FromBody] int backerId)
        {
            return backerManager.ChangeActivityStatus(backerId);
        }

        [HttpPost("Login")]
        public Backer LoginBacker([FromBody] BackerOption backerOption)
        {
            return backerManager.FindBackerByEmail(backerOption);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
