using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CNM.Models;

namespace CNM.Web.Framework
{
    public class SkillEnumerableModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var formData = bindingContext.ValueProvider.GetValue("skills").AttemptedValue;

            if (string.IsNullOrWhiteSpace(formData))
            {
                return new List<Skill>();
            }
            else
            {
                return formData.Split(',').Select(x => x.ConvertTo<Skill>()).Where(x => Enum.IsDefined(typeof(Skill), x)).ToList();
            }
        }
    }
}