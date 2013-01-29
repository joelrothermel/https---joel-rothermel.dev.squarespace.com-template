using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CNM.Repositories;
using CNM.Models;

namespace CNM.Services
{
    /// <summary>
    /// A service that is used by the board member to search for charities
    /// </summary>
    public class SearchService
    {
        private readonly SearchRepository _repository;

        public SearchService(SearchRepository repository)
        {
            _repository = repository;
        }


        public virtual IEnumerable<Charity> GetMatchingCharities(SearchCriteria criteria)
        {
            var objResults = new SearchResults();

            return null;
        }

        public virtual IEnumerable<BoardMember> GetMatchingBoardMembers(SearchCriteria criteria)
        {
            var objResults = new SearchResults();

            return null;
        }
    }
}
