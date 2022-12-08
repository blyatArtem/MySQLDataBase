using System;
using System.Collections.Generic;
using System.Text;

namespace MySQLDataBase
{
    public class SQLColumnInfo
    {

        internal SQLColumnInfo(string columnName, Type columnType)
        {
            this.name = columnName;
            this.type = columnType;
        }
        internal SQLColumnInfo()
        {

        }

        public override string ToString()
        {
            return name;
            //return $"{{{name}, {type.Name}}}";
        }

        public string name;
        public Type type;
    }
}
