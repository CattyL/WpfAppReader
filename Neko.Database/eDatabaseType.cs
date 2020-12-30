using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neko.Database
{
    /// <summary>
    /// 数据库类型
    /// </summary>
    public enum eDatabaseType
    {
        [EnumDisplayText("SqlServer数据库")]
        SqlServer,
        [EnumDisplayText("Oracle数据库")]
        Oracle,
        [EnumDisplayText("SQLite数据库")]
        SQLite,
        [EnumDisplayText("MySql数据库")]
        MySql,
        [EnumDisplayText("无")]
        None
    }
}
