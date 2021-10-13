using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EldoCodeDesktop.AppData
{
    public class ValidationEmpryFields
    {
        public static bool IsFieldEmpty(params string[] textData)
        {
            foreach(string text in textData)
            {
                if (string.IsNullOrEmpty(text))
                    return true;
            }

            return false;
        }
    }
}
