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
            return RedirectToAction("Edit", "Member", new { @id = id });
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            //var member = CorePracticeServices.GetMember(id);
            var member = MemberServices.GetMember(id);
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
        public IActionResult Edit(MemberVm viewModel)
        {
            var result = EnumServices.UpdateResult.fail; //0 = fail, 1 = success

            if (!ModelState.IsValid)
            {
                viewModel.PageMessage = "Not Valid Entry";
                return View("MemberForm", viewModel);
            }
            else
            {
                result = MemberServices.UpdateMember(viewModel.Member);
            }
            if (result.Equals(EnumServices.UpdateResult.success))
            {
                viewModel.PageMessage = "Successfully updated";
                return RedirectToAction("Edit", "Member", new { @id = viewModel.Member.Id });

            }
            else
            {
                viewModel.PageMessage = "Error updating";
                return View("MemberForm", viewModel);

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

        //private IActionResult Update(Members member)
        //{
        //    if(member.Id == 0)
        //    {
        //        db.Members.Add(member);
        //    }
        //    else
        //    {
        //        var memberInDb = db.Members.Find(member.Id);
        //        if(memberInDb != null)
        //        {
        //            memberInDb.FirstName = member.FirstName;
        //            memberInDb.LastName = member.LastName;
        //            memberInDb.StreetAddress = member.StreetAddress;
        //            memberInDb.City = member.City;
        //            memberInDb.State = member.State;
        //            memberInDb.Country = member.Country;
        //            memberInDb.DateOfBirth = member.DateOfBirth;
        //            memberInDb.DateofBap = member.DateofBap;
        //        }
        //    }

        //    db.SaveChanges();

        //    return RedirectToAction("Details", new { id = member.Id });
        //}

        [HttpGet]
        public IActionResult Manage()
        {
            var viewModel = new MemberManageVm()
            {
                Members = MemberServices.GetActiveMembers()
                //Members = db.Members.ToList()
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Delete(Members member)
        {
            member.IsActive = false;
            var result = MemberServices.UpdateMember(member);

            if (result.Equals(EnumServices.UpdateResult.success))
            {
                return Ok("Sucessfully deleted");
            }
            else
            {
                return BadRequest("Error Deleting");
            }
        }

    }
}