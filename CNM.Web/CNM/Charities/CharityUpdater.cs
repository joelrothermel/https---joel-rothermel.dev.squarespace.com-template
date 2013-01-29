using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CNM.Charities.Repositories;
using CNM.Models;

namespace CNM.Charities
{
    public class CharityUpdater
    {
        protected CharityRepository _repository = null;
        protected CharityProvider _charityProvider = null;

        public CharityUpdater(CharityRepository repository, CharityProvider charityProvider)
        {
            _repository = repository;
            _charityProvider = charityProvider;
        }

        public virtual UpdateResult Update(Charity updatedCharityData, IEnumerable<Skill> neededSkills, IEnumerable<ServiceArea> neededAreas)
        {
            if (_charityProvider.DoesCharityExist(updatedCharityData.OrganizationName, updatedCharityData.CharityId))
                return UpdateResult.ItemAlreadyExists;

            _repository.Update(updatedCharityData, neededSkills, neededAreas);

            return UpdateResult.Successful;
        }
    }
}
