using FundMeUp.Models;
using FundMeUp.Options;
using FundMeUp.Repository;
using System.Linq;

namespace FundMeUp.Services
{
  public class BackerManager
  {
    private FundMeUpDbContext db;

    public BackerManager(FundMeUpDbContext _db)
    {
      db = _db;
    }

    //CRUD

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


    public Backer FindBackerById(int backerId)
    {
      return db.Backers.Find(backerId);
    }

    public Backer FindBackerByName(BackerOption BackerOpt)
    {
      return null;/* db.Backers
        .Where(b => b.FirstName == BackerOpt.FirstName)
        .Where(b => b.LastName == BackerOpt.LastName).ToList();*/

    }

  }
}
