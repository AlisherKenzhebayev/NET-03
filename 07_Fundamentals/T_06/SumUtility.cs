using System.Text;
using System.Xml;

namespace U07_Fundamentals.T_06
{
    using System;
    using System.Linq;
    using System.Security;

    public static class SumUtility
    {
        public static string SumTwoBigOnesAndPositive(string first, string second)
        {
            if (second.Length > first.Length)
            {
                var t = first;
                first = second;
                second = t;
            }

            var retRev = new StringBuilder();
            using var firste = first.Reverse().GetEnumerator();
            using var seconde = second.Reverse().GetEnumerator();
            var reserve = 0;
            do
            {
                if (!char.IsDigit(firste.Current)) continue;
                var sum = (firste.Current - '0') + (char.IsDigit(seconde.Current) ? (seconde.Current - '0') : 0) + reserve;
                reserve = sum / 10;
                sum %= 10;
                retRev = retRev.Insert(0, sum.ToString());
            }
            while (firste.MoveNext() | seconde.MoveNext());

            return retRev.ToString();
        }
    }
}