using System;
using System.Collections.Generic;
using System.Text;

namespace FundMeUp.Models
{
  public class Backer
  {
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Proffesion { get; set; }
    public string Address { get; set; }
    public string Email { get; set; } 
    public string Password { get; set; }
    public bool Active { get; set; } //For activate/deactivate reasons
  }
}
