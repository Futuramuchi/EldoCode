using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EldoCodeDesktop.AppData
{
    public class DefaultMessage
    {
        public static void InformationMessage(string message)
        {
            MessageBox.Show($"{message}", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public static void WarningMessage(string message)
        {
            MessageBox.Show($"{message}", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }
    }
}
