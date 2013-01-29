using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CNM.Models;
using CNM.Web.ViewModels;
using CNM.Web.Mappers;
using CNM.Services;
using CNM.Searching;
using CNM.Charities;
using CNM.Web.Routing;
using CNM.Web.Controllers;
using CNM.Web.Framework;
using CNM.Skills;
using CNM.ServiceAreas;

namespace CNM.Web.Controllers
{
    public class BoardMemberController : CnmControllerBase
    {
        private BoardMemberProfileService _boardMemberProfileService;
        protected SkillsMapper _skillsMapper;
        protected ServiceAreaMapper _serviceAreaMapper;
        protected SkillsRepository _skillRepository = null;
        protected ServiceAreaRepository _serviceAreaRepository = null;

        public BoardMemberController(BoardMemberProfileService profileService, SkillsMapper skillsMapper, ServiceAreaMapper serviceAreaMapper, SkillsRepository skillRepository, ServiceAreaRepository areaRepository)
        {
            _boardMemberProfileService = profileService;
            _skillsMapper = skillsMapper;
            _serviceAreaMapper = serviceAreaMapper;
            _skillRepository = skillRepository;
            _serviceAreaRepository = areaRepository;
        }

        [AnonymousOnly]
        public ActionResult New()
        {
            //load profile create
            BoardMemberProfileViewModel objViewModel = new BoardMemberProfileViewModel() 
                                                        { BoardMember = new BoardMember(),
                                                          SelectedSkills = Enum.GetValues(typeof(Skill)).OfType<Skill>().ToList(),
                                                          SelectedAreas = Enum.GetValues(typeof(ServiceArea)).OfType<ServiceArea>().ToList()
                                                        };
            return View(objViewModel);
        }

        [HttpPost, AnonymousOnly]
        public ActionResult New(BoardMemberProfileViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.BoardMember.AvailableSkills = _skillsMapper.MapSkills(model.SelectedSkills);
                model.BoardMember.Interests = _serviceAreaMapper.MapServiceAreas(model.SelectedAreas);

                var encryptor = new Encryptor();
                model.BoardMember.Password = encryptor.Encrypt(model.BoardMember.Password);
                var result = _boardMemberProfileService.CreateBoardMember(model.BoardMember, model.SelectedSkills, model.SelectedAreas);

                switch (result)
                {
                    case CreateResult.SuccessfullyCreated:
                        {
                            return RedirectTo.Account.Login();
                        }
                    case CreateResult.ItemAlreadyExists:
                        ModelState.AddModelError("Email", "A Member with that Email already exists.");
                        break;
                }
            }

            model.SelectedSkills = Enum.GetValues(typeof(Skill)).OfType<Skill>().ToList();
            model.SelectedAreas = Enum.GetValues(typeof(ServiceArea)).OfType<ServiceArea>().ToList();
            model.CurrentAreas = new List<ServiceAreaEntity>();
            model.CurrentSkills = new List<SkillEntity>();

            return View(model);
        }

        [RequiresAuthentication(ValidRole=UserAuthenticationType.Board)]
        public ActionResult Edit(int? id)
        {
            if (id.HasValue && LoggedInUser.Type != UserAuthenticationType.UberMegaSuperUltraUser)
                return RedirectTo.Account.Login();

            int boardMemberToSelect = id.HasValue ? id.Value : LoggedInUser.BoardMemberId.Value;

            var Member = _boardMemberProfileService.GetBoardMember(boardMemberToSelect);
            BoardMemberProfileViewModel objViewModel = new BoardMemberProfileViewModel()
            {
                BoardMember = Member,
                SelectedSkills = Enum.GetValues(typeof(Skill)).OfType<Skill>().ToList(),
                SelectedAreas = Enum.GetValues(typeof(ServiceArea)).OfType<ServiceArea>().ToList(),
                CurrentSkills = _skillRepository.GetSkillsFor(boardMemberToSelect).ToList(),
                CurrentAreas = _serviceAreaRepository.GetServiceAreasFor(boardMemberToSelect).ToList()
            };
        
            return View(objViewModel);
        }

        [HttpPost, RequiresAuthentication(ValidRole = UserAuthenticationType.Board)]
        public ActionResult Edit(BoardMemberProfileViewModel model)
        {           
            if (ModelState.IsValid)
            {
                model.BoardMember.AvailableSkills = _skillsMapper.MapSkills(model.SelectedSkills);
                model.BoardMember.Interests = _serviceAreaMapper.MapServiceAreas(model.SelectedAreas);

                //This is to keep them from submitting a blank password.
                if (!String.IsNullOrWhiteSpace(model.BoardMember.Password))
                {
                    var encryptor = new Encryptor();
                    model.BoardMember.Password = encryptor.Encrypt(model.BoardMember.Password);
                }
                var result = _boardMemberProfileService.UpdateBoardMember(model.BoardMember, model.SelectedSkills, model.SelectedAreas);

                switch (result)
                {
                    case UpdateResult.Successful:
                        return RedirectTo.Search.NonProfits();
                    case UpdateResult.ItemAlreadyExists:
                        ModelState.AddModelError("Email", "A Member with that name already exists.");
                        break;
                }                
            }

            return View(model);
        }
    }
}
