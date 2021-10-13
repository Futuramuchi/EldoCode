using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace EldoCodeDesktop.Model
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public FirmModel Firm { get; set; }
        public string VendorCode { get; set; }
        public CategoryModel Category { get; set; }
        public decimal? Price { get; set; }
        public string Description { get; set; }
        public byte[] Photo { get; set; }

        public BitmapImage GetPhoto
        {
            get
            {   
                if (Photo == null)
                {
                    return new BitmapImage(new Uri("/Resources/order.png", UriKind.Relative));
                }
                else 
                {
                    MemoryStream strmImg = new MemoryStream(Photo);
                    BitmapImage myBitmapImage = new BitmapImage();
                    myBitmapImage.BeginInit();
                    myBitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    myBitmapImage.StreamSource = strmImg;
                    myBitmapImage.DecodePixelWidth = 200;
                    myBitmapImage.EndInit();

                    return myBitmapImage;
                }

            }
        }

    }
}
