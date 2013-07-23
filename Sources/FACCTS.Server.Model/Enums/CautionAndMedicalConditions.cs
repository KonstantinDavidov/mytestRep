using System;
using System.ComponentModel;

namespace FACCTS.Server.Model.Enums
{
    public enum CautionAndMedicalConditions
    {
        [Description("Armed and dangerous")]
        ArmedAndDangerous = 0,
        [Description("Other")]
        Other = 1,
        [Description("Violent tendencies")]
        ViolentTendencies = 5,
        [Description("Martial arts expert")]
        MartialArtsExpert = 10,
        [Description("Explosive Expertise")]
        ExplosiveExpertise = 15,
        [Description("Known to abuse drugs")]
        KnownToAbuseDrugs = 20,
        [Description("Escape risk")]
        EscapeRisk = 25,
        [Description("Sexually violent predator")]
        SexuallyViolentPredator = 30,
        [Description("International Flight Risk")]
        InternationalFlighRisk = 40,
        [Description("Heart condition")]
        HeartСondition = 50,
        [Description("Alcoholic")]
        Alcoholic = 55,
        [Description("Allergies")]
        Allergies = 60,
        [Description("Epilepsy")]
        Epilepsy = 65,
        [Description("Suicidal")]
        Suicidal = 70,
        [Description("Medication required")]
        MedicationRequired = 80,
        [Description("Hemophiliac")]
        Hemophiliac = 85,
        [Description("Diabetic")]
        Diabetic = 90
    }
    public static class CautionAndMedicalConditionsExt
    {
        public static string ToString(this CautionAndMedicalConditions value)
        {
            return ((int)value).ToString("00");
        }
    }
}
