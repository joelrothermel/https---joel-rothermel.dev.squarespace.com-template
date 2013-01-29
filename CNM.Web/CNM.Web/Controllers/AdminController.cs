using System;
using System.Web.Mvc;
using CNM.Charities.Repositories;
using CNM.Models;
using CNM.ServiceAreas;
using CNM.Services;
using CNM.Skills;
using CNM.Web.Framework;
using CNM.Web.ViewModels;

namespace CNM.Web.Controllers
{
    public class AdminController : CnmControllerBase
    {
        public AdminController(BoardMemberProfileService boardMemberProfileService, CharityRepository charityRepository)
        {
            _boardMemberProfileService = boardMemberProfileService;
            _charityRepository = charityRepository;
        }

        private BoardMemberProfileService _boardMemberProfileService;
        private CharityRepository _charityRepository;

        [RequiresAuthentication(ValidRole = UserAuthenticationType.UberMegaSuperUltraUser)]
        public ActionResult Index()
        {
            var vm = new ViewModelBase();
            return View(vm);
        }

        public ActionResult FindBoardMember(string id)
        {
            var boardMember = _boardMemberProfileService.GetBoardMember(id);

            if (boardMember == null)
            {
                return Json(new
                {
                    id = 0,
                    enabled = false
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new
                {
                    id = boardMember.BoardMemberId,
                    enabled = boardMember.IsSearchable
                }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult ToggleStatus(int id)
        {
            var boardMember = _boardMemberProfileService.GetBoardMember(id);

            boardMember.IsSearchable = !boardMember.IsSearchable;
            _boardMemberProfileService.UpdateBoardMember(boardMember, null, null);

            return Json(new { winning = "true" });
        }

        [HttpPost]
        public ActionResult CreateCharity(string id, string password)
        {
            var encryptor = new Encryptor();
            password = encryptor.Encrypt(password);

            var charity = new Charity
                {
                    CharityId = id,
                    Password = password,
                    Address1 = "__",
                    Address2 = "__",
                    City = "__",
                    State = "__",
                    PostalCode = "__",
                    Essay = "__",
                    Email = "__",
                    FirstName = "__",
                    IsSearchable = false,
                    LastName = "__",
                    OrganizationName = "charity" + id,
                    Phone = "__",
                    Website = "__",
                    YearsService = 0
                };

            _charityRepository.Add(charity);

            return Json(new { awesome = "clearly true" });
        }
    }
}
