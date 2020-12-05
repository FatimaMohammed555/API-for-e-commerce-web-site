using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace API_Angular_Project.Model
{
    public class OrderDetails
    {
        public int ID { get; set; }
        public double Price { get; set; }
        //neededQuantity
        public int Quantity { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        [ForeignKey("OrderID")]
        [JsonIgnore]
        public virtual Order Order { get; set; }
        [ForeignKey("ProductID")]
        [JsonIgnore]
        public virtual Product Product { get; set; }
    }
}