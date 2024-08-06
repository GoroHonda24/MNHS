using MHNS.Utilities;
using System;
using System.ComponentModel.DataAnnotations;

namespace MHNS.Models
{
    public class EnrolmentForm
    {
        public EnrolmentForm()
        {
            Birthdate = DateTime.Now; // Set default value to today's date
        }

        [Required]
        [Display(Name = "PSA Birth Certificate No.")]
        public string BirthCertificateNo { get; set; }

        [Required]
        [Display(Name = "Learner Reference No. (LRN)")]
        public string LearnerReferenceNo { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DateRangeUntilToday("01/01/1900", ErrorMessage = "Birthdate must be between 01/01/1900 and today's date")]
        public DateTime Birthdate { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [Display(Name = "Extension Name")]
        public string ExtensionName { get; set; }

        [Display(Name = "Learner with Disability")]
        public bool HasDisability { get; set; }

        public string DisabilityType { get; set; }

        [Required]
        public string PermanentAddress { get; set; }

        [Required]
        public string CurrentAddress { get; set; }

        [Required]
        public string FatherName { get; set; }

        [Required]
        public string MotherMaidenName { get; set; }

        public string LegalGuardianName { get; set; }

        [Required]
        public string MotherTongue { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string Sex { get; set; }

        [Display(Name = "Indigenous Peoples Community")]
        public bool IsIndigenous { get; set; }

        public string IndigenousCommunity { get; set; }

        [Display(Name = "4Ps Beneficiary")]
        public bool Is4PsBeneficiary { get; set; }

        public string FourPsHouseholdId { get; set; }

        public string LastGradeLevelCompleted { get; set; }

        public string LastSchoolYearCompleted { get; set; }

        public string LastSchoolAttended { get; set; }

        public string LastSchoolID { get; set; }

        public bool SemesterFirst { get; set; }

        public bool SemesterSecond { get; set; }

        public string Track { get; set; }

        public string Strand { get; set; }

        public bool ModularPrint { get; set; }

        public bool Online { get; set; }

        public bool RadioBasedInstruction { get; set; }

        public bool Blended { get; set; }

        public bool ModularDigital { get; set; }

        public bool EducationalTelevision { get; set; }

        public bool Homeschooling { get; set; }
    }
}
