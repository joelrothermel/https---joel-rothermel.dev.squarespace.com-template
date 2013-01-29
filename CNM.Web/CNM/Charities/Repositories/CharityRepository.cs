using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using CNM.Models;
using CNM.Searching.Repositories;
using CNM.Security.Procedures;
using CNM.Sql;

namespace CNM.Charities.Repositories
{
    public class CharityRepository
    {
        protected SearchingRepository _searchRepository = null;

        public CharityRepository(SearchingRepository searchRepository)
        {
            _searchRepository = searchRepository;
        }

        public virtual IEnumerable<Charity> GetAllCharities()
        {
            using (var context = new SqlDataContext())
            {
                return context.Charities.ToList();
            }
        }

        public virtual IEnumerable<Charity> GetSubsetOfCharities(Expression<Func<Charity, bool>> selector)
        {
            using (var context = new SqlDataContext())
            {
                return context.Charities.Where(selector).ToList();
            }
        }

        public virtual Charity GetSpecificCharity(Expression<Func<Charity, bool>> selector)
        {
            return GetSubsetOfCharities(selector).FirstOrDefault();
        }

        public virtual void Add(Charity charity)
        {
            using (var context = new SqlDataContext())
            {
                context.Charities.Add(charity);
                context.SaveChanges();
            }

            _searchRepository.UpdateSearchIndexForCharity(charity.CharityId);
        }

        public virtual void Update(Charity updatedData, IEnumerable<Skill> neededSkills, IEnumerable<ServiceArea> neededAreas)
        {
            using (var context = new SqlDataContext())
            {
                var charity = context.Charities.First(x => x.CharityId == updatedData.CharityId);

                charity.Address1 = updatedData.Address1;
                charity.Address2 = updatedData.Address2;
                charity.City = updatedData.City;
                charity.Email = updatedData.Email;
                charity.Essay = updatedData.Essay;
                charity.FirstName = updatedData.FirstName;
                charity.LastName = updatedData.LastName;
                charity.OrganizationName = updatedData.OrganizationName;
                charity.Phone = updatedData.Phone;
                charity.PostalCode = updatedData.PostalCode;
                charity.State = updatedData.State;
                charity.Website = updatedData.Website;
                charity.YearsService = updatedData.YearsService;
                charity.IsSearchable = updatedData.IsSearchable;

                if (!string.IsNullOrWhiteSpace(updatedData.Password))
                    charity.Password = updatedData.Password;

                charity.NeededSkills.Clear();
                charity.NeededServiceAreas.Clear();

                var skillTransform = neededSkills.Select(x => (int)x);
                var areaTransform = neededAreas.Select(x => (int)x);

                var newSkills = context.Skills.Where(x => skillTransform.Contains(x.SkillId)).ToList();
                var newAreas = context.ServiceAreas.Where(x => areaTransform.Contains(x.ServiceAreaId)).ToList();

                newSkills.ForEach(x => charity.NeededSkills.Add(x));
                newAreas.ForEach(x => charity.NeededServiceAreas.Add(x));

                context.SaveChanges();
            }

            _searchRepository.UpdateSearchIndexForCharity(updatedData.CharityId);
        }

        public virtual string ValidateLogin(string username, string password)
        {
            LookupCharityId procedure = new LookupCharityId();
            var charityId = procedure.Execute(username).CharityId;

            using (var context = new SqlDataContext())
            {
                var matchingPassword = context.Charities.FirstOrDefault(x => x.CharityId == charityId && x.Password.ToLower() == password.ToLower());

                if (matchingPassword != null)
                    return charityId;

                return null;
            }

        }
    }
}
