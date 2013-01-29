using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CNM.Configuration;

namespace CNM.Models
{
    public class SearchResultBase
    {
        
        public string Zip {get; set;}
        public string City {get; set;}
        public string State {get; set;}


        [SearchIndexSkillMapping(Skill.Management)]
        public byte SK1 { get; set; }
        [SearchIndexSkillMapping(Skill.Education)]
        public byte SK2 { get; set; }
        [SearchIndexSkillMapping(Skill.ProgramDevelopment)]
        public byte SK3 { get; set; }
        [SearchIndexSkillMapping(Skill.Finance)]
        public byte SK4 { get; set; }
        [SearchIndexSkillMapping(Skill.Research)]
        public byte SK5 { get; set; }
        [SearchIndexSkillMapping(Skill.NonprofitStrategicPlanning)]
        public byte SK6 { get; set; }
        [SearchIndexSkillMapping(Skill.Government)]
        public byte SK7 { get; set; }
        [SearchIndexSkillMapping(Skill.VolunteerManagement)]
        public byte SK8 { get; set; }
        [SearchIndexSkillMapping(Skill.MarketingPR)]
        public byte SK9 { get; set; }
        [SearchIndexSkillMapping(Skill.Technology)]
        public byte SK10 { get; set; }
        [SearchIndexSkillMapping(Skill.RealEstate)]
        public byte SK11 { get; set; }
        [SearchIndexSkillMapping(Skill.HumanResoruces)]
        public byte SK12 { get; set; }
        [SearchIndexSkillMapping(Skill.LawBankruptcy)]
        public byte SK13 { get; set; }
        [SearchIndexSkillMapping(Skill.LawBusinessLaw)]
        public byte SK14 { get; set; }
        [SearchIndexSkillMapping(Skill.LawCiviRights)]
        public byte SK15 { get; set; }
        [SearchIndexSkillMapping(Skill.LawConsumerLaw)]
        public byte SK16 { get; set; }
        [SearchIndexSkillMapping(Skill.LawContracts)]
        public byte SK17 { get; set; }
        [SearchIndexSkillMapping(Skill.LawCriminalLaw)]
        public byte SK18 { get; set; }
        [SearchIndexSkillMapping(Skill.LawEducationLaw)]
        public byte SK19 { get; set; }
        [SearchIndexSkillMapping(Skill.LawElderLaw)]
        public byte SK20 { get; set; }
        [SearchIndexSkillMapping(Skill.LawEstatePlanning)]
        public byte SK21 { get; set; }
        [SearchIndexSkillMapping(Skill.LawFamilyLaw)]
        public byte SK22 { get; set; }
        [SearchIndexSkillMapping(Skill.LawGeneralPractice)]
        public byte SK23 { get; set; }
        [SearchIndexSkillMapping(Skill.LawImmigration)]
        public byte SK24 { get; set; }
        [SearchIndexSkillMapping(Skill.LawIntellectualProperty)]
        public byte SK25 { get; set; }
        [SearchIndexSkillMapping(Skill.LawLaborandEmployment)]
        public byte SK26 { get; set; }
        [SearchIndexSkillMapping(Skill.LawLegalMalpractice)]
        public byte SK27 { get; set; }
        [SearchIndexSkillMapping(Skill.LawMedicalMalpractive)]
        public byte SK28 { get; set; }
        [SearchIndexSkillMapping(Skill.LawMilitayLaw)]
        public byte SK29 { get; set; }
        [SearchIndexSkillMapping(Skill.LawPersonalInjury)]
        public byte SK30 { get; set; }
        [SearchIndexSkillMapping(Skill.LawProductsLiability)]
        public byte SK31 { get; set; }
        [SearchIndexSkillMapping(Skill.LawRealEstate)]
        public byte SK32 { get; set; }
        [SearchIndexSkillMapping(Skill.LawSecurities)]
        public byte SK33 { get; set; }
        [SearchIndexSkillMapping(Skill.LawSocialSeurity)]
        public byte SK34 { get; set; }
        [SearchIndexSkillMapping(Skill.LawTaxation)]
        public byte SK35 { get; set; }
        [SearchIndexSkillMapping(Skill.LawTrustsandEstates)]
        public byte SK36 { get; set; }
        [SearchIndexSkillMapping(Skill.LawVeteransBenefits)]
        public byte SK37 { get; set; }
        [SearchIndexSkillMapping(Skill.LawWillsandProbat)]
        public byte SK38 { get; set; }
        [SearchIndexSkillMapping(Skill.LawWorkersCompensation)]
        public byte SK39 { get; set; }
        [SearchIndexServiceAreaMapping(ServiceArea.AnimalWelfare)]
        public byte AR1 { get; set; }
        [SearchIndexServiceAreaMapping(ServiceArea.AnimalRights)]
        public byte AR2 { get; set; }
        [SearchIndexServiceAreaMapping(ServiceArea.Arts)]
        public byte AR3 { get; set; }
        [SearchIndexServiceAreaMapping(ServiceArea.Legal)]
        public byte AR4 { get; set; }
        [SearchIndexServiceAreaMapping(ServiceArea.SeniorAdultServices)]
        public byte AR5 { get; set; }
        [SearchIndexServiceAreaMapping(ServiceArea.Environmental)]
        public byte AR6 { get; set; }
        [SearchIndexServiceAreaMapping(ServiceArea.WomensIssue)]
        public byte AR7 { get; set; }
        [SearchIndexServiceAreaMapping(ServiceArea.DomesticViolence)]
        public byte AR8 { get; set; }
        [SearchIndexServiceAreaMapping(ServiceArea.ChildrenYouthTeen)]
        public byte AR9 { get; set; }
        [SearchIndexServiceAreaMapping(ServiceArea.CrimePrevention)]
        public byte AR10 { get; set; }
        [SearchIndexServiceAreaMapping(ServiceArea.MentalHealth)]
        public byte AR11 { get; set; }
        [SearchIndexServiceAreaMapping(ServiceArea.VeteransMilitary)]
        public byte AR12 { get; set; }
        [SearchIndexServiceAreaMapping(ServiceArea.Homelessness)]
        public byte AR13 { get; set; }
        [SearchIndexServiceAreaMapping(ServiceArea.Housing)]
        public byte AR14 { get; set; }
        [SearchIndexServiceAreaMapping(ServiceArea.HumanRights)]
        public byte AR15 { get; set; }
    }
}
