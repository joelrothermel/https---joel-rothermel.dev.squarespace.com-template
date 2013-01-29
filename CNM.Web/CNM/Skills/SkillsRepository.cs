using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CNM.Models;
using CNM.Sql;

namespace CNM.Skills
{
    public class SkillsRepository
    {
        public virtual IEnumerable<SkillEntity> GetSkillsFor(string charityId)
        {
            using (var context = new SqlDataContext())
            {
                var charity =  context.Charities.FirstOrDefault(x => x.CharityId == charityId);

                if (charity == null)
                    return new List<SkillEntity>();

                return charity.NeededSkills.ToList();
            }
        }

        public virtual Dictionary<Charity, IEnumerable<ServiceAreaEntity>> GetSkillsForCharitySet(IEnumerable<string> charityIds)
        {
            Dictionary<Charity, IEnumerable<ServiceAreaEntity>> data = new Dictionary<Charity, IEnumerable<ServiceAreaEntity>>();

            using (var context = new SqlDataContext())
            {
                var charities = context.Charities.Where(x => charityIds.Contains(x.CharityId)).ToList();

                charities.ForEach(x =>
                {
                    data.Add(x, x.NeededServiceAreas.ToList());
                });

                return data;
            }
        }

        public virtual IEnumerable<SkillEntity> GetSkillsFor(int memberId)
        {
            using (var context = new SqlDataContext())
            {
                var boardMember = context.BoardMembers.FirstOrDefault(x => x.BoardMemberId == memberId);

                if (boardMember == null)
                    return new List<SkillEntity>();

                return boardMember.AvailableSkills.ToList();
            }
        }
    }
}
