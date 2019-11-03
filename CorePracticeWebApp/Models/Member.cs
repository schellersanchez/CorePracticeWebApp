using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorePracticeWebApp.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfBap { get; set; }
        public bool IsActive { get; set; }
    }
}
