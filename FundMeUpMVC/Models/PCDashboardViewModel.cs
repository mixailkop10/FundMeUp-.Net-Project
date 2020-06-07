using FundMeUp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace FundMeUpMVC.Models
{
    public class PCDashboardViewModel
    {
        public List<BackerProject> PendingBackerProjects { get; set; }
        public IPagedList<BackerProject> AcceptedBackerProjects { get; set; }
        public int ProjectId { get; set; }
        public DateTime SearchStartDate { get; set; }
        public DateTime SearchEndDate { get; set; }

        /*IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
         if (SearchEndDate < SearchStartDate)
            {
                yield return new ValidationResult("Check-out must be greater than Check-in");
            }
        }
        */

       public int ProjectCreatorId { get; set; }
        
       public List<Project> Projects { get; set; }
       public ProjectCreator ProjectCreator { get; set; }

        
    }


}
