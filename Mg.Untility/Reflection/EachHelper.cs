using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AH.Untility.Reflection
{
    public class EachHelper
    {
        public static void EachListHeader(object list, Action<int, string, Type> handle)
        {
            var index = 0;
            var dict = GenericUtil.GetListProperties(list);
            foreach (var item in dict)
                handle(index++, item.Key, item.Value);
        }

        public static void EachListRow(object list, Action<int, object> handle)
        {
            var index = 0;
            IEnumerator enumerator = ((dynamic)list).GetEnumerator();
            while (enumerator.MoveNext())
                handle(index++, enumerator.Current);
        }

        public static void EachObjectProperty(object row, Action<int, string, object> handle)
        {
            var index = 0;
            var dict = GenericUtil.GetDictionaryValues(row);
            foreach (var item in dict)
                handle(index++, item.Key, item.Value);
        }

        public static IDictionary<string,object> EachObject(DataRow row)
        { 
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            foreach (DataColumn col in row.Table.Columns)
            {
                dictionary.Add(col.ColumnName, row[col]);
            }
            return dictionary;
        }

        
    }
}
