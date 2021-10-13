using EldoCodeDesktop.AppData;
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
    /// Логика взаимодействия для CRMPage.xaml
    /// </summary>
    public partial class CRMPage : Page
    {
        public CRMPage()
        {
            InitializeComponent();

            PermanentData.CrmFrame = FrameCRM;
            PermanentData.CrmFrame.Navigate(new ManagerDefPage());

            GetWorkerData();
            GetRegionData();
        }

        private List<RegionModel> _region;
        private void GetRegionData()
        {
            try
            {
                string url = "http://eldocode.makievksy.ru.com/api/Region";
                WebRequest webRequest = WebRequest.Create(url);

                var response = webRequest.GetResponse();
                string jsonString = string.Empty;

                using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                {
                    jsonString = sr.ReadToEnd();
                }

                _region = JsonConvert.DeserializeObject<List<RegionModel>>(jsonString);
                CmbxRegion.ItemsSource = _region;

                CmbxRegion.SelectedValuePath = "Id";
                CmbxRegion.DisplayMemberPath = "Name";
                CmbxRegion.SelectedIndex = 0;
            }
            catch (Exception er)
            {
                er.Message.ToString();
            }
        }




        private List<ProductOrderModel> _worker;
        private async void GetWorkerData()
        {
            string url = "http://eldocode.makievksy.ru.com/api/ProductOrder";
            HttpClient client = new HttpClient();

            var response = await client.GetAsync(url);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                _worker = JsonConvert.DeserializeObject<List<ProductOrderModel>>(responseContent);
                ListWorker.ItemsSource = _worker.GroupBy(x => x.Order.Worker.Id).Select(x => x.FirstOrDefault());
            }

        }

        private ProductOrderModel _selectedWorker;
        private void ListWorker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selectedWorker = ListWorker.SelectedItem as ProductOrderModel;
            PermanentData.CrmFrame.Navigate(new ManagerIncomeInfoPage(_selectedWorker));
        }

        private void CmbxRegion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedRegion = Convert.ToInt32(CmbxRegion.SelectedValue);
            ListWorker.ItemsSource = _worker.Where(x => x.Order.Worker.Store.Region.Id == selectedRegion).GroupBy(x => x.Order.Worker.Id).Select(x => x.FirstOrDefault()).ToList();
        }



    }
}
