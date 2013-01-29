using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CNM.Security
{
    public class CustomDataTranslator
    {
        public virtual CustomUserData TransformUserData(string userData)
        {
            var enumType = typeof(UserAuthenticationType);
            var components = userData.Split('|');

            UserAuthenticationType authType = UserAuthenticationType.Board;
            if (components.Length > 1 && Enum.GetNames(enumType).Any(z => z == components.First()))
                authType = Enum.Parse(enumType, components.First()).ConvertTo<UserAuthenticationType>();


            

            return new CustomUserData
            {
                AuthenticationType = authType,
                CharityId = components.ElementAt(1).ToString(),
                BoardMemberId = components.ElementAt(2).GetValueOrDefault<int?>(null)
            };
        }

        public virtual string TransformUserData(CustomUserData userData)
        {
            return userData.AuthenticationType.ToString() + "|" + userData.CharityId + "|" + userData.BoardMemberId.ConvertTo<string>();
        }
    }
}
