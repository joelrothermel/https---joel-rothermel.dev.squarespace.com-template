using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using CNM.Configuration;
using CNM.Models;

namespace CNM.Searching
{
    public class SearchResultScorer
    {
        public virtual int ScoreSearchCriteriaRelevance(CharitySearchResult rawSearchResult, IEnumerable<Skill> skills, IEnumerable<ServiceArea> serviceAreas)
        {
            var type = typeof(CharitySearchResult);
            var score = 0;
            int requiredScore = 0;

            foreach (var property in type.GetProperties().Where(x => x.CanRead))
            {
                var skillAttribute = property.GetCustomAttributes(true).OfType<SearchIndexSkillMappingAttribute>().FirstOrDefault();
                var serviceAttribute = property.GetCustomAttributes(true).OfType<SearchIndexServiceAreaMappingAttribute>().FirstOrDefault();

                if (skillAttribute != null)
                {
                    if (skills.Any(x => x == skillAttribute.RelatedSkill))
                    {
                        if (property.GetValue(rawSearchResult, null).ConvertTo<bool>())
                            requiredScore++;
                    }
                }

                if (serviceAttribute != null)
                {
                    if (serviceAreas.Any(x => x == serviceAttribute.RelatedArea))
                    {
                        if (property.GetValue(rawSearchResult, null).ConvertTo<bool>())
                            score++;
                    }
                }
            }

            if (requiredScore == 0)
                return 0;

            return score + requiredScore;
        }

        public virtual int ScoreSearchCriteriaRelevance(BoardMemberSearchResult rawSearchResult, IEnumerable<Skill> skills, IEnumerable<ServiceArea> serviceAreas)
        {
            var type = typeof(BoardMemberSearchResult);
            var score = 0;
            int requiredScore = 0;

            foreach (var property in type.GetProperties().Where(x => x.CanRead))
            {
                var skillAttribute = property.GetCustomAttributes(true).OfType<SearchIndexSkillMappingAttribute>().FirstOrDefault();
                var serviceAttribute = property.GetCustomAttributes(true).OfType<SearchIndexServiceAreaMappingAttribute>().FirstOrDefault();

                if (skillAttribute != null)
                {
                    if (skills.Any(x => x == skillAttribute.RelatedSkill))
                    {
                        if (property.GetValue(rawSearchResult, null).ConvertTo<bool>())
                            score++;
                    }
                }

                if (serviceAttribute != null)
                {
                    if (serviceAreas.Any(x => x == serviceAttribute.RelatedArea))
                    {
                        if (property.GetValue(rawSearchResult, null).ConvertTo<bool>())
                            requiredScore++;
                    }
                }
            }

            if (requiredScore == 0)
                return 0;

            return score + requiredScore;
        }
    }
}
