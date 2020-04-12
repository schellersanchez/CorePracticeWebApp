using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorePracticeWebApp.Models;
using CorePracticeWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace CorePracticeWebApp.Controllers
{
    public class MemberController : Controller
    {
        CorePracticeWebAppContext db = new CorePracticeWebAppContext();

        [HttpGet]
        public IActionResult Details(int id)
        {
            var member = MemberServices.GetMember(id);

            return View("MemberForm", new MemberVm(member, "readonly"));
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View("MemberForm", new MemberVm("add"));
        }

        [HttpPost]
        public IActionResult Add(MemberVm memberVm)
        {
            int id = MemberServices.AddMember(memberVm.Member);
            return RedirectToAction("Details", "Member", new { @id = id });
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            //var member = CorePracticeServices.GetMember(id);
            var member = db.Members.Find(id);
            if (member != null)
            {
                return View("MemberForm", new MemberVm(member, "edit"));
            }
            else
            {
                return RedirectToAction("Add");
            }
        }

        [HttpPost]
        public IActionResult Submit(MemberVm member)
        {

            switch (member.ViewMode.ToLower())
            {
                case "edit":
                    //do something
                    break;  
                case "add":
                    //do something
                    break;
                default:
                    //do nothing
                    break;
            }

            return RedirectToAction("View", member);
        }

        private IActionResult Update(Members member)
        {
            if(member.Id == 0)
            {
                db.Members.Add(member);
            }
            else
            {
                var memberInDb = db.Members.Find(member.Id);
                if(memberInDb != null)
                {
                    memberInDb.FirstName = member.FirstName;
                    memberInDb.LastName = member.LastName;
                    memberInDb.StreetAddress = member.StreetAddress;
                    memberInDb.City = member.City;
                    memberInDb.State = member.State;
                    memberInDb.Country = member.Country;
                    memberInDb.DateOfBirth = member.DateOfBirth;
                    memberInDb.DateofBap = member.DateofBap;
                }
            }

            db.SaveChanges();

            return RedirectToAction("Details", new { id = member.Id });
        }

        [HttpGet]
        public IActionResult Manage()
        {
            var viewModel = new MemberManageVm()
            {
                //Members = CorePracticeServices.GetAllMembers()
                Members = db.Members.ToList()
            };
            return View(viewModel);
        }

    }
}