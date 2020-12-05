using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace API_Angular_Project.Model
{
    public class Product
    {
        public int ID { get; set; }
        [Required]
        public string ProductName { get; set; }
        public double UnitPrice { get; set; }
        public int? QuantityPerUnit { get; set; }
        public double? Discount { get; set; }
        //[Required]
        public string Image { get; set; }       
        public int CategoryID { get; set; }
        [ForeignKey("CategoryID")]
        [JsonIgnore]
        public virtual Category Category { get; set; }
        [JsonIgnore]
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}