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
        public Backer GetProject(int id)
        {
            return backerManager.FindBackerById(id);
        }

        //public IActionResult CreateBacker()
        //{
        //    var viewModel = new CreateBackerViewModel();
        //    return View(viewModel);
        //}

        public IActionResult Index()
        {
            return View();
        }
    }
}
