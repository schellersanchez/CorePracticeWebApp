using CorePracticeWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorePracticeWebApp
{
    public class CorePracticeServices
    {
        internal static List<Members> GetAllMembers()
        {
            var members = new List<Members>();
            return members;
        }

        internal static Members GetMember(int id)
        {
            var member = new Members();
            return member;
        }
    }
}
