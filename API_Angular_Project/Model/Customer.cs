using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace API_Angular_Project.Model
{
    public class Customer:IdentityUser
    {
        [Required]
        public string Name { get; set; }
        //[Required]
        public string Address { get; set; }
        //[Required]
        public string City { get; set; }
        //[Required]
        //public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        public int Phone { get; set; }
        //public virtual IdentityUser Customer { get; set; }

        //public virtual ICollection<Order> Orders { get; set; }
    }

    //1c8b1a1f-46d9-43ba-b1df-f588ae78fe53





}