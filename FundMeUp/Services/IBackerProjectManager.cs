using FundMeUp.Models;
using FundMeUp.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundMeUp.Services
{
    public interface IBackerProjectManager
    {
        BackerProject FindFundingById(int id);
        BackerProject CreateFunding(BackerProjectOption backProj);
        List<BackerProject> GetProjectFundings(int projectId);
        List<BackerProject> GetBackerFundings(int backerId);
        bool CancelFundingByBacker(int? backProjId);
        bool StatusUpdate(int backProjId, bool accept = false);
    }
}
