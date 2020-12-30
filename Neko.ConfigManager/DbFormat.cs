using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neko.ConfigManager
{
    public class DbFormatConst
    {
        public const string Server = "Server";
        public const string Database = "Database";
        public const string Uid = "Uid";
        public const string Pwd = "Pwd";
    }
    public class MysqlDbFormat
    {
        public string Server;
        public string Database;
        public string Uid;
        public string Pwd;
    }
}
