using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Facebook_Prep.NaturalSortCompare
{
    public class NaturalSortComparer<T> : IComparer<string>, IDisposable
    {
        private const string RegexString = @"([0-9]+([0-9]+)?)";
        private static  StringComparison StringComparison = StringComparison.Ordinal;
        private Dictionary<string, string[]> table = new Dictionary<string, string[]>();
        private readonly bool isAscending;

        public NaturalSortComparer(bool isAscending = true)
        {
            this.isAscending = isAscending;
        }

        public int Compare(string x, string y)
        {
            if (x == y)
                return 0;

            string[] x1, y1;
            int returnVal;
            if (!table.TryGetValue(x, out x1))
            {
                x1 = Regex.Split(x.Replace(" ", ""), RegexString);
                table.Add(x, x1);
            }
            if (!table.TryGetValue(y, out y1))
            {
                y1 = Regex.Split(y.Replace(" ", ""), RegexString);
                table.Add(y, y1);
            }
            for (int i = 0; i < x1.Length && i < y1.Length; i++)
            {
                if (x1[i] != y1[i])
                {
                    returnVal = PartCompare(x1[i], y1[i]);
                    return isAscending ? returnVal : -returnVal;
                }
            }
            if (y1.Length > x1.Length)
            {
                returnVal = 1;
            }
            else if (x1.Length > y1.Length)
            {
                returnVal = -1;
            }
            else
            {
                returnVal = 0;
            }

            return isAscending ? returnVal : -returnVal;
        }

        private static int PartCompare(string left, string right)
        {
            decimal x, y;
            if (!decimal.TryParse(left, NumberStyles.Any, CultureInfo.InvariantCulture, out x))
                return String.Compare(left, right, StringComparison);

            if (!decimal.TryParse(right, NumberStyles.Any, CultureInfo.InvariantCulture, out y))
                return String.Compare(left, right, StringComparison);

            return x.CompareTo(y);
        }

        public void Dispose()
        {
            table.Clear();
            table = null;
        }
    }
}
