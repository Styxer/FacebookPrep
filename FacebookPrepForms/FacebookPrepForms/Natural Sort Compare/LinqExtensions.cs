using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookPrepForms.Natural_Sort_Compare
{
    public static class LinqExtensions
    {
        public static IEnumerable<T> OrderByNatural<T>(
           this IEnumerable<T> source, string propertyName)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (propertyName == null)
                throw new ArgumentNullException("propertyName");

            try
            {
                return source.OrderBy(x => x.GetReflectedPropertyValue(propertyName), new NaturalSortComparer<T>());
            }
            catch
            { }

            return source;
        }

        public static string GetReflectedPropertyValue(this object subject, string field)
        {
            object reflectedValue = subject.GetType().GetProperty(field).GetValue(subject, null);
            return reflectedValue != null ? reflectedValue.ToString() : "";
        }
    }
}
