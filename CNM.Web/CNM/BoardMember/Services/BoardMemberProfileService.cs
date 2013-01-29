using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CNM.Models;
using CNM.Repositories;
using CNM.Charities;

namespace CNM.Services
{
    /// <summary>
    /// A service used for creating/editing a board member profile
    /// </summary>
    public class BoardMemberProfileService
    {
        private readonly BoardMemberProfileRepository _repository;

        public BoardMemberProfileService(BoardMemberProfileRepository repository)
        {
            _repository = repository;
        }

        public virtual IEnumerable<BoardMember> GetAllBoardMembers()
        {
            return _repository.GetAllBoardMembers();
        }

        public virtual IEnumerable<BoardMember> GetSetOfBoardMembers(IEnumerable<int> boardMemberIds)
        {
            return _repository.GetSetOfBoardMembers(x => boardMemberIds.Contains(x.BoardMemberId));
        }

        public virtual BoardMember GetBoardMember(int memberId)
        {
            return _repository.GetBoardMember(memberId);          
        }

        public virtual BoardMember GetBoardMember(string email)
        {
            return _repository.GetBoardMember(email);
        }

        public virtual CreateResult CreateBoardMember(BoardMember member, IEnumerable<Skill> skills, IEnumerable<ServiceArea> serviceAreas)
        {
            if (_repository.GetSetOfBoardMembers(x => x.Email.ToLower() == member.Email.ToLower()).Any())
                return CreateResult.ItemAlreadyExists;

            _repository.Add(member, skills, serviceAreas);

            return CreateResult.SuccessfullyCreated;
        }

        public virtual UpdateResult UpdateBoardMember(BoardMember member, IEnumerable<Skill> skills, IEnumerable<ServiceArea> serviceAreas)
        {
            if (_repository.GetSetOfBoardMembers(x => x.Email.ToLower() == member.Email.ToLower() && x.BoardMemberId != member.BoardMemberId).Any())
                return UpdateResult.ItemAlreadyExists;

            _repository.Update(member, skills, serviceAreas);

            return UpdateResult.Successful;
        }
    }
}
