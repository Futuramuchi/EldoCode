using EldocCodeApi.Helper;
using EldocCodeApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace EldocCodeApi.Controllers
{
    public class ProductOrderController : ApiController
    {
        private EldoCodeEntities _ent;

        public ProductOrderController()
        {
            _ent = new EldoCodeEntities();
        }

        public async Task<HttpResponseMessage> Post([FromBody] ProductOrderModel productOrder)
        {
            byte[] vs = Encoding.UTF8.GetBytes(PermanentData.Order.Id + productOrder.Order.DateCreated.ToString());
            var secretKey = Convert.ToBase64String(vs);

            ProductOrder productOrderData = new ProductOrder()
            {
                ProductId = productOrder.Product.Id,
                OrderId = PermanentData.Order.Id,
                Amount = productOrder.Amount,
                SecretKey = secretKey
            };

            PermanentData.SecretKey = productOrderData.SecretKey;
            PermanentData.ProductOrderId = productOrder.Id;

            _ent.ProductOrder.Add(productOrderData);
            Chat chatData = new Chat()
            {
                ProductOrderId = PermanentData.ProductOrderId,
                DateCreated = DateTime.Now,
                SecretKey = PermanentData.SecretKey
            };
            _ent.Chat.Add(chatData);
            await _ent.SaveChangesAsync();

            var newChat = new ChatModel()
            {
                Id = chatData.Id,
                SecretKey = chatData.SecretKey
            };

            return Request.CreateResponse(System.Net.HttpStatusCode.OK, newChat);
        }

        public IHttpActionResult Get()
        {
            return Ok(_ent.ProductOrder.ToList().ConvertAll(x => new ProductOrderModel(x)));
        }

    }
}