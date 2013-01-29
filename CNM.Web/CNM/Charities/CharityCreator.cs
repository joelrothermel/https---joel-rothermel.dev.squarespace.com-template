using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CNM.Charities.Repositories;
using CNM.Models;

namespace CNM.Charities
{
    public class CharityCreator
    {
        protected CharityRepository _repository = null;
        protected CharityProvider _charityProvider = null;

        public CharityCreator(CharityRepository repository, CharityProvider charityProvider)
        {
            _repository = repository;
            _charityProvider = charityProvider;
        }

        public virtual CreateResult Save(Charity newCharityData)
        {
            if (_charityProvider.DoesCharityExist(newCharityData.OrganizationName, newCharityData.CharityId))
                return CreateResult.ItemAlreadyExists;

            _repository.Add(newCharityData);

            return CreateResult.SuccessfullyCreated;
        }

        public virtual CreateResult CreateFreshCharity(string charityId)
        {
            Charity charity = new Charity
            {
                Address1 = "Enter an Address",
                Address2 = string.Empty,
                CharityId = charityId,
                City = "Dallas",
                Email = "Enter an Email",
                Essay = "My Description",
                FirstName = "First Name",
                IsSearchable = false,
                LastName = "Last Name",
                OrganizationName = "Charity " + charityId,
                Phone = "123-456-7890",
                PostalCode = "75254",
                State = "TX",
                Website = "http://www.google.com/",
                YearsService = 0
            };

            _repository.Add(charity);

            return CreateResult.SuccessfullyCreated;
        }
    }
}
