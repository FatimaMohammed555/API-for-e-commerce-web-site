using API_Angular_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_Angular_Project.Controller
{
    public class BuyOrderController :BaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        [HttpPost]
        public IHttpActionResult BuyProducts(orderDTO orderDTO)
        {


            orderDTO.CustomerID = GetUserId();
            Product prod = new Product();
            OrderDetails orderDetails = new OrderDetails();
            //var totalPRICE = 0.0;
            Order order = new Order()
            {
              
                CustomerID =orderDTO.CustomerID,               
                OrderDate =DateTime.Today.ToString("dd-MM-yyyy")
            };
            db.Orders.Add(order);
            db.SaveChanges();
            var total = 0.0;
            foreach (var item in orderDTO.productList)
            {
                     prod = db.Products.FirstOrDefault(p => p.ID == item.ID);
                     prod.QuantityPerUnit = prod.QuantityPerUnit - item.NeededQuantity;
                     orderDetails.ProductID = prod.ID;
                     orderDetails.Quantity = item.NeededQuantity;
                     orderDetails.Price = prod.UnitPrice;
                     orderDetails.OrderID = order.ID;
                     total += orderDetails.Price * orderDetails.Quantity;
                     order.TotalOrderPrice = total;
                     db.OrderDetails.Add(orderDetails);
                     db.SaveChanges();
                    // orderDetails = new OrderDetails();
            }

            return Ok("order Added");
        }


    }
}
