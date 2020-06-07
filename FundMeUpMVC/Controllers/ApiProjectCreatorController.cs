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
    public class ApiProjectCreatorController : Controller
    {
        
        private readonly ILogger<ApiBackerController> logger;
        private IProjectCreatorManager projectCreatorManager;

        public ApiProjectCreatorController(ILogger<ApiBackerController> logger, IProjectCreatorManager projectCreatorManager)
        {
            this.logger = logger;
            this.projectCreatorManager = projectCreatorManager;
        }

        [HttpPost("CreateProjectCreator")]
        public ProjectCreator CreateProjectCreator([FromBody] ProjectCreatorOption projectCreatorOption)
        {
            return projectCreatorManager.CreateProjectCreator(projectCreatorOption);
        }

        [HttpGet("AllProjectCreators")]
        public List<ProjectCreator> GetAll()
        {
            return projectCreatorManager.GetAllProjectCreators();
        }

        [HttpGet("ProjectCreator/{id}")]
        public ProjectCreator GetProjectCreator([FromRoute]int id)
        {
            return projectCreatorManager.FindProjectCreatorById(id);
        }

        [HttpPut("EditProjectCreator/{id}")]
        public ProjectCreator EditProjectCreator([FromBody] ProjectCreatorOption  projectCreatorOption, int projectCreatorId)
        {
            return projectCreatorManager.Update(projectCreatorOption, projectCreatorId);
        }

        //[HttpDelete("DeleteProjectCreator")]
        //public bool DeleteProjectCreator([FromBody] DeleteModel delModel)
        //{
        //    if (delModel != null)
        //        return projectCreatorManager.DeleteProjectCreatorById(delModel.Id);
        //    else return false;
        //}
        [HttpDelete("DeleteProjectCreator/{id}")]
        public bool DeleteProjectCreator([FromRoute]int id)
        {
            return projectCreatorManager.DeleteProjectCreatorById(id);
        }

        [HttpPost("LoginProjectCreator")]
        public ProjectCreator LoginProjectCreator([FromBody] ProjectCreatorOption projectCreatorOption)
        {
            return projectCreatorManager.FindProjectCreatorByEmail(projectCreatorOption);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
