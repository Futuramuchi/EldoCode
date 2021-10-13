using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EldocCodeApi.Models
{
    public class ProductModel
    {
        public ProductModel(Product product = null)
        {
            if (product != null)
            {
                Id = product.Id;
                Name = product.Name;
                Firm = new FirmModel(product.Firm);
                Category = new CategoryModel(product.Category);
                VendorCode = product.VendorCode;
                Price = (decimal?)product.Price;
                Description = product.Description;
                Photo = (byte[])product.Photo;
            }

        }

        public int Id { get; set; }
        public string Name { get; set; }
        public FirmModel Firm { get; set; }
        public string VendorCode { get; set; }
        public CategoryModel Category { get; set; }
        public decimal? Price { get; set; }
        public byte[] Photo { get; set; }
        public string Description { get; set; }
    }
}