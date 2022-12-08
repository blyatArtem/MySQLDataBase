using System;
using System.Collections.Generic;
using System.Text;

namespace MySQLDataBase
{
    public class SQLRow
    {
        internal SQLRow()
        {
            values = new List<object>();
        }

        public override string ToString()
        {
            return string.Join(" ", values);
        }

        public List<object> values;
    }
}
