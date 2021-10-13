using EldocCodeApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EldocCodeApi.Helper
{
    public class PermanentData
    {
        public static Order Order { get; set; }
        public static int ProductOrderId { get; set; }
        public static string SecretKey { get; set; }
    }
}