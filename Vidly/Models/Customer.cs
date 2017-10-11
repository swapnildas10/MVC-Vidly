using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        //[required(ErrorMessage=("xxx"))]
        [Required] //data annotation
        [StringLength(255)]
        public string Name { get; set; }
        [Required] //data annotation
        [StringLength(255)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required] //data annotation
        [StringLength(255)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        public MembershipType MembershipType { get; set; }

        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }
        [Min18YearsIfAMember]
        [Display(Name = "Date of Birth")]
        public DateTime? BirthDate { get; set; } //to set something nullable

    }
}