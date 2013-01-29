using System;
using System.Collections.Generic;
using CNM.Charities;
using CNM.Charities.Repositories;
using CNM.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CNM.Tests.Charities
{
    [TestClass]
    public class CharityCreatorTests : TestBase
    {
        protected CharityCreator _creator = null;
        protected Mock<CharityRepository> _mockRepository = null;
        protected Mock<CharityProvider> _mockCharityProvider = null;

        [TestInitialize]
        public void InitializeTests()
        {
            _mockRepository = Mock<CharityRepository>();
            _mockCharityProvider = Mock<CharityProvider>();

            _creator = new CharityCreator(_mockRepository.Object, _mockCharityProvider.Object);
        }

        [TestMethod]
        public void Save_CharityAlreadyExists_ReturnsError()
        {
            Charity charity = new Charity
            {
                CharityId = "2",
                OrganizationName = "SomeOrg"
            };

            _mockCharityProvider.Setup(x => x.DoesCharityExist("SomeOrg", "2")).Returns(true);

            var result = _creator.Save(charity);

            result.IsEqualTo(CreateResult.ItemAlreadyExists);

            _mockRepository.Verify(x => x.Add(charity), Times.Never());
        }

        [TestMethod]
        public void Save_PersistsTheCharity_SavesIt()
        {
            Charity charity = new Charity
            {
                CharityId = "2",
                OrganizationName = "SomeOrg"
            };

            _mockRepository.Setup(x => x.GetAllCharities()).Returns(new List<Charity>
            {
               
            });

            var result = _creator.Save(charity);

            result.IsEqualTo(CreateResult.SuccessfullyCreated);

            _mockRepository.Verify(x => x.Add(charity), Times.Once());
        }
    }
}
