using EldoCodeDesktop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EldoCodeDesktop.AppData
{
    public class PermanentData
    {
        public static Frame Frame { get; set; }
        public static Frame FrameProduct { get; set; }
        public static List<ProductOrderModel> ProductOrder { get; set; }
        public static List<ProductOrderModel> ProductClientOrder { get; set; }
        public static List<ProductOrderModel> ProductAnalyseOrder { get; set; }
        public static Frame CrmFrame { get; set; }
    }
}
