using FundMeUp.Models;
using FundMeUp.Options;
using FundMeUp.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundMeUp.Services
{
  public class BackerManager
  {
    private FundMeUpDbContext db;

    public BackerManager(FundMeUpDbContext _db)
    {
      db = _db;
    }

    /// <summary>
    /// Creating a new Backer (User) for the platform
    /// </summary>
    /// <param name="backerOption"></param>
    /// <returns></returns>
    public Backer CreateBacker(BackerOption backerOption)
    {
      Backer backer = new Backer
      {
        FirstName = backerOption.FirstName,
        LastName = backerOption.LastName,
        Email = backerOption.Email,
        Address = backerOption.Address,
        Profession = backerOption.Profession,
        Password = backerOption.Password,
        Active = true // Active by default
      };

      db.Backers.Add(backer);
      db.SaveChanges();

      return backer;
    }


  }
}
