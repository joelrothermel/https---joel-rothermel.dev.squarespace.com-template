using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CNM.Models;
using CNM.Searching.Repositories;

namespace CNM.Searching
{
    public class SearchingProvider
    {
        protected SearchResultScorer _resultScorer = null;
        protected SearchingRepository _repository = null;

        protected int _itemsPerPage = 10;

        public SearchingProvider(SearchResultScorer resultScorer, SearchingRepository repository)
        {
            _resultScorer = resultScorer;
            _repository = repository;
        }

        public virtual SearchResult<string> GetCharitySearchResultsFor(SearchCriteria searchCriteria, int page)
        {
            SearchResult<string> result = new SearchResult<string>
            {
                Page = page,
            };

            var interimResults = _repository.GetCharitySearchResultsFor(searchCriteria);

            var searchValues = interimResults.AsParallel().Select(rawResult => new { Id = rawResult.CharityId, Score = CreateScore(rawResult, searchCriteria) });

            result.MaxNumberOfPages = Math.Ceiling((double)searchValues.Count() / (double)_itemsPerPage);

            result.SearchIds = searchValues.GroupBy(x => x.Score)
                .OrderByDescending(x => x.Key)
                .Where(x => x.Key != 0)
                .SelectMany(x => x)
                //.Skip(_itemsPerPage * page)
                .Take(500)
                .Select(x => x.Id)
                .ToList();

            return result;
        }

        protected virtual int CreateScore(CharitySearchResult result, SearchCriteria searchCriteria)
        {
            return _resultScorer.ScoreSearchCriteriaRelevance(result, searchCriteria.Skills, searchCriteria.ServiceAreas);
        }

        protected virtual int CreateScore(BoardMemberSearchResult result, SearchCriteria searchCriteria)
        {
            return _resultScorer.ScoreSearchCriteriaRelevance(result, searchCriteria.Skills, searchCriteria.ServiceAreas);
        }

        public virtual SearchResult<int> GetBoardMemberSearchResultsFor(SearchCriteria searchCriteria, int page)
        {
            SearchResult<int> result = new SearchResult<int>
            {
                Page = page,
            };

            var interimResults = _repository.GetBoardMemberSearchResultsFor(searchCriteria);

            var searchValues = interimResults.AsParallel().Select(rawResult => new { Id = rawResult.BoardMemberId, Score = CreateScore(rawResult, searchCriteria) });

            result.MaxNumberOfPages = Math.Ceiling((double)searchValues.Count() / (double)_itemsPerPage);

            result.SearchIds = searchValues.GroupBy(x => x.Score)
                .OrderByDescending(x => x.Key)
                .Where(x => x.Key != 0)
                .SelectMany(x => x)
                //.Skip(_itemsPerPage * page)
                .Take(500)
                .Select(x => x.Id)
                .ToList();

            return result;
        }
    }
}
