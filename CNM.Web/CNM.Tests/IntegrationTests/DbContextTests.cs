using System;
using CNM.Models;
using CNM.Sql;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;

namespace CNM.Tests.IntegrationTests
{
    [TestClass]
    public class DbContextTests
    {
        [TestMethod]
        public void CanCrudBoardMembers()
        {
            Database.SetInitializer<SqlDataContext>(null);

            var dataContext = new SqlDataContext();

            //Insert!
            var member = new BoardMember
            {
                FirstName = "bob",
                LastName = "smith",
                BirthDay = DateTime.Now,
                Employer = "wut.com",
                Title = "le title",
                Phone = "8765435467",
                Email = "ihateken@forreal.com",
                Address1 = "123 Foo",
                Address2 = "Suite 5",
                City = "Dallas",
                State = "TX",
                PostalCode = "76543",
                MissionStatement = "To hate Ken"
                
            };
            dataContext.BoardMembers.Add(member);
            dataContext.SaveChanges();

            //Get
            var dude = dataContext.BoardMembers.Find(member.BoardMemberId);
            Assert.IsNotNull(dude);

            //Update
            dude.LastName = "JustinIsShort";
            dataContext.SaveChanges();
            dude = dataContext.BoardMembers.Find(member.BoardMemberId);
            Assert.AreEqual("JustinIsShort", dude.LastName, "Bad last name.");

            //Delete
            dataContext.BoardMembers.Remove(dude);
            dataContext.SaveChanges();
            dude = dataContext.BoardMembers.Find(member.BoardMemberId);
            Assert.IsNull(dude, "Did not delete.");
        }

        [TestMethod]
        public void CanCrudSkill()
        {
            Database.SetInitializer<SqlDataContext>(null);

            var dataContext = new SqlDataContext();

            //Get
            var skill = dataContext.Skills.Find(1);
            Assert.IsNotNull(skill);
        }

    }
}
