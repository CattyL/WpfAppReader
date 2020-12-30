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
        /// <summary>
        /// SqlServer数据库
        /// </summary>
        [EnumDisplayText("SqlServer数据库")]
        SqlServer,
        /// <summary>
        /// Oracle数据库
        /// </summary>
        [EnumDisplayText("Oracle数据库")]
        Oracle,
        /// <summary>
        /// SQLite数据库
        /// </summary>
        [EnumDisplayText("SQLite数据库")]
        SQLite,
        /// <summary>
        /// MySql数据库
        /// </summary>
        [EnumDisplayText("MySql数据库")]
        MySql,
        /// <summary>
        /// 无
        /// </summary>
        [EnumDisplayText("无")]
        None
    }
}
