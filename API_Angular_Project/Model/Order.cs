using Microsoft.AspNet.Identity.EntityFramework;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace API_Angular_Project.Model
{
    public class Order
    {
        public int ID { get; set; }
        public double TotalOrderPrice { get; set; }
        [Required]
        public string OrderDate { get; set; }
        public double? Discount { get; set; }

        [Required]
        public string CustomerID { get; set; }
        [ForeignKey("CustomerID")]
        [JsonIgnore]
        public virtual Customer Customer { get; set; }
        [JsonIgnore]
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }   
}