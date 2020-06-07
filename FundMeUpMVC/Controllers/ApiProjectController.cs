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
{   [ApiController]
    [Route("[controller]")]
    public class ApiProjectController : Controller
    {

        private IProjectManager projManager;
        private readonly ILogger<ApiProjectController> _logger;

        public ApiProjectController(ILogger<ApiProjectController> logger, IProjectManager _projManager)
        {
            projManager = _projManager;
            _logger = logger;
        }


        [HttpPost("CreateProject")]
        public Project CreateProject([FromBody] ProjectOption projOpt)
        {
            return projManager.CreateProject(projOpt);
        }

        [HttpGet("AllProjects")]
        public List<Project> GetAll()
        {
            return projManager.GetAll();
        }

        [HttpGet("RecentProjects")]
        public List<Project> RecentProjects()
        {
            return projManager.GetRecentProjects();
        }

        [HttpGet("TrendingProjects")]
        public List<Project> TrendingProjects()
        {
            return projManager.GetFamousProjects();
        }

        [HttpGet("Project/{id}")]
        public Project GetProject(int id)
        {
            return projManager.FindProjectById(id);
        }

   
        [HttpPut("Project/{id}")]
        public Project PutProject([FromBody] ProjectOption projOpt, int id)
        {

            return projManager.Update(projOpt, id);
        }

        [HttpDelete("DeleteProject/{id}")]
        public bool DeleteProject( int id)
        {
            return projManager.DeleteProjectById(id);
        }

        [HttpGet("Category/{category}")]
        public List<Project> GetByCategory([FromRoute] string category)
        {
            ProjectOption projOpt = new ProjectOption
            {
                Category = category
            };
            return projManager.FindProjectByCategory(projOpt);
        }

    }
}
