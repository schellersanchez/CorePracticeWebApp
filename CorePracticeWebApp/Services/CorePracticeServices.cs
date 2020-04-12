using CorePracticeWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CorePracticeWebApp
{
    public class MemberServices
    {
        internal static List<Members> GetAllMembers()
        {
            var allMembers = new List<Members>();
            using (var db = new CorePracticeWebAppContext())
            {
                allMembers = db.Members.ToList();
            }

            return allMembers;
        }

        internal static List<Members> GetActiveMembers()
        {
            var activeMembers = new List<Members>();
            using (var db = new CorePracticeWebAppContext())
            {
                activeMembers = db.Members.Where(m => m.IsActive == true).ToList();
            }
            return activeMembers;
        }

        internal static Members GetMember(int id)
        {
            var member = new Members();

            using (var db = new CorePracticeWebAppContext())
            {
                member = db.Members.Find(id);
            }

            return member;
        }

        internal static EnumServices.UpdateResult UpdateMember(Members member)
        {
            using(var db = new CorePracticeWebAppContext())
            {
                try
                {
                    var memberInDb = db.Members.Find(member.Id);
                    if (memberInDb != null)
                    {
                        memberInDb.City = member.City;
                        memberInDb.Country = member.Country;
                        memberInDb.DateofBap = member.DateofBap;
                        memberInDb.DateOfBirth = member.DateOfBirth;
                        memberInDb.FirstName = member.FirstName;
                        memberInDb.LastName = member.LastName;
                        memberInDb.State = member.State;
                        memberInDb.StreetAddress = member.StreetAddress;
                        memberInDb.IsActive = member.IsActive;

                        db.SaveChanges();
                    }
                    else
                    {
                        throw new KeyNotFoundException("Member not found");
                    }
                }
                catch(Exception e)
                {
                    return EnumServices.UpdateResult.fail;
                }

                return EnumServices.UpdateResult.success;
                
            }

        }

        internal static int AddMember(Members member)
        {
            using (var db = new CorePracticeWebAppContext())
            {
                try
                {
                    db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Members] ON");
                    db.Members.Add(member);
                    db.SaveChanges();
                    db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Members] OFF");


                }
                catch (Exception e)
                {
                }
            }

            return member.Id;

        }

    }
}
