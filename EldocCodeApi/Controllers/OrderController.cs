using EldocCodeApi.Helper;
using EldocCodeApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    public class OrderController : ApiController
    {
        private EldoCodeEntities _ent;
        public OrderController()
        {
            _ent = new EldoCodeEntities();
        }

        public async Task<HttpResponseMessage> Post([FromBody] OrderModel order, [FromUri] int notificationId)
        {

            Order orderData = new Order()
            {
                ClientId = (int)order.Client.Id,
                WorkerId = (int)order.Worker.Id,
                DateCreated = DateTime.Now,
                StatusId = (int)order.Status.Id,
                NotificationId = notificationId
            };

            _ent.Order.Add(orderData);
            await _ent.SaveChangesAsync();

            PermanentData.Order = orderData;

            return Request.CreateResponse(System.Net.HttpStatusCode.OK);
        }

        public async Task<HttpResponseMessage> Delete(int? orderId)
        {
            var orderToDelete = _ent.Order.Find(orderId);
            if (orderToDelete != null)
            {
                _ent.Order.Remove(orderToDelete);

                await _ent.SaveChangesAsync();
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, "The order was successfully deleted!");

            }
            return Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, "The Id of the order wasnt't found");
        }

        public async Task<HttpResponseMessage> Post([FromBody] OrderModel orderModel)
        {
            var order = await _ent.Order.FirstOrDefaultAsync(x => x.Id == orderModel.Id);

            if (order != null)
            {
                order.StatusId = (int)orderModel.Status.Id;

                await _ent.SaveChangesAsync();
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, "All the data was successfully saved!");
            }

            return Request.CreateResponse(System.Net.HttpStatusCode.BadRequest);
        }
    }
}