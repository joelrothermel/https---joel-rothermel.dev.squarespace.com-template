using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CNM
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum enumMember)
        {
            var members = enumMember.GetType().GetMembers().Where(member => member.GetCustomAttributes(false).Any(attr => attr is DescriptionAttribute));

            if (!members.Any(x => x.Name == enumMember.ToString()))
                return enumMember.ToString();

            var match = members.First(x => x.Name == enumMember.ToString());

            var attribute = match.GetCustomAttributes(false).OfType<DescriptionAttribute>().First();

            return attribute.Description;
        }
    }
}
