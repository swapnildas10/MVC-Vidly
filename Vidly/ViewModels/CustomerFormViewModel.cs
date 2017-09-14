using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        //Ienum bcos we dont wanna use list prop
        // changing list type wont change this class as its only Ienum
        public Customer Customer { get; set; }
    }
}