using EldocCodeApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace EldocCodeApi.Controllers
{
    public class ProductController : ApiController
    {
        private EldoCodeEntities _ent;

        public ProductController()
        {
            _ent = new EldoCodeEntities();
        }

        public IHttpActionResult Get([FromUri] int categoryId)
        {
            return Ok(_ent.Product.Where(x => x.CategoryId == categoryId).ToList().ConvertAll(x => new ProductModel(x)));
        }
        public IHttpActionResult Get()
        {
            return Ok(_ent.Product.ToList().ConvertAll(x => new ProductModel(x)));
        }

        public async Task<HttpResponseMessage> Post([FromBody] ProductModel product, int option)
        {
            if (option == 1)
            {
                Product productData = new Product()
                {
                    Name = product.Name,
                    Price = product.Price,
                    Description = product.Description,
                    CategoryId = product.Category.Id,
                    FirmId = product.Firm.Id,
                    Photo = product.Photo,
                    VendorCode = product.VendorCode
                };

                _ent.Product.Add(productData);
                await _ent.SaveChangesAsync();

                return Request.CreateResponse(System.Net.HttpStatusCode.OK, "The product was successfully added!");

            }

            if (option == 2)
            {
                var productData = await _ent.Product.FirstOrDefaultAsync(x => x.Id == product.Id);
                if (productData != null)
                {
                    productData.Name = product.Name;
                    productData.Price = product.Price;
                    productData.Description = product.Description;
                    productData.CategoryId = product.Category.Id;
                    productData.FirmId = product.Firm.Id;
                    productData.Photo = product.Photo;
                    productData.VendorCode = product.VendorCode;

                    await _ent.SaveChangesAsync();
                    return Request.CreateResponse(System.Net.HttpStatusCode.OK);
                }

                return Request.CreateResponse(System.Net.HttpStatusCode.BadRequest);
            }

            return Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, "The option wasnt't found");

        }

    }
}