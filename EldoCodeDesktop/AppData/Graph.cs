using EldoCodeDesktop.Model;
using Newtonsoft.Json;
using OxyPlot;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EldoCodeDesktop.AppData
{
    public class Graph
    {
        public List<ProductOrderModel> ProductOrder { get; set; }
        public List<DataPoint> ABCAnalysisData { get; set; }
        private List<ProductOrderModel> ProductOrderAnalyse { get; set; }
        public List<string> Months { get; set; }
        public List<DataPoint> Data { get; set; }
        public List<DataPoint> WorkerData { get; set; }
        public Graph()
        {
            string url = "http://eldocode.makievksy.ru.com/api/ProductOrder";
            WebRequest webRequest = WebRequest.Create(url);

            var response = webRequest.GetResponse();
            string jsonString = string.Empty;

            using (StreamReader sr = new StreamReader(response.GetResponseStream()))
            {
                jsonString = sr.ReadToEnd();
            }

            ProductOrder = JsonConvert.DeserializeObject<List<ProductOrderModel>>(jsonString).OrderBy(x => x.Order.DateCreated.Month).GroupBy(x => x.Order.DateCreated.Month).Select(x => x.FirstOrDefault()).ToList();
            Data = new List<DataPoint>();

            List<string> months = new List<string>() { "январь", "февраль", "март", "апрель", "май", "июнь", "июль", "август", "сентябрь", "октябрь", "ноябрь" };
            Months = new List<string>();
            for (int i = 0; i < ProductOrder.Count; i++)
            {
                Months.Add(months[ProductOrder[i].Order.DateCreated.Month]);
                Data.Add(new DataPoint(i, (double)ProductOrder[i].Product.Price * ProductOrder[i].Amount));
            }
        }

        public Graph(WorkerModel worker = null)
        {
            string url = "http://eldocode.makievksy.ru.com/api/ProductOrder";
            WebRequest webRequest = WebRequest.Create(url);

            var response = webRequest.GetResponse();
            string jsonString = string.Empty;

            using (StreamReader sr = new StreamReader(response.GetResponseStream()))
            {
                jsonString = sr.ReadToEnd();
            }
    
            ProductOrder = JsonConvert.DeserializeObject<List<ProductOrderModel>>(jsonString).Where(x => x.Order.Worker.Id == worker.Id && x.Order.Status.Id == 2).OrderBy(x => x.Order.DateCreated.Month).GroupBy(x => x.Order.DateCreated.Month).Select(x => x.FirstOrDefault()).ToList();
            WorkerData = new List<DataPoint>();

            List<string> months = new List<string>() { "январь", "февраль", "март", "апрель", "май", "июнь", "июль", "август", "сентябрь", "октябрь", "ноябрь" };
            Months = new List<string>();
            for (int i = 0; i < ProductOrder.Count; i++)
            {
                Months.Add(months[ProductOrder[i].Order.DateCreated.Month]);
                WorkerData.Add(new DataPoint(i, (double)ProductOrder[i].Product.Price * ProductOrder[i].Amount));
            }
        }


        public Graph(string value)
        {

            string url = "http://eldocode.makievksy.ru.com/api/ProductOrder";
            WebRequest webRequest = WebRequest.Create(url);

            var response = webRequest.GetResponse();
            string jsonString = string.Empty;

            using (StreamReader sr = new StreamReader(response.GetResponseStream()))
            {
                jsonString = sr.ReadToEnd();
            }

            ProductOrderAnalyse = JsonConvert.DeserializeObject<List<ProductOrderModel>>(jsonString);
            ABCAnalysisData = new List<DataPoint>();


            for (int i = 0; i < ProductOrderAnalyse.Count; i++)
            {
                ABCAnalysisData.Add(new DataPoint((double)ProductOrderAnalyse[i].GetAbsc, (double)ProductOrderAnalyse[i].GetOrd));
            }

        }
    }
}
