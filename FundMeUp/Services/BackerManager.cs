using FundMeUp.Models;
using FundMeUp.Options;
using FundMeUp.Repository;
using System.Collections.Generic;
using System.Linq;

namespace FundMeUp.Services
{
  public class BackerManager : IBackerManager
  {
    private FundMeUpDbContext db;

    public BackerManager(FundMeUpDbContext _db)
    {
      db = _db;
    }

    //CRUD

    /// Creating a new Backer (User) for the platform
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

    public List<Backer> FindBackerByName(BackerOption BackerOpt)
    {
      return db.Backers // LAMPROS AM CONFIRMED
        .Where(b => b.FirstName == BackerOpt.FirstName)
        .Where(b => b.LastName == BackerOpt.LastName)
        .ToList();

    }

        public Backer UpdateBacker(BackerOption backerOption, int backerId)
        {
            Backer backer = db.Backers.Find(backerId);
            if (backerOption.FirstName != null)
                backer.FirstName = backerOption.FirstName;
            if (backerOption.LastName != null)
                backer.LastName = backerOption.LastName;
            if (backerOption.Profession != null)
                backer.Profession = backerOption.Profession;
            if (backerOption.Address != null)
                backer.Address = backerOption.Address;
            if (backerOption.Email != null)
                backer.Email = backerOption.Email;
            if (backerOption.Password != null)
                backer.Password = backerOption.Password;
            db.SaveChanges();
            return backer;
        }

        public bool DeleteBackerById(int backerId)
        {
            Backer backer = db.Backers.Find(backerId);
            if (backer != null)
            {
                db.Backers.Remove(backer);
                db.SaveChanges();
                return true;
            }
            return false;
        }
        public List<Backer> GetBackers()
        {
            return db.Backers.ToList();
        }

    }
}
