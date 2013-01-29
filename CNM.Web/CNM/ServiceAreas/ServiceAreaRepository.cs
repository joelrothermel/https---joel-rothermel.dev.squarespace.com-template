using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CNM.Models;
using CNM.Sql;

namespace CNM.ServiceAreas
{
    public class ServiceAreaRepository
    {
        public virtual IEnumerable<ServiceAreaEntity> GetServiceAreasFor(string charityId)
        {
            using (var context = new SqlDataContext())
            {
                var charity = context.Charities.FirstOrDefault(x => x.CharityId == charityId);

                if (charity == null)
                    return new List<ServiceAreaEntity>();

                return charity.NeededServiceAreas.ToList();
            }
        }

        public virtual Dictionary<Charity, IEnumerable<SkillEntity>> GetSkillsForCharitySet(IEnumerable<string> charityIds)
        {
            Dictionary<Charity, IEnumerable<SkillEntity>> data = new Dictionary<Charity, IEnumerable<SkillEntity>>();

            using (var context = new SqlDataContext())
            {
                var charities = context.Charities.Where(x => charityIds.Contains(x.CharityId)).ToList();

                charities.ForEach(x =>
                    {
                        data.Add(x, x.NeededSkills.ToList());
                    });

                return data;
            }
        }

        public virtual IEnumerable<ServiceAreaEntity> GetServiceAreasFor(int memberId)
        {
            using (var context = new SqlDataContext())
            {
                var boardMember = context.BoardMembers.FirstOrDefault(x => x.BoardMemberId == memberId);

                if (boardMember == null)
                    return new List<ServiceAreaEntity>();

                return boardMember.Interests.ToList();
            }
        }
    }
}
