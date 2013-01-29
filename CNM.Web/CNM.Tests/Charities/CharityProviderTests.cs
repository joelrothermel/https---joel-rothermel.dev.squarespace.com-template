using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CNM.Charities;
using CNM.Charities.Repositories;
using Moq;
using CNM.Models;

namespace CNM.Tests.Charities
{
    /// <summary>
    /// Summary description for CharityProviderTests
    /// </summary>
    [TestClass]
    public class CharityProviderTests : TestBase
    {
        protected CharityProvider _provider = null;
        protected Mock<CharityRepository> _mockRepository = null;

        [TestInitialize]
        public void InitializeTests()
        {
            _mockRepository = Mock<CharityRepository>();

            _provider = new CharityProvider(_mockRepository.Object);
        }

        [TestMethod]
        public void GetAllCharities_ReturnsCharities()
        {
            _mockRepository.Setup(x => x.GetAllCharities()).Returns(new List<Charity>
            {
                new Charity { CharityId = "1" },
                new Charity { CharityId = "2" }
            });

            var charities = _provider.GetAllCharities();

            charities.IsNotNull();
            charities.Count().IsEqualTo(2);
            charities.First().CharityId.IsEqualTo("1");
        }

        [TestMethod]
        public void GetCharityFor_ReturnsSpecificCharity()
        {
            _mockRepository.Setup(x => x.GetAllCharities()).Returns(new List<Charity>
            {
                new Charity { CharityId = "1" },
                new Charity { CharityId = "2" }
            });

            var charity = _provider.GetCharityFor("2");

            charity.IsNotNull();
            charity.CharityId.IsEqualTo("2");
        }

        [TestMethod]
        public void GetCharityFor_ReturnsNull_IfNoCharityExists()
        {
            _mockRepository.Setup(x => x.GetAllCharities()).Returns(new List<Charity>
            {
                new Charity { CharityId = "1" },
                new Charity { CharityId = "2" }
            });

            var charity = _provider.GetCharityFor("3");

            charity.IsNull();
        }
    }
}
