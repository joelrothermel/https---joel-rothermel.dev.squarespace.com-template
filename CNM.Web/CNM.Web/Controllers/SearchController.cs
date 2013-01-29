using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CNM.Charities;
using CNM.Geography;
using CNM.Searching;
using CNM.Services;
using CNM.Web.Framework;
using CNM.Web.Mappers;
using CNM.Web.ViewModels.Search;

namespace CNM.Web.Controllers
{
    public class SearchController : CnmControllerBase
    {
        protected SearchingProvider _searchingProvider = null;
        protected SearchCriteriaMapper _searchCriteriaMapper = null;
        protected BoardMemberProfileService _boardMemberProvider = null;
        protected CharityProvider _charityProvider = null;
        protected GeoProvider _geoProvider = null;
        protected CNM.ServiceAreas.ServiceAreaRepository _serviceAreaRepo = null;
        protected CNM.Skills.SkillsRepository _skillrepo = null;
        protected SkillsMapper _skillsMapper;
        protected ServiceAreaMapper _serviceAreaMapper;

        public SearchController(SkillsMapper skillsMapper, ServiceAreaMapper serviceAreaMapper, CNM.Skills.SkillsRepository skillrepo, CNM.ServiceAreas.ServiceAreaRepository serviceAreaRepo, GeoProvider geoProvider, SearchingProvider searchingProvider, SearchCriteriaMapper searchCriteriaMapper, BoardMemberProfileService boardMemberProvider, CharityProvider charityProvider)
        {
            _geoProvider = geoProvider;
            _searchingProvider = searchingProvider;
            _searchCriteriaMapper = searchCriteriaMapper;
            _boardMemberProvider = boardMemberProvider;
            _charityProvider = charityProvider;
            _serviceAreaRepo = serviceAreaRepo;
            _skillrepo = skillrepo;
            _skillsMapper = skillsMapper;
            _serviceAreaMapper = serviceAreaMapper;

        }

        [RequiresAuthentication(ValidRole=UserAuthenticationType.Charity)]
        public ActionResult BoardMembers()
        {
            var vm = new SearchFormViewModel();
            
            vm.States = _geoProvider.GetStates().ToArray();
            vm.Skills = Enum.GetValues(typeof(CNM.Models.Skill)).OfType<CNM.Models.Skill>().ToArray();
            vm.ServiceAreas = Enum.GetValues(typeof(CNM.Models.ServiceArea)).OfType<CNM.Models.ServiceArea>().ToArray();
            vm.SelectedServiceAreas = new List<CNM.Models.ServiceArea>();
            vm.SelectedSkills = new List<CNM.Models.Skill>();
            
            return View(vm);
        }

        [RequiresAuthentication(ValidRole=UserAuthenticationType.Board)]
        public ActionResult NonProfits()
        {
            var vm = new SearchFormViewModel();

            vm.States = _geoProvider.GetStates().ToArray();
            vm.Skills = Enum.GetValues(typeof(CNM.Models.Skill)).OfType<CNM.Models.Skill>().ToArray();
            vm.ServiceAreas = Enum.GetValues(typeof(CNM.Models.ServiceArea)).OfType<CNM.Models.ServiceArea>().ToArray();
            vm.SelectedServiceAreas = new List<CNM.Models.ServiceArea>();
            vm.SelectedSkills = new List<CNM.Models.Skill>();
            

            return View(vm);
        }

        [HttpPost, RequiresAuthentication(ValidRole=UserAuthenticationType.Charity)] // [IsAjax]
        public ActionResult BoardMembers(SearchFormViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return Json(new BoardMemberSearchResultsViewModel { Status = "OK", SearchResults = new List<BoardMemberSearchResultItemViewModel>() });
            }

            var searchCriteria = _searchCriteriaMapper.MapToDomainModel(vm);

            var searchResults = _searchingProvider.GetBoardMemberSearchResultsFor(searchCriteria, GetCurrentPage(vm));
            var boardMembers = _boardMemberProvider.GetSetOfBoardMembers(searchResults.SearchIds).Select(z =>
                new BoardMemberSearchResultItemViewModel
                {
                    
                    FirstName = z.FirstName,
                    LastName = z.LastName,
                    Address1 = z.Address1,
                    Address2 = z.Address2,
                    City = z.City,
                    Email = z.Email,
                    State = z.State,
                    Essay = z.MissionStatement
                }).ToList();

            var viewModel = new BoardMemberSearchResultsViewModel
            {
                Status = "OK",
                SearchResults = boardMembers,
                MaxPageCount = searchResults.MaxNumberOfPages
            };

            return Json(viewModel, "text/plain");
        }

        private static int GetCurrentPage(SearchFormViewModel vm)
        {
            return (vm.PageNumber.HasValue) ? vm.PageNumber.Value : 0;
        }

        [HttpPost, RequiresAuthentication(ValidRole = UserAuthenticationType.Board)] // [IsAjax]
        public ActionResult NonProfits(SearchFormViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return Json(new CharitySearchResultsViewModel { Status = "OK", SearchResults = new List<CharitySearchResultItemViewModel>() });
            }

            var searchCriteria = _searchCriteriaMapper.MapToDomainModel(vm);

            var searchResults = _searchingProvider.GetCharitySearchResultsFor(searchCriteria, GetCurrentPage(vm));
            var charities = _charityProvider.GetSetOfCharities(searchResults.SearchIds).Select(z =>
                new CharitySearchResultItemViewModel
                {
                    OrganizationName = z.OrganizationName,
                    Address1 = z.Address1,
                    Address2 = z.Address2,
                    City = z.City,
                    Email = z.Email,
                     State = z.State,
                     Website = z.Website,
                     Essay = z.Essay
                }).ToList();

            var viewModel = new CharitySearchResultsViewModel
            {
                Status = "OK",
                SearchResults = charities,
                MaxPageCount = searchResults.MaxNumberOfPages
            };

            return Json(viewModel, "text/plain");   
        }
    }
}
