using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorePracticeWebApp.Models;
using CorePracticeWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CorePracticeWebApp.Controllers
{
    public class MemberController : Controller
    {
        [HttpGet]
        public IActionResult Index(int id)
        {
            var member = CorePracticeServices.GetMember(id);
            return View(member);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View("MemberForm", new Member());
        }

        [HttpPost]
        public IActionResult Add(Member member)
        {
            return Update(member);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var member = CorePracticeServices.GetMember(id);
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
        public IActionResult Edit(Member member)
        {
            return Update(member);
        }

        private IActionResult Update(Member member)
        {
            return RedirectToAction("Index", new { id = member.Id });
        }

        [HttpGet]
        public IActionResult Manage()
        {
            var viewModel = new MemberManageVm()
            {
                Members = CorePracticeServices.GetAllMembers()
            };
            return View(viewModel);
        }

    }
}