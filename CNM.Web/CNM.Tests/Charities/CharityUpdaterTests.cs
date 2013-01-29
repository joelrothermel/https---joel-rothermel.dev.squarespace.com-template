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
    public class CharityUpdaterTests : TestBase
    {
        protected CharityUpdater _updater = null;
        protected Mock<CharityRepository> _mockRepository = null;
        protected Mock<CharityProvider> _mockCharityProvider = null;

        [TestInitialize]
        public void InitializeTests()
        {
            _mockRepository = Mock<CharityRepository>();
            _mockCharityProvider = Mock<CharityProvider>();

            _updater = new CharityUpdater(_mockRepository.Object, _mockCharityProvider.Object);
        }

        [TestMethod]
        public void Update_CharityAlreadyExists_ReturnsError()
        {
            var charity = new Charity
            {
                OrganizationName = "SomeOrg",
                CharityId = "2"
            };

            _mockCharityProvider.Setup(x => x.DoesCharityExist("SomeOrg", "2")).Returns(true);

            var result = _updater.Update(charity, null, null);

            result.IsEqualTo(UpdateResult.ItemAlreadyExists);
            _mockRepository.Verify(x => x.Update(charity, null, null), Times.Never());
        }

        [TestMethod]
        public void Update_UpdatesValues()
        {
            _mockRepository.Setup(x => x.GetAllCharities()).Returns(new List<Charity>
            {
                new Charity { OrganizationName = "SomeOrg2" }
            });

            var charity = new Charity
            {
                OrganizationName = "SomeOrg"
            };

            var result = _updater.Update(charity, null, null);

            result.IsEqualTo(UpdateResult.Successful);
            _mockRepository.Verify(x => x.Update(charity, null, null), Times.Once());
        }
    }
}
