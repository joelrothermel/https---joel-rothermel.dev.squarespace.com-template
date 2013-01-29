using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CNM.Models;
using CNM.Searching.Procedures;
using CNM.Sql;

namespace CNM.Searching.Repositories
{
    public class SearchingRepository
    {
        public virtual void UpdateSearchIndexForCharity(string charityId)
        {
            SyncCharitySearch updateProcedure = new SyncCharitySearch();
            updateProcedure.Execute(charityId);
        }

        public virtual IEnumerable<CharitySearchResult> GetCharitySearchResultsFor(SearchCriteria searchCriteria)
        {
            using (var context = new SqlDataContext())
            {
                if (!string.IsNullOrEmpty(searchCriteria.State) && !string.IsNullOrEmpty(searchCriteria.City))
                {
                    return context.CharitySearchIndex.Where(x => x.State == searchCriteria.State && x.City == searchCriteria.City).ToList();
                }
                else if (!string.IsNullOrEmpty(searchCriteria.PostalCode))
                {
                    return context.CharitySearchIndex.Where(x => x.Zip == searchCriteria.PostalCode).ToList();
                }
                else {
                    return context.CharitySearchIndex.Take(10000).ToList();
                }
            }   
            
        }

        public virtual IEnumerable<BoardMemberSearchResult> GetBoardMemberSearchResultsFor(SearchCriteria searchCriteria)
        {
            using (var context = new SqlDataContext())
            {
                if (!string.IsNullOrEmpty(searchCriteria.State) && !string.IsNullOrEmpty(searchCriteria.City))
                {
                    return context.BoardMemberSearchIndex.Where(x => x.State == searchCriteria.State && x.City == searchCriteria.City).ToList();
                }
                else if (!string.IsNullOrEmpty(searchCriteria.PostalCode))
                {
                    return context.BoardMemberSearchIndex.Where(x => x.Zip == searchCriteria.PostalCode).ToList();
                }
                else
                {
                    return context.BoardMemberSearchIndex.Take(10000).ToList();
                }
            }
        }
    }
}
