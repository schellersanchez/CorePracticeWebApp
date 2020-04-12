using System;
using System.Collections.Generic;

namespace CorePracticeWebApp.Models
{
    public partial class Members
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? DateofBap { get; set; }
        public bool? IsActive { get; set; }
    }
}
