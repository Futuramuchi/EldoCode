using EldoCodeDesktop.AppData;
using EldoCodeDesktop.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EldoCodeDesktop.View
{
    /// <summary>
    /// Логика взаимодействия для ABCAnalusysPage.xaml
    /// </summary>
    public partial class ABCAnalusysPage : Page
    {
        private List<ProductOrderModel> _productOrder { get; set; }
        public ABCAnalusysPage()
        {
            InitializeComponent();

            GetAnalysis();            

        }

        private async void GetAnalysis()
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
                    PermanentData.ProductAnalyseOrder = _productOrder;


                    GridClients.ItemsSource = _productOrder.GroupBy(x => x.Product.Id).Select(x => x.FirstOrDefault()).ToList();
                    DataContext = new Graph("analyse");
                }
            }
            catch (Exception er)
            {

                er.Message.ToString();
            }
        }
    }
}
