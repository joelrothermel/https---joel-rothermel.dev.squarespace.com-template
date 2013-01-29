using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CNM.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CNM.Tests
{
    [TestClass]
    public class EnumExtensionsTests : TestBase
    {
        [TestMethod]
        public void EnumDescription_PullsDescription()
        {
            var description = Skill.LawWorkersCompensation.GetDescription();

            description.IsNotNull();
            description.IsEqualTo("Law - Workers Compensation");
        }

        [TestMethod]
        public void EnumDescription_PullsServiceDescription()
        {
            ServiceArea.AnimalRights.GetDescription().IsEqualTo("Animal Rights");
        }
    }
}
