using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CNM.Charities;
using CNM.Models;
using CNM.Web.ViewModels;
using CNM.Web.Framework;
using CNM.Searching;
using CNM.Web.ViewModels.NonProfit;
using CNM.Web.Mappers;
using CNM.Skills;
using CNM.ServiceAreas;

namespace CNM.Web.Controllers
{
    public class NonProfitController : CnmControllerBase
    {
        protected CharityCreator _charityCreator = null;
        protected CharityUpdater _charityUpdater = null;
        protected CharityProvider _charityProvider = null;
        protected SkillsMapper _skillsMapper;
        protected ServiceAreaMapper _serviceAreaMapper;
        protected SkillsRepository _skillRepository = null;
        protected ServiceAreaRepository _serviceAreaRepository = null;

        public NonProfitController(CharityCreator charityCreator, CharityUpdater charityUpdater, CharityProvider charityProvider, SkillsMapper skillsMapper, ServiceAreaMapper serviceAreaMapper,
            SkillsRepository skillRepository, ServiceAreaRepository areaRepository)
        {
            _charityCreator = charityCreator;
            _charityUpdater = charityUpdater;
            _charityProvider = charityProvider;
            _skillsMapper = skillsMapper;
            _serviceAreaMapper = serviceAreaMapper;
            _skillRepository = skillRepository;
            _serviceAreaRepository = areaRepository;
        }

        [RequiresAuthentication(ValidRole=UserAuthenticationType.Charity)]
        public ActionResult New()
        {
            var vm = new CharityContainerViewModel()
            {
                Charity = new Charity() ,
                SelectedSkills = Enum.GetValues(typeof(Skill)).OfType<Skill>().ToList(),
                SelectedAreas = Enum.GetValues(typeof(ServiceArea)).OfType<ServiceArea>().ToList(),
                CurrentAreas = new List<ServiceAreaEntity>(),
                CurrentSkills = new List<SkillEntity>()
            };

            return View(vm);
        }

        [HttpPost, RequiresAuthentication(ValidRole = UserAuthenticationType.Charity)]
        public ActionResult New(CharityContainerViewModel vm)
        {
            vm.Charity.CharityId = LoggedInUser.CharityId;

            if (string.IsNullOrWhiteSpace(vm.Charity.Password))
            {
                ModelState.AddModelError("Charity.Password", "You must select a password");
            }

            if (ModelState.IsValid)
            {
                var encryptor = new Encryptor();
                vm.Charity.Password = encryptor.Encrypt(vm.Charity.Password);
                var result = _charityUpdater.Update(vm.Charity, vm.SelectedSkills, vm.SelectedAreas);

                switch (result)
                {
                    case UpdateResult.Successful:
                        return RedirectTo.Search.BoardMembers();
                    case UpdateResult.ItemAlreadyExists:
                        ModelState.AddModelError("OrganizationName", "An organization with that name already exists.");
                        break;
                }
            }

            vm.SelectedSkills = Enum.GetValues(typeof(Skill)).OfType<Skill>().ToList();
            vm.SelectedAreas = Enum.GetValues(typeof(ServiceArea)).OfType<ServiceArea>().ToList();
            vm.CurrentAreas = new List<ServiceAreaEntity>();
            vm.CurrentSkills = new List<SkillEntity>();

            return View(vm);
        }

        [RequiresAuthentication(ValidRole=UserAuthenticationType.Charity)]
        public ActionResult Edit()
        {
            var charity = _charityProvider.GetCharityFor(LoggedInUser.CharityId);
            RemoveDefaultValues(charity);

            var vm = new CharityContainerViewModel
            {
                Charity = charity,
                SelectedSkills = Enum.GetValues(typeof(Skill)).OfType<Skill>().ToList(),
                SelectedAreas = Enum.GetValues(typeof(ServiceArea)).OfType<ServiceArea>().ToList()
            };

            vm.CurrentSkills = _skillRepository.GetSkillsFor(LoggedInUser.CharityId).ToList();
            vm.CurrentAreas = _serviceAreaRepository.GetServiceAreasFor(LoggedInUser.CharityId).ToList();
            return View(vm);
        }

        private void RemoveDefaultValues(Charity charity)
        {
            if (charity.Phone == "__" && charity.FirstName == "__")
            {
                charity.Address1 = String.Empty;
                charity.Address2 = String.Empty;
                charity.City = String.Empty;
                charity.State = String.Empty;
                charity.PostalCode = String.Empty;
                charity.Essay = String.Empty;
                charity.Email = String.Empty;
                charity.FirstName = String.Empty;
                charity.LastName = String.Empty;
                charity.Phone = String.Empty;
                charity.Website = String.Empty;
            }
        }

        [HttpPost, RequiresAuthentication(ValidRole = UserAuthenticationType.Charity)]
        public ActionResult Edit(CharityContainerViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var charity = vm.Charity;
                charity.CharityId = LoggedInUser.CharityId;

                var encryptor = new Encryptor();
                charity.Password = encryptor.Encrypt(charity.Password);
                var result = _charityUpdater.Update(charity, vm.SelectedSkills, vm.SelectedAreas);

                switch (result)
                {
                    case UpdateResult.Successful:
                        return RedirectTo.Search.BoardMembers();
                    case UpdateResult.ItemAlreadyExists:
                        ModelState.AddModelError("OrganizationName", "An organization with that name already exists.");
                        break;
                }
            }

            return View(vm);
        }
    }
}
