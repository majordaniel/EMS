using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EMS.Models
{
    public class Employee
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please inpute employee name")]
        [Display(Name = "Employee name")]
        [StringLength(100)]
        public string EmployeeName { get; set; }

        [Required(ErrorMessage = "Please input fathers name!")]
        [Display(Name = "Father's name")]
        [StringLength(100)]
        public string FathersName { get; set; }

        [Required(ErrorMessage = "Please input mother's name!")]
        [Display(Name = "Mother's name")]
        [StringLength(100)]
        public string MothersName { get; set; }

        [Required(ErrorMessage = "Plase select select marital status!")]
        [Display(Name = "Marital status")]
        public Marital MaritalStatus { get; set; }

        [Display(Name = "Spouse name")]
        [StringLength(100)]
        public string SpouseName { get; set; }

        [Required(ErrorMessage = "Please select gender type!")]
        public Sex Gender { get; set; }

        [Required(ErrorMessage = "Please set your birth date!")]
        [DataType(DataType.Date)]
        [Display(Name = "Birth date")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Please select blood group!")]
        [Display(Name = "Blood group")]
        public Blood BloodGroup { get; set; }

        [Required(ErrorMessage = "Please select religion!")]
        [Display(Name = "Religion")]
        public Religon Religion { get; set; }

        [Required(ErrorMessage = "Please input email ID!")]
        [StringLength(255)]
        [Index(IsUnique = true)]
        [Remote("IsEmailExists","Employee",HttpMethod = "POST", ErrorMessage = "Email id already exists! try another")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please input Mobile no!")]
        [StringLength(20)]
        [Index(IsUnique = true)]
        [Remote("IsMobileExists", "Employee", HttpMethod = "POST", ErrorMessage = "Mobile no already exists! try another")]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "Please input nationality!")]
        [StringLength(20)]
        public string Nationality { get; set; }

        [Required(ErrorMessage = "Please inpute nation ID number!")]
        [StringLength(17, MinimumLength = 13, ErrorMessage = "National ID number must be 13 to 17 digit ling!")]
        [Display(Name = "National ID")]
        [Index(IsUnique = true)]
        [Remote("IsNationalIDExists","Employee",HttpMethod = "POST",ErrorMessage = "National ID number already exists!")]
        public string NationalID { get; set; }

        [Required(ErrorMessage = "Please input contact person name!")]
        [StringLength(50)]
        [Display(Name = "Contact person")]
        public string ContactPerson { get; set; }

        [Required(ErrorMessage = "Please input contact person mobile no.!")]
        [StringLength(20)]
        [Display(Name = "Mobile no.")]
        public string ContactMobileNo { get; set; }

        [Required(ErrorMessage = "Please input contact person Email!")]
        [StringLength(255)]
        [Display(Name = "Email")]
        public string ContactEmail { get; set; }

        [Required(ErrorMessage = "Please select contact person relation!")]
        [Display(Name = "Relation")]
        public Relation ContactRelation { get; set; }


        //Address Start
        [Required(ErrorMessage = "Please input road no!")]
        [Display(Name = "House no")]
        public string HouseNo { get; set; }

        [Required(ErrorMessage = "Please input road no!")]
        [Display(Name = "Road no")]
        public string RoadNo { get; set; }
        [Required(ErrorMessage = "Please input village name")]
        public string Village { get; set; }

        [Display(Name = "Country")]
        [Required(ErrorMessage = "Please select country!")]
        public int CountryId { get; set; }

        [Required(ErrorMessage = "Please select division!")]
        [Display(Name = "Division")]
        public int DivisionId { get; set; }

        [Required(ErrorMessage = "Please select district!")]
        [Display(Name = "District")]
        public int DistrictId { get; set; }

        [Required(ErrorMessage = "Please select policestation")]
        [Display(Name = "Policestation")]
        public int PoliceStationId { get; set; }

        [Required(ErrorMessage = "Please select union!")]
        [Display(Name = "Union")]
        public int UnionId { get; set; }

        [Required(ErrorMessage = "Please input postal code!")]
        [Display(Name = "Postal code")]
        public string PostalCode { get; set; }


        //Address Part End

        [Required(ErrorMessage = "Please set join date!")]
        [Display(Name = "Joining Date")]
        public DateTime JoiningDate { get; set; }

        [Required(ErrorMessage = "Please select employment status!")]
        [Display(Name = "Employment status")]
        public Employement EmployementStatus { get; set; }

        [Required(ErrorMessage = "Please select paygrade!")]
        [Display(Name = "Pay Grade")]
        public Grade PayGrade { get; set; }

        [Required(ErrorMessage = "Please select department!")]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Please select designation!")]
        [Display(Name = "Designation")]
        public int DesignationId { get; set; }

        [Required(ErrorMessage = "Please select status!")]
        [Display(Name = "Status")]
        public State Status { get; set; }

        //Join

        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }

        [ForeignKey("DivisionId")]
        public virtual Division Division { get; set; }

        [ForeignKey("DistrictId")]
        public virtual District District { get; set; }

        [ForeignKey("PoliceStationId")]
        public virtual PoliceStation PoliceStation { get; set; }

        [ForeignKey("UnionId")]
        public virtual Union Union { get; set; }

        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }

        [ForeignKey("DesignationId")]
        public virtual Designation Designation { get; set; }
        public string EmployeeRegNo { get; set; }
    }

    public enum Employement
    {
        Parttime,
        FullTime,
        Contractual
    }

    public enum Grade
    {
        Manager,
        Executive,
        Assistant,
        Administrator
    }
    public enum State
    {
        Active,
        Terminated
    }
    public enum Religon
    {
        Islam,
        Christain,
        Buddist,
        Hidu
    }
    public enum Sex
    {
        Male,
        Female
    }
    public enum Blood
    {
        [Display(Name = "O+")]
        OPositive,
        [Display(Name = "A+")]
        APositive,
        [Display(Name = "B+")]
        BPositive,
        [Display(Name = "AB+")]
        ABPositive,
        [Display(Name = "AB-")]
        ABNegative,
        [Display(Name = "A-")]
        ANegative,
        [Display(Name = "B-")]
        BNegative,
        [Display(Name = "O-")]
        ONegative

    }

    public enum Marital
    {
        Married,
        Single,
        Divorced,
        Widowed,
        Other
    }

    public enum Relation
    {
        Father,
        Mother,
        Brtother,
        Wife
    }
}