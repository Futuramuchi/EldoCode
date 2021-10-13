using EldoCodeDesktop.AppData;
using EldoCodeDesktop.Core;
using EldoCodeDesktop.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EldoCodeDesktop.ViewModel
{
    public class AnalyticsVM
    {
        public string ClientsAmount { get; set; }
        public string PlusClientAmount { get; set; }
        public string OrderAmount { get; set; }
        public string PlusOrderAmount { get; set; }

        public string IncomeAmount { get; set; }
        public string PlusIncometAmount { get; set; }

        public string SoldAmount { get; set; }
        public string PlusSelledAmount { get; set; }

        public List<ProductOrderModel> ProductOrder { get; set; }
        public List<ProductOrderModel> TopProduct { get; set; }
        public List<ProductOrderModel> CountryRate { get; set; }
        public List<ClientModel> Client { get; set; }


        private DateTime _neededMonth = DateTime.Now;
        private string _value = string.Empty;

        public AnalyticsVM()
        {
            GetClientData();

            try
            {
                string url = "http://eldocode.makievksy.ru.com/api/ProductOrder";
                WebRequest webRequest = WebRequest.Create(url);

                var response = webRequest.GetResponse();
                string jsonString = string.Empty;

                using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                {
                    jsonString = sr.ReadToEnd();
                }

                ProductOrder = JsonConvert.DeserializeObject<List<ProductOrderModel>>(jsonString);
                PermanentData.ProductOrder = ProductOrder;

            }
            catch (Exception er)
            {

                er.Message.ToString();
            }

            GetCountryRate();
            GetTopProduct();
            GetIncomeData();
        }

        private async void GetClientData()
        {
            try
            {
                HttpClient client = new HttpClient();
                string url = "http://eldocode.makievksy.ru.com/api/Client";

                var response = await client.GetAsync(url);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    Client = JsonConvert.DeserializeObject<List<ClientModel>>(responseContent);
                    ClientsAmount = Client.Count().ToString();

                    PlusClientAmount = "+ " + Client
                        .Where(x => x.DateCreated.Value.Month == _neededMonth.AddMonths(-1).Month)
                        .Count()
                        .ToString();
                }
            }
            catch (Exception er)
            {

                er.Message.ToString();
            }
        }

        private void GetCountryRate()
        {
            try
            {
                CountryRate = (List<ProductOrderModel>)ProductOrder
                    .GroupBy(el => el.Order.Worker.Store.Region.Id)
                    .OrderByDescending(el => el.Count())
                    .Take(2);
            }
            catch (Exception er)
            {

                er.Message.ToString();
            }
        }

        private void GetTopProduct()
        {
            TopProduct = (List<ProductOrderModel>)ProductOrder
                .GroupBy(el => el.Product.Id)
                .OrderByDescending(el => el.Count());
        }


        private void GetIncomeData()
        {
            try
            {
                IncomeAmount = ProductOrder
                    .Sum(x => x.Product.Price)
                    .ToString();

                var previousIncome = ProductOrder
                    .Where(x => x.Order.DateCreated.Month == _neededMonth.AddMonths(-1).Month)
                    .Sum(x => x.Product.Price);

                var currentIncome = ProductOrder
                    .Where(x => x.Order.DateCreated.Month == _neededMonth.Month)
                    .Sum(x => x.Product.Price);


                var difference = (currentIncome * (100 / previousIncome)) - 100;
                PlusIncometAmount = $"{_value} {Math.Round((decimal)difference, 2)}%";

                // Количество заказов за весь период
                OrderAmount = ProductOrder
                    .Select(x => x.Order)
                    .Count()
                    .ToString();

                // Количество заказов, которые прибавились в течение месяца
                PlusOrderAmount = "+ " + ProductOrder
                    .Where(x => x.Order.DateCreated.Month == _neededMonth.AddMonths(-1).Month)
                    .Select(x => x.Order.Id)
                    .Count()
                    .ToString();

                // Количество проданных товаров
                SoldAmount = ProductOrder
                    .Where(x => x.Order.Status.Id == 2)
                    .Sum(x => x.Amount)
                    .ToString();

                // Количество проданных товаров в сравнении с прошлым месяцем
                PlusSelledAmount = "+ " + ProductOrder
                    .Where(x => x.Order.DateCreated.Month == _neededMonth
                    .AddMonths(-1).Month)
                    .Sum(x => x.Amount)
                    .ToString();
            }
            catch (Exception er)
            {

                er.Message.ToString();
            }
        }


    }
}
