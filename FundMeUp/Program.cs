using FundMeUp.Repository;
using Microsoft.EntityFrameworkCore;
using System;

namespace FundMeUp
{
  class Program
  {
    static void Main(string[] args)
    {
      var dbContext = new FundMeUpDbContext();
      dbContext.Database.EnsureCreated();
    }
  }
}
