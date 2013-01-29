using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CNM.Charities.Repositories;
using CNM.Models;

namespace CNM.Charities
{
    public class CharityProvider
    {
        protected CharityRepository _repository = null;

        public CharityProvider(CharityRepository repository)
        {
            _repository = repository;
        }

        public virtual IEnumerable<Charity> GetAllCharities()
        {
            return _repository.GetAllCharities().ToList();
        }

        public virtual IEnumerable<Charity> GetSetOfCharities(IEnumerable<string> charityIds)
        {
            return _repository.GetSubsetOfCharities(x => charityIds.Contains(x.CharityId)).ToList();
        }

        public virtual bool DoesCharityExist(string organizationName, string charityId)
        {
            return _repository.GetSpecificCharity(x => x.OrganizationName.ToLower() == organizationName.ToLower() && x.CharityId != charityId) != null;
        }

        public virtual Charity GetCharityFor(string charityId)
        {
            return GetSetOfCharities(new List<string> { charityId }).FirstOrDefault();
        }
    }
}
