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
    /// Interaction logic for ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page
    {
        public ProductPage()
        {
            InitializeComponent();

            PermanentData.FrameProduct = FrameProduct;
            PermanentData.FrameProduct.Navigate(new ABCAnalusysPage());

        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            PermanentData.FrameProduct.Navigate(new EditPage());
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            PermanentData.FrameProduct.Navigate(new AddPage());
        }

        private void BtnABC_Click(object sender, RoutedEventArgs e)
        {
            PermanentData.FrameProduct.Navigate(new ABCAnalusysPage());
        }
    }
}
