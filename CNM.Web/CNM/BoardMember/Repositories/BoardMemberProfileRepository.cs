using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using CNM.Models;
using CNM.Sql;

namespace CNM.Repositories
{
    public class BoardMemberProfileRepository
    {

        public virtual IEnumerable<BoardMember> GetAllBoardMembers()
        {
            using (var context = new SqlDataContext())
            {
                return context.BoardMembers.ToList();
            }
        }

        public virtual BoardMember GetBoardMember(int id)
        {
            using (var context = new SqlDataContext())
            {
                return context.BoardMembers.Find(id);
            }
        }

        public virtual BoardMember GetBoardMember(string email)
        {
            using (var context = new SqlDataContext())
            {
                return context.BoardMembers.Where(x => x.Email == email).FirstOrDefault();

            }
        }

        public virtual IEnumerable<BoardMember> GetSetOfBoardMembers(Expression<Func<BoardMember, bool>> selector)
        {
            using(var context = new SqlDataContext())
            {
                return context.BoardMembers.Where(selector).ToList();
            }
        }

        public virtual void Add(BoardMember member, IEnumerable<Skill> skills, IEnumerable<ServiceArea> serviceAreas)
        {
            using (var context = new SqlDataContext())
            {
                member.AvailableSkills.Clear();
                member.Interests.Clear();

                context.BoardMembers.Add(member);
                context.SaveChanges();

                if (skills != null && serviceAreas != null && member.AvailableSkills != null && member.Interests != null)
                {
                    member.AvailableSkills.Clear();
                    member.Interests.Clear();

                    var rawSkillIds = skills.Select(x => (int)x);
                    var rawServiceIds = serviceAreas.Select(x => (int)x);

                    var transformSkils = context.Skills.Where(x => rawSkillIds.Contains(x.SkillId)).ToList();
                    var transformAreas = context.ServiceAreas.Where(x => rawServiceIds.Contains(x.ServiceAreaId)).ToList();

                    transformSkils.ForEach(x => member.AvailableSkills.Add(x));
                    transformAreas.ForEach(x => member.Interests.Add(x));
                }

                context.SaveChanges();
            }
        }

        public virtual void Update(BoardMember updatedMember, IEnumerable<Skill> skills, IEnumerable<ServiceArea> serviceAreas)
        {
            using (var context = new SqlDataContext())
            {
                var member = context.BoardMembers.First(x => x.BoardMemberId == updatedMember.BoardMemberId);

                member.Address1 = updatedMember.Address1;
                member.Address2 = updatedMember.Address2;
                member.City = updatedMember.City;
                member.Email = updatedMember.Email;
                member.Employer = updatedMember.Employer;
                member.FirstName = updatedMember.FirstName;
                member.LastName = updatedMember.LastName;
                member.Title = updatedMember.Title;
                member.Phone = updatedMember.Phone;
                member.PostalCode = updatedMember.PostalCode;
                member.State = updatedMember.State;
                member.Ethnicity = updatedMember.Ethnicity;
                member.Gender = updatedMember.Ethnicity;
                member.YearsService = updatedMember.YearsService;
                member.MissionStatement = updatedMember.MissionStatement;
                member.BirthDay = updatedMember.BirthDay;
                member.IsSearchable = updatedMember.IsSearchable;
                if (!String.IsNullOrWhiteSpace(updatedMember.Password))
                    member.Password = updatedMember.Password;

                if (skills != null && serviceAreas != null && member.AvailableSkills != null && member.Interests != null)
                {
                    member.AvailableSkills.Clear();
                    member.Interests.Clear();

                    var rawSkillIds = skills.Select(x => (int)x);
                    var rawServiceIds = serviceAreas.Select(x => (int)x);

                    var transformSkils = context.Skills.Where(x => rawSkillIds.Contains(x.SkillId)).ToList();
                    var transformAreas = context.ServiceAreas.Where(x => rawServiceIds.Contains(x.ServiceAreaId)).ToList();

                    transformSkils.ForEach(x => member.AvailableSkills.Add(x));
                    transformAreas.ForEach(x => member.Interests.Add(x));
                }

                context.SaveChanges();
            }
        }

        public virtual int? ValidateLogin(string email, string password)
        {
            using (var context = new SqlDataContext())
            {
                var thingy = context.BoardMembers
                    .Where(x => x.Email == email && x.Password == password)
                    .FirstOrDefault();

                if (thingy == null)
                    return null;
                else
                    return thingy.BoardMemberId;
            }

        }

    }
}
