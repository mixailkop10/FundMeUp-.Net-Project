using FundMeUp.Models;
using FundMeUp.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FundMeUp.Services
{
    public interface IBackerProjectManager
    {
        BackerProject FindFundingById(int id);
        BackerProject CreateFunding(BackerProjectOption backProj);
        List<BackerProject> GetProjectFundings(int projectId);
        IQueryable<BackerProject> GetPendingProjectFundings(int projectId);
        IQueryable<BackerProject> GetAcceptedProjectFundings(int projectId);
        List<BackerProject> GetBackerFundings(int backerId);
        bool CancelFundingByBacker(int? backProjId);
        bool StatusUpdate(int backProjId, bool accept = false);
    }
}
