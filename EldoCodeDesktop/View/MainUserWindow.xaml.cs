using EldoCodeDesktop.AppData;
using EldoCodeDesktop.Model;
using EldoCodeDesktop.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EldoCodeDesktop.View
{
    /// <summary>
    /// Логика взаимодействия для MainUserWindow.xaml
    /// </summary>
    public partial class MainUserWindow : Window
    {
        public MainUserWindow()
        {
            InitializeComponent();

            PermanentData.Frame = FrameBody;
            PermanentData.Frame.Navigate(new AnalyticsPage());

        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void BtnRoll_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void BtnCRM_Click(object sender, RoutedEventArgs e)
        {
            PermanentData.Frame.Navigate(new CRMPage());

        }

        private void BtnAnalytics_Click(object sender, RoutedEventArgs e)
        {
            PermanentData.Frame.Navigate(new AnalyticsPage());

        }

        private void BtnProduct_Click(object sender, RoutedEventArgs e)
        {
            PermanentData.Frame.Navigate(new ProductPage());

        }
    }
}
