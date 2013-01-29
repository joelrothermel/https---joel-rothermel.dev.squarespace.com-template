using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CNM.Models
{
    public enum ServiceArea
    {
        [Description("Animal Welfare")]
        AnimalWelfare = 1,
        [Description("Animal Rights")]
        AnimalRights = 2,
        [Description("Arts")]
        Arts = 3,
        [Description("Legal")]
        Legal = 4,
        [Description("Senior Adult Services")]
        SeniorAdultServices = 5,
        [Description("Environmental")]
        Environmental = 6,
        [Description("Women's Issue")]
        WomensIssue = 7,
        [Description("Domestic Violence")]
        DomesticViolence = 8,
        [Description("Children\\Youth\\Teen")]
        ChildrenYouthTeen = 9,
        [Description("Crime Prevention")]
        CrimePrevention = 10,
        [Description("Mental Health")]
        MentalHealth = 11,
        [Description("Veterans\\Military")]
        VeteransMilitary = 12,
        [Description("Homelessness")]
        Homelessness = 13,
        [Description("Housing")]
        Housing = 14,
        [Description("Human Rights")]
        HumanRights = 15,
    }
}
