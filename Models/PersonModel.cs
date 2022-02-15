using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Day6.Enum;

namespace Day6.Models
{
    public class PersonModel
    {
        [Range(0, 1000)]
        public int ID { get; set; }

        [DisplayNameAttribute("First Name")]
        public string FirstName { get; set; }

        [DisplayNameAttribute("Last Name")]
        public string LastName { get; set; }

        public Gender Gender { get; set; }

        [DisplayNameAttribute("Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        [DisplayNameAttribute("Phone Number")]
        public string? PhoneNumber { get; set; }

        [DisplayNameAttribute("Birth Place")]
        public string? BirthPlace { get; set; }

        [DisplayNameAttribute("Graduated")]
        public string IsGraduated { get; set; }
        public int Age
        {
            get
            {
                return DateTime.Now.Year - DateOfBirth.Year;
            }
        }
        public string DOB
        {
            get
            {
                return DateOfBirth.ToString("dd/MM/yyyy");
            }
        }
    }
}