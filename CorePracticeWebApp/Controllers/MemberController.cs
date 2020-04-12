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
            var member = new Members();
            var memberInDb = db.Members.Find(id);
            if(memberInDb != null)
            {
                member = memberInDb;
            }

            return View(member);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View("MemberForm", new Members());
        }

        [HttpPost]
        public IActionResult Add(Members member)
        {
            return Update(member);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            //var member = CorePracticeServices.GetMember(id);
            var member = db.Members.Find(id);
            if (!string.IsNullOrEmpty(member.FirstName))
            {
                return View("MemberForm", member);
            }
            else
            {
                return RedirectToAction("Add");
            }
        }

        [HttpPost]
        public IActionResult Edit(Members member)
        {
            return Update(member);
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