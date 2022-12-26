using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeApp.Models
{
    public class EmpData
    {
        [Key]
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        [Required(ErrorMessage = "Please Enter Name"), MaxLength(50), RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Use Alphabets only")]
        public string? Name { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        [Required(ErrorMessage = "Please select Gender")]
        public string? Gender { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        [Required(ErrorMessage = "Please select Designatin")]
        public string? Designation { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        [Display(Name = "Mail ID")]
        [Required(ErrorMessage = "Please enter you email ID"), DataType(DataType.EmailAddress, ErrorMessage = "Data type is not Email"), EmailAddress(ErrorMessage = "This is not proper Email format")]
        public string? MailID { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        [Display(Name = "Mobile Number")]
        [Required(ErrorMessage = "Please enter your mobile number"), DataType(DataType.PhoneNumber, ErrorMessage = "Datatype is not match with phone number datatype"), StringLength(10), RegularExpression(@"^[7-9][0-9]{9}$", ErrorMessage = "Not a valid phone number")]
        public string? MobileNumber { get; set; }

        [Column(TypeName = "bit")]
        public bool C { get; set; }

        [Column(TypeName = "bit")]
        public bool Oops { get; set; }

        [Column(TypeName = "bit")]
        public bool Java { get; set; }

    }
}
