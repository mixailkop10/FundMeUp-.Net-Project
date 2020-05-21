using FundMeUp.Models;
using FundMeUp.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundMeUp.Services
{
     public interface IBackerManager
    {
        Backer CreateBacker(BackerOption backerOption);

        Backer FindBackerById(int backerId);
        List<Backer> FindBackerByName(BackerOption backerOption);
        Backer UpdateBacker(BackerOption backerOption, int backerId);
        bool DeleteBackerById(int backerId);
        List<Backer> GetBackers();
    }
}
