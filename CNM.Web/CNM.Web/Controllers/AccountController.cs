using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CNM.Charities;
using CNM.Charities.Repositories;
using CNM.Repositories;
using CNM.Web.Framework;
using CNM.Web.ViewModels;
using CNM.Web.ViewModels.Account;

namespace CNM.Web.Controllers
{
    public class AccountController : CnmControllerBase
    {
        public AccountController(FormsAuthFacade formsAuth, CharityRepository charityRepository, BoardMemberProfileRepository boardMemberRepository, CharityCreator charityCreator)
        {
            _formsAuth = formsAuth;
            _charityRepository = charityRepository;
            _boardMemberRepository = boardMemberRepository;
            _charityCreator = charityCreator;
        }

        private FormsAuthFacade _formsAuth;
        private CharityRepository _charityRepository;
        private BoardMemberProfileRepository _boardMemberRepository;
        private CharityCreator _charityCreator = null;

        [AnonymousOnly]
        public ActionResult Login()
        {
            var vm = new LoginViewModel();

            if (LoggedInUser != null)
            {
                if (LoggedInUser.Type == UserAuthenticationType.Board)
                {
                    var boardMember = _boardMemberRepository.GetBoardMember(LoggedInUser.BoardMemberId.Value);

                    if (boardMember == null)
                        return RedirectTo.BoardMember.New();

                    return RedirectTo.Search.NonProfits();
                    
                }
                else
                {
                    var loggedInCharity = _charityRepository.GetSpecificCharity(x => x.CharityId == LoggedInUser.CharityId);

                    if (loggedInCharity == null)
                        return RedirectTo.NonProfit.New();

                    return RedirectTo.Search.BoardMembers();
                }
            }

            return View(vm);
        }

        [HttpPost, AnonymousOnly]
        public ActionResult Login(LoginViewModel vm)
        {
            var encryptor = new Encryptor();
            if (!String.IsNullOrEmpty(vm.BoardPassword))
                vm.BoardPassword = encryptor.Encrypt(vm.BoardPassword);
            if (!String.IsNullOrWhiteSpace(vm.CharityPassword))
                vm.CharityPassword = encryptor.Encrypt(vm.CharityPassword);

            if (ModelState.IsValid)
            {
                ActionResult result = null;
                string ticket = null;

                if (vm.Type == "board")
                {
                    var boardMemberId = _boardMemberRepository.ValidateLogin(vm.BoardEmail, vm.BoardPassword);

                    if (!boardMemberId.HasValue)
                    {
                        ModelState.AddModelError("BoardPassword", "Invalid login.");
                        return View(vm);
                    }

                    ticket = _formsAuth.SignIn(vm.BoardEmail, UserAuthenticationType.Board, string.Empty, boardMemberId);

                    var boardMember = _boardMemberRepository.GetBoardMember(boardMemberId.Value);

                    if (boardMemberId == null)
                    {
                        result = RedirectTo.BoardMember.New();
                    }
                    else
                    {
                        result = RedirectTo.Search.NonProfits();
                    }
                }
                else
                {
                    var charityId = _charityRepository.ValidateLogin(vm.CharityUsername, vm.CharityPassword);

                    if (string.IsNullOrWhiteSpace(charityId))
                    {
                        ModelState.AddModelError("CharityPassword", "Invalid login.");
                        return View(vm);
                    }

                    if (vm.CharityUsername == "61903")
                        ticket = _formsAuth.SignIn(vm.CharityUsername, UserAuthenticationType.UberMegaSuperUltraUser, charityId, null);
                    else
                        ticket = _formsAuth.SignIn(vm.CharityUsername, UserAuthenticationType.Charity, charityId, null);

                    var charity = _charityRepository.GetSpecificCharity(x => x.CharityId == charityId);

                    if (charity == null)
                        result = RedirectTo.NonProfit.New();
                    else
                    {
                        result = RedirectTo.Search.BoardMembers();
                    }
                }

                var cookie = new HttpCookie(FormsAuthFacade.COOKIE_NAME, ticket);
                cookie.Expires = DateTime.Now.AddDays(30);
                Response.Cookies.Add(cookie);
                return result;
            }

            return View(vm);
        }

        public ActionResult Logout()
        {
            var cookie = Request.Cookies[FormsAuthFacade.COOKIE_NAME];
            if (cookie != null)
            {
                cookie.Expires = DateTime.Now.AddDays(-1);

                Response.Cookies.Add(cookie);
            }

            return RedirectTo.Account.Login();
        }
    }
}