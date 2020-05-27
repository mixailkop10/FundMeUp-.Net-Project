using FundMeUp.Models;
using FundMeUp.Options;
using FundMeUp.Repository;
using FundMeUp.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FundMeUp
{
  class Program
  {
        static void Main()
        { 
            var dbContext = new FundMeUpDbContext();
            dbContext.Database.EnsureCreated();

            var backer1 = new Backer
            {
                FirstName = "Mixalis",
                LastName = "Koptsis",
                Profession = "Developer",
                Address = "G.Drosini 12",
                Email = "mieciel-1908@hotmail.com",
                Password = "12345"
            };
            var backer = new Backer
            {
                FirstName = "Mixalis",
                LastName = "Kop",
                Profession = "Developer",
                Address = "Drosini 12",
                Email = "mieciel@hotmail.com",
                Password = "12345"
            };
            Backer backer2 = new Backer
            {
                FirstName = "Geo",
                LastName = "Kop",
                Profession = "Developer",
                Address = "Drosini 14",
                Email = "mieciel10@hotmail.com",
                Password = "456"
            };
            dbContext.Add(backer1);
            dbContext.Add(backer);
            dbContext.Add(backer2);
            var backerManager = new BackerManager(dbContext);
            List<Backer> backers = backerManager.GetBackers();
            Console.WriteLine("The list of backers" + backers);
        }
  }
}
