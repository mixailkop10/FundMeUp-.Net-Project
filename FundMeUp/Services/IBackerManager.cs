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
        List<Backer> FindBackerByName(BackerOption BackerOpt);
        

    }
}

