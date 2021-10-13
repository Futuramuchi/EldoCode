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
    /// Логика взаимодействия для ManagerIncomeInfoPage.xaml
    /// </summary>
    public partial class ManagerIncomeInfoPage : Page
    {
        private ProductOrderModel _worker { get; set; }
        public ManagerIncomeInfoPage(ProductOrderModel worker)
        {
            InitializeComponent();

            _worker = worker;
            if (worker != null)
            {
                DataContext = new Graph(worker.Order.Worker);
                GetClientData();

            }

        }

        private List<ProductOrderModel> _productOrder;
        private async void GetClientData()
        {
            try
            {
                string url = "http://eldocode.makievksy.ru.com/api/ProductOrder";
                HttpClient client = new HttpClient();

                var response = await client.GetAsync(url);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    _productOrder = JsonConvert.DeserializeObject<List<ProductOrderModel>>(responseContent);
                    PermanentData.ProductClientOrder = _productOrder;
                    GridClients.ItemsSource = _productOrder.Where(x => x.Order.Worker.Id == _worker.Id && x.Order.Status.Id == 2).ToList();

                    var previousMonth = DateTime.Now;

                    TxtAmount.Text = _productOrder.Where(x => x.Order.Worker.Id == _worker.Id).Select(x => x.Order.Client).Count().ToString();
                    TxtAmountPlus.Text = "+ " + _productOrder.Where(x => x.Order.DateCreated.Month == previousMonth.AddMonths(-1).Month && x.Order.Worker.Id == _worker.Id).Count().ToString();

                    TxtFinishedAmount.Text = _productOrder.Where(x => x.Order.Worker.Id == _worker.Id && x.Order.Status.Id == 2).Count().ToString();
                    TxtFinishedAmountPlus.Text = "+ " + _productOrder.Where(x => x.Order.Worker.Id == _worker.Id && x.Order.Status.Id == 2 && x.Order.DateCreated.Month == previousMonth.Month).Count().ToString();

                    TxtProductAmount.Text = _productOrder.Where(x => x.Order.Worker.Id == _worker.Id && x.Order.Status.Id == 2).Sum(x => x.Amount).ToString();
                    TxtProductPlus.Text = "+ " + _productOrder.Where(x => x.Order.Worker.Id == _worker.Id && x.Order.Status.Id == 2 && x.Order.DateCreated.Month == previousMonth.AddMonths(-1).Month).Sum(x => x.Amount).ToString();
                }
            }
            catch (Exception er)
            {

                er.Message.ToString();
            }
        }
    }
}
