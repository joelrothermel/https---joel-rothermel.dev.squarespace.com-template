using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CNM.Models;
 using CNM.Web.ViewModels;
using CNM.Web.ViewModels.Search;

namespace CNM.Web.Mappers
{
    public class SearchCriteriaMapper
    {
        public virtual SearchCriteria MapToDomainModel(SearchFormViewModel viewModel)
        {
            SearchCriteria objSearchCriteria = new SearchCriteria
            {
                Skills = viewModel.SelectedSkills,
                ServiceAreas = viewModel.SelectedServiceAreas,
                City = viewModel.City,
                PostalCode = viewModel.PostalCode
            };

            return objSearchCriteria;
        }
    }
}