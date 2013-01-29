using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CNM.Models;

namespace CNM.Web.Framework
{
    public class ServiceAreaEnumerableModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var formData = bindingContext.ValueProvider.GetValue("serviceAreas").AttemptedValue;

            if (string.IsNullOrWhiteSpace(formData))
                return new List<ServiceArea>();
            else
                return formData.Split(',').Select(x => x.ConvertTo<ServiceArea>()).Where(x => Enum.IsDefined(typeof(ServiceArea), x)).ToList();
        }
    }
}