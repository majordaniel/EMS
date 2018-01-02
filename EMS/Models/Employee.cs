using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EMS.Models
{
    public class Employee
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please inpute employee name")]
        [Display(Name = "Employee Name")]
        public string EmployeeName { get; set; }
        public string FathersName { get; set; }
        public string MothersName { get; set; }
        public Marital MaritalStatus { get; set; }
        public string SpouseName { get; set; }
        public Sex Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public Blood BloodGroup { get; set; }
        public Religon Religion { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Nationality { get; set; }
        public string NationalID { get; set; }
        public string BithID { get; set; }
       
        //Address Start
        public string HouseNo { get; set; }
        public string RoadNo { get; set; }
        public string Address { get; set; }
        public int CountryId { get; set; }
        public int DivisionId { get; set; }
        public int DistrictId { get; set; }
        public int PoliceStationId { get; set; }
        public int UnionId { get; set; }
        public string PostalCode { get; set; }


        //Address Part End

        public DateTime JoiningDate { get; set; }
        public Employement EmployementStatus { get; set; }
        public Grade PayGrade { get; set; }
        public int DepartmentId { get; set; }
        public int DesignationId { get; set; }
        public State Status { get; set; }
        public DateTime TerminationDate { get; set; }



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
}