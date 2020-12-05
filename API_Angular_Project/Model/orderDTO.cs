using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_Angular_Project.Model
{
    public class orderDTO
    {
        public string CustomerID { get; set; }
        public double TotalOrderPrice { get; set; }
        public List<ProductDTO> productList { get; set; }

        //public virtual Customer Customer { get; set; }
    }


    public class ProductDTO
    {
        public int ID { get; set; }
        public int NeededQuantity { get; set; }

    }


}