using EldoCodeDesktop.AppData;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace EldoCodeDesktop.Model
{
    public class ProductOrderModel
    {
        public int Id { get; set; }
        public OrderModel Order { get; set; }
        public int Amount { get; set; }
        public ProductModel Product { get; set; }


        public BitmapImage GetPhoto
        {
            get
            {
                if (Product.Photo == null)
                {
                    return new BitmapImage(new Uri("/Resources/order.png", UriKind.Relative));
                }
                else
                {
                    MemoryStream strmImg = new MemoryStream(Product.Photo);
                    BitmapImage myBitmapImage = new BitmapImage();
                    myBitmapImage.BeginInit();
                    myBitmapImage.StreamSource = strmImg;
                    myBitmapImage.DecodePixelWidth = 200;
                    myBitmapImage.EndInit();

                    return myBitmapImage;
                }
            }
        }

        private decimal? _totalSum;
        public double GetTotalWidth
        {
            get
            {
                _totalSum = PermanentData.ProductOrder.Where(x => x.Order.Status.Id == 2).Sum(x => x.Product.Price * Amount);
                return (double)_totalSum / 1000;
            }
        }

        public double GetWidth
        {
            get
            {
                var monthSum = PermanentData.ProductOrder.Where(x => x.Order.DateCreated.Month == DateTime.Now.Month && x.Order.Status.Id == 2).Sum(x => x.Product.Price * Amount);
                return (double)(monthSum * 100 / _totalSum);
            }
        }

        public string GetCurrentIncome
        {
            get
            {
                var monthIncome = PermanentData.ProductOrder.Where(x => x.Order.DateCreated.Month == DateTime.Now.Month && x.Order.Status.Id == 2).Sum(x => x.Product.Price * Amount);
                return Math.Round((decimal)monthIncome, 2).ToString() + " руб.";
            }
        }

        public string GetClientName
        {
            get
            {
                if (Order.Client.FirstName != string.Empty)
                    return $"{Order.Client.FirstName}";
                else
                    return "Нет";
            }
        }

        public string LastOrderDate
        {
            get
            {
                var lastDate = PermanentData.ProductClientOrder.OrderByDescending(x => x.Order.DateCreated).Select(x => x.Order.DateCreated).First();
                return lastDate.ToShortDateString();
            }
        }

        public string FavouriteCategory
        {
            get
            {
                var res = PermanentData.ProductClientOrder.GroupBy(el => el.Product.Category.Id).OrderByDescending(el => el.Count()).Select(x => x.Key).First();
                var neededCategory = PermanentData.ProductClientOrder.Where(x => x.Product.Category.Id == res).Select(x => x.Product.Category.Name).FirstOrDefault();

                return neededCategory;
            }
        }


        public BitmapImage GetUserPhoto
        {
            get
            {
                if (Order.Worker.Photo == null)
                {
                    return new BitmapImage(new Uri("/Resources/person.png", UriKind.Relative));
                }
                else
                {
                    MemoryStream strmImg = new MemoryStream(Order.Worker.Photo);
                    BitmapImage myBitmapImage = new BitmapImage();
                    myBitmapImage.BeginInit();
                    myBitmapImage.StreamSource = strmImg;
                    myBitmapImage.DecodePixelWidth = 200;
                    myBitmapImage.EndInit();

                    return myBitmapImage;
                }
            }
        }

        public string GetFullName
        {
            get
            {
                return $"{Order.Worker.MiddleName} {Order.Worker.FirstName} {Order.Worker.LastName}";
            }
        }


        public double GetTotal
        {
            get
            {
                return (double)PermanentData.ProductAnalyseOrder.Where(x => x.Order.DateCreated.Month == Order.DateCreated.Month && x.Product.Id == Product.Id).Sum(x => x.Product.Price);
            }
        }

        public double GetWeight
        {
            get
            {
                double total = PermanentData.ProductAnalyseOrder.Sum(x => x.GetTotal);
                return Math.Round((double)(GetTotal / total / 100), 4);
            }
        }

        public double GetOrd
        {
            get
            {
                for (int i = 0; i < PermanentData.ProductAnalyseOrder.Count;)
                {
                    if (i == 0)
                        return GetWeight;
                    else
                        return Math.Round(GetWeight + PermanentData.ProductAnalyseOrder[i - 1].GetOrd, 4);
                }

                return 0;
            }
        }


        public double GetWeightK
        {
            get
            {
                double total = PermanentData.ProductAnalyseOrder.Where(x => x.Order.DateCreated.Month == Order.DateCreated.Month && x.Product.Id == Product.Id).Count();

                return Math.Round(1 / total / 100, 4);
            }
        }

        public double GetAbsc
        {
            get
            {
                for (int i = 0; i < PermanentData.ProductAnalyseOrder.Count; i++)
                {
                    if (i == 0)
                        return GetWeightK;
                    else
                        return Math.Round(GetWeightK + PermanentData.ProductAnalyseOrder[i - 1].GetAbsc, 4);
                }

                return 0;
            }
        }

        public double CMethod
        {
            get
            {
                return GetOrd + GetAbsc;
            }
        }

        public string GetLetter
        {
            get
            {
                if (CMethod < 1)
                    return "A";
                if (CMethod == 1 || CMethod < 1.45f)
                    return "B";
                else
                {
                    return "C";
                }
            }
        }
    }
}
