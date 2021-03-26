using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace nashtech_form.Mvc.Models
{
    public class Member
    {
        public int Id { get; set; }
        [Required, DisplayName("First Name")]
        public string firstName { get; set; }
         [Required, DisplayName("Last Name")]
        public string lastName { get; set; }
        [Required, DisplayName("Gender")]
        public string Gender { get; set; }
        [Required, DisplayName("Date of birth")]
        public DateTime DOB { get; set; }
        [Required, DisplayName("Phone Number")]
        public int phoneNumber { get; set; }
        [Required, DisplayName("Birth Place")]
        public string birthPlace { get; set; }
        [Required, DisplayName("Age")]
        public int Age { get; set; }
        [Required, DisplayName("IsGraduated")]
        public bool IsGraduated { get; set; }
        [DisplayName("File")]
        public string DataFile{get; set;}
    }
}