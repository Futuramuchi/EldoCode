using EldoCodeDesktop.AppData;
using EldoCodeDesktop.Model;
using EldoCodeDesktop.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EldoCodeDesktop.View
{
    /// <summary>
    /// Interaction logic for AnalyticsPage.xaml
    /// </summary>
    public partial class AnalyticsPage : Page
    {
        public AnalyticsPage()
        {
            InitializeComponent();


            GetProductOrderData();
            GetIncomeData();
            GetClientData();

            GetCountryData();
        }

        private void GetProductOrderData()
        {
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

                _productOrder = JsonConvert.DeserializeObject<List<ProductOrderModel>>(jsonString);
                PermanentData.ProductOrder = _productOrder;

                ListProduct.ItemsSource = _productOrder.GroupBy(el => el.Product.Id).OrderByDescending(el => el.Count()).ToList();

            }
            catch (Exception er)
            {

                er.Message.ToString();
            }
        }

        private List<ClientModel> _client;
        private List<ProductOrderModel> _productOrder;
        //private List<ProductOrderModel> _product;
        private string _value;

        private void GetCountryData()
        {
            try
            {
                ListRate.ItemsSource = _productOrder.GroupBy(el => el.Order.Worker.Store.Region.Id).OrderByDescending(el => el.Count()).Take(2).ToList();
            }
            catch (Exception er)
            {

                er.Message.ToString();
            }
        }


        private async void GetIncomeData()
        {
            try
            {
                HttpClient client = new HttpClient();
                string url = "http://eldocode.makievksy.ru.com/api/ProductOrder";

                var response = await client.GetAsync(url);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    _productOrder = JsonConvert.DeserializeObject<List<ProductOrderModel>>(responseContent);
                    TxtIncomeAmount.Text = _productOrder.Sum(x => x.Product.Price).ToString();

                    var neededMonth = DateTime.Now;
                    var previousIncome = _productOrder.Where(x => x.Order.DateCreated.Month == neededMonth.AddMonths(-1).Month).Sum(x => x.Product.Price);
                    var currentIncome = _productOrder.Where(x => x.Order.DateCreated.Month == neededMonth.Month).Sum(x => x.Product.Price);


                    var difference = (currentIncome * (100 / previousIncome)) - 100;

                    if (difference > 0)
                        _value = "+";
                    else
                        TxtIncomeAmountPlus.Foreground = new SolidColorBrush(Color.FromRgb(227, 18, 53));

                    TxtIncomeAmountPlus.Text = $"{_value} {Math.Round((decimal)difference, 2)}%";
                    TxtOrderAmount.Text = _productOrder.Select(x => x.Order).Count().ToString();
                    TxtOrderAmountPlus.Text = "+ " + _productOrder.Where(x => x.Order.DateCreated.Month == neededMonth.AddMonths(-1).Month).Select(x => x.Order.Id).Count().ToString();

                    TxtSellAmount.Text = _productOrder.Where(x => x.Order.Status.Id == 2).Sum(x => x.Amount).ToString();
                    TxtSellAmountPlus.Text = "+ " + _productOrder.Where(x => x.Order.DateCreated.Month == neededMonth.AddMonths(-1).Month).Sum(x => x.Amount).ToString();


                }
            }
            catch (Exception er)
            {

                er.Message.ToString();
            }
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
                    _client = JsonConvert.DeserializeObject<List<ClientModel>>(responseContent);
                    TxtAmount.Text = _client.Count().ToString();

                    var previousMonth = DateTime.Now;
                    TxtAmountPlus.Text = "+ " + _client.Where(x => x.DateCreated.Value.Month == previousMonth.AddMonths(-1).Month).Count().ToString();
                }
            }
            catch (Exception er)
            {

                er.Message.ToString();
            }
        }

    }
}
