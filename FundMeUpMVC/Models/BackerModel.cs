using FundMeUp.Models;
using FundMeUp.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundMeUpMVC.Models
{
    public class BackerModel
    {
        public List<Backer> Backers { get; set; }
        public BackerOption backerOption { get; set; }
    }
}
