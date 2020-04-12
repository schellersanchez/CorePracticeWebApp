using CorePracticeWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorePracticeWebApp.ViewModels
{
    public class MemberVm
    {
        public Members Member { get; set; }
        public string ViewMode { get; set; }
        public string PageMessage { get; set; }

        public MemberVm()
        {
            Member = new Members();
        }
        public MemberVm(string viewMode)
        {
            Member = new Members();
            ViewMode = viewMode;
        }

        public MemberVm(Members member, string viewMode)
        {
            Member = member;
            ViewMode = viewMode;
        }
    }

    
}
