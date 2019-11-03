using CorePracticeWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorePracticeWebApp
{
    public class CorePracticeServices
    {
        internal static List<Member> GetAllMembers()
        {
            var members = new List<Member>();
            return members;
        }

        internal static Member GetMember(int id)
        {
            var member = new Member();
            return member;
        }
    }
}
