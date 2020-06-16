using System;

namespace Eims.Core
{
    public static class Toos
    {
        public static int getIntByString(string str)
        {
            return Convert.ToInt32(System.Text.RegularExpressions.Regex.Replace(str, @"[^0-9]+", ""));
        }
    }
}
