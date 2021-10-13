using EldoCodeDesktop.AppData;
using EldoCodeDesktop.Model;
using Microsoft.Win32;
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
    /// Логика взаимодействия для EditPage.xaml
    /// </summary>
    public partial class EditPage : Page
    {
        public EditPage()
        {
            InitializeComponent();

            GetProduct();
            GetCategory();
            GetFirm();
        }

        private string _path;
        byte[] _imageToByte;
        private ProductModel _selectedProduct;
        private List<ProductModel> _product;
        private List<CategoryModel> _category;
        private List<FirmModel> _firm;
        private void GetProduct()
        {
            try
            {
                string url = "http://eldocode.makievksy.ru.com/api/Product";
                WebRequest webRequest = WebRequest.Create(url);

                var response = webRequest.GetResponse();
                string jsonString = string.Empty;

                using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                {
                    jsonString = sr.ReadToEnd();
                }

                _product = JsonConvert.DeserializeObject<List<ProductModel>>(jsonString);
                ListProduct.ItemsSource = _product;

                DataContext = null;
            }
            catch (Exception er)
            {

                er.Message.ToString();
            }
        }

        private void GetCategory()
        {
            try
            {
                string url = "http://eldocode.makievksy.ru.com/api/Category";
                WebRequest webRequest = WebRequest.Create(url);

                var response = webRequest.GetResponse();
                string jsonString = string.Empty;

                using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                {
                    jsonString = sr.ReadToEnd();
                }

                _category = JsonConvert.DeserializeObject<List<CategoryModel>>(jsonString);
                CmbxCategory.ItemsSource = _category;

                CmbxCategory.SelectedValuePath = "Id";
                CmbxCategory.DisplayMemberPath = "Name";

                CmbxCategory.SelectedIndex = 0;
            }
            catch (Exception er)
            {

                er.Message.ToString();
            }
        }

        private void GetFirm()
        {
            try
            {
                string url = "http://eldocode.makievksy.ru.com/api/Firm";
                WebRequest webRequest = WebRequest.Create(url);

                var response = webRequest.GetResponse();
                string jsonString = string.Empty;

                using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                {
                    jsonString = sr.ReadToEnd();
                }

                _firm = JsonConvert.DeserializeObject<List<FirmModel>>(jsonString);
                CmbxFirm.ItemsSource = _firm;

                CmbxFirm.SelectedValuePath = "Id";
                CmbxFirm.DisplayMemberPath = "Name";

                CmbxFirm.SelectedIndex = 0;

            }
            catch (Exception er)
            {

                er.Message.ToString();
            }
        }

        private void BtnAddPhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                _path = openFileDialog.FileName;
                ImgPhoto.Source = new BitmapImage(new Uri(openFileDialog.FileName, UriKind.Relative));
            }
        }

        private async void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_path != null)
                    _imageToByte = File.ReadAllBytes(_path);
                else
                    _imageToByte = _selectedProduct.Photo;

                string url = "http://eldocode.makievksy.ru.com/api/Product?option=2";

                decimal number = Convert.ToDecimal(TxtPrice.Text.Replace('.', ','));
                var request = new ProductModel()
                {
                    Id = _selectedProduct.Id,
                    Name = TxtName.Text,
                    Price = number,
                    Description = TxtDescription.Text,
                    VendorCode = TxtArticle.Text,
                    Photo = _imageToByte,
                    Category = CmbxCategory.SelectedItem as CategoryModel,
                    Firm = CmbxFirm.SelectedItem as FirmModel
                };

                HttpClient httpClient = new HttpClient();

                var requestJson = JsonConvert.SerializeObject(request);
                StringContent sc = new StringContent(requestJson, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync(url, sc);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    DefaultMessage.InformationMessage("Данные сохранены!");


                    PermanentData.FrameProduct.Navigate(new EditPage());
                }
            }
            catch (Exception er)
            {

                er.Message.ToString();
            }
        }

        private void ListProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selectedProduct = ListProduct.SelectedItem as ProductModel;
            DataContext = _selectedProduct;
        }

        private void StackPanel_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] vs = (string[])e.Data.GetData(DataFormats.FileDrop);
                ImgPhoto.Source = new BitmapImage(new Uri(vs[0]));
                _path = vs[0];
            }
        }
    }

}
