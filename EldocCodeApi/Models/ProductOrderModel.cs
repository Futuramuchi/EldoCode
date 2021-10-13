using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EldocCodeApi.Models
{
    public class ProductOrderModel
    {
        public ProductOrderModel(ProductOrder productOrder = null)
        {
            if (productOrder != null)
            {

                Id = productOrder.Id;
                Order = new OrderModel(productOrder.Order);
                Product = new ProductModel(productOrder.Product);
                Amount = (int)productOrder.Amount;
            }
        }

        public int Id { get; set; }
        public OrderModel Order { get; set; }
        public int Amount { get; set; }
        public ProductModel Product { get; set; }
    }
}