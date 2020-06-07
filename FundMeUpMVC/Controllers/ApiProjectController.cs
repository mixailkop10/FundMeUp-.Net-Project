using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FundMeUp.Models;
using FundMeUp.Options;
using FundMeUp.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace FundMeUpMVC.Controllers
{   [ApiController]
    [Route("[controller]")]
    public class ApiProjectController : Controller
    {

        private IProjectManager projManager;
        private readonly ILogger<ApiProjectController> _logger;
        private readonly IWebHostEnvironment hostingEnvironment;

        public ApiProjectController(ILogger<ApiProjectController> logger, IProjectManager _projManager,IWebHostEnvironment environment)
        {
            hostingEnvironment = environment;
            projManager = _projManager;
            _logger = logger;
        }

        [HttpPost("CreateProject")]
        public Project CreateProject([FromForm] ProjectOption projOpt)
        {

          if (projOpt.MyImage != null)
          {
            var uniqueFileName = GetUniqueFileName(projOpt.MyImage.FileName);
            var uploads = Path.Combine(hostingEnvironment.WebRootPath, "images");
            var filePath = Path.Combine(uploads, uniqueFileName);
        projOpt.MyImage.CopyTo(new FileStream(filePath, FileMode.Create));


            projOpt.ImagePath = "/images/" + uniqueFileName;
            //to do : Save uniqueFileName  to your db table   
          }
      return projManager.CreateProject(projOpt);
        }

        private string GetUniqueFileName(string fileName)
        {
          fileName = Path.GetFileName(fileName);
          return Path.GetFileNameWithoutExtension(fileName)
                    + "_"
                    + Guid.NewGuid().ToString().Substring(0, 4)
                    + Path.GetExtension(fileName);
        }


    [HttpPost("UpdateBalance")]
        public bool UpdateBalance([FromBody] int id)
        {
            return projManager.UpdateBalance(id);
        }

        [HttpGet("AllProjects")]
        public List<Project> GetAll()
        {
            return projManager.GetAll();
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
