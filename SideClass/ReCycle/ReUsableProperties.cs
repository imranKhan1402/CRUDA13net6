using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SideClass.ReCycle
{
    public static class ReUsableProperties
    {
        public static double ToDouble<T>(this T value) where T : IConvertible
        {
            if (value is null)
            {
                return 0;
            }
            return Convert.ToDouble(value);
        }

        public static int ToInteger<T>(this T value) where T : IConvertible
        {
            if (value is null)
            {
                return 0;
            }
            return Convert.ToInt32(value);
        }
    }
}
