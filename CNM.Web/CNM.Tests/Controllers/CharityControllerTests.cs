using System;
using System.Web.Mvc;
using CNM.Charities;
using CNM.Models;
using CNM.Searching;
using CNM.Web.Controllers;
using CNM.Web.Mappers;
using CNM.Web.Routing;
using CNM.Web.ViewModels.NonProfit;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CNM.Tests.Controllers
{
    [TestClass]
    public class CharityControllerTests : TestBase
    {
        protected NonProfitController _controller = null;
        protected Mock<CharityProvider> _mockCharityProvider = null;
        protected Mock<CharityUpdater> _mockCharityUpdater = null;
        protected Mock<CharityCreator> _mockCharityCreator = null;
        protected Mock<SkillsMapper> _mockSkillsMapper = null;
        protected Mock<ServiceAreaMapper> _mockServiceAreaMapper = null;

        [TestInitialize]
        public void InitializeTests()
        {
            _mockCharityUpdater = Mock<CharityUpdater>();
            _mockCharityCreator = Mock<CharityCreator>();
            _mockCharityProvider = Mock<CharityProvider>();

            _controller = new NonProfitController(_mockCharityCreator.Object, _mockCharityUpdater.Object, _mockCharityProvider.Object,_mockSkillsMapper.Object,_mockServiceAreaMapper.Object, null, null);
        }

        [TestMethod]
        public void New_ReturnsView()
        {
            var viewResult = _controller.New().EnsureIs<ViewResult>();
            var model = viewResult.Model.EnsureIs<CharityContainerViewModel>();

            model.IsNotNull();
        }

        [TestMethod]
        public void NewPost_ValidationErrors_ReturnsView()
        {
            _controller.ModelState.AddModelError("Test", "Test");

            var charity = new Charity
            {
                OrganizationName = "Stuff"
            };

            var viewResult = _controller.New(new CharityContainerViewModel { Charity = charity }).EnsureIs<ViewResult>();
            var model = viewResult.Model.EnsureIs<CharityContainerViewModel>();
            model.Charity.IsEqualTo(charity);

            _mockCharityCreator.Verify(x => x.Save(charity), Times.Never());
        }

        [TestMethod]
        public void NewPost_OrganizationNameExists_ReturnsView()
        {
            var charity = new Charity
            {
                OrganizationName = "Stuff"
            };

            _mockCharityCreator.Setup(x => x.Save(charity)).Returns(CreateResult.ItemAlreadyExists);

            var viewResult = _controller.New(new CharityContainerViewModel { Charity = charity }).EnsureIs<ViewResult>();
            var model = viewResult.Model.EnsureIs<CharityContainerViewModel>();
            model.Charity.IsEqualTo(charity);
        }

        [TestMethod]
        public void NewPost_Success_ReturnsRedirect()
        {
            var charity = new Charity
            {
                OrganizationName = "Stuff"
            };

            _mockCharityCreator.Setup(x => x.Save(charity)).Returns(CreateResult.SuccessfullyCreated);

            var redirectResult = _controller.New(new CharityContainerViewModel { Charity = charity }).EnsureIs<StronglyNamedRouteResult>();
            redirectResult.RouteValues["controller"].ToString().ToLower().IsEqualTo("charity");
            redirectResult.RouteValues["action"].ToString().ToLower().IsEqualTo("search");
        }
    }
}