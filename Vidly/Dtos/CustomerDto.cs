﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }
        //[required(ErrorMessage=("xxx"))]
        [Required] //data annotation
        [StringLength(255)]
        public string Name { get; set; }

      //  [Required] //data annotation
        [StringLength(255)]
        public string FirstName { get; set; }

       // [Required] //data annotation
        [StringLength(255)]
        public string LastName { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        public byte MembershipTypeId { get; set; }

        public MembershipTypeDto MembershipType { get; set; }
        //[Min18YearsIfAMember] //shows error in customerDto
        public DateTime? BirthDate { get; set; } //to set something nullable


    }
}