using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Neko.ConfigManager;

namespace Neko.Database
{
    /// <summary>
    /// MySQL数据库操作类
    /// </summary>
    public class MySqlDbHelper : DbHelperBase
    {
        private MysqlDbFormat dbFormat;

        /// <summary>
        /// 
        /// </summary>
        public string Server { get => dbFormat.Server; }
        /// <summary>
        /// 
        /// </summary>
        public string Database { get => dbFormat.Database; }
        /// <summary>
        /// 
        /// </summary>
        public string Uid { get => dbFormat.Uid; }
        /// <summary>
        /// 
        /// </summary>
        public string Pwd { get => dbFormat.Pwd; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public MySqlDbHelper(string connection)
        {
            connectionstring = connection;
            databasetype = eDatabaseType.MySql;
            dbFormat = new MysqlDbFormat();
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connection);
            dbFormat.Server = builder[dbFormat.Server].ToString();
            dbFormat.Database = builder[dbFormat.Database].ToString();
            dbFormat.Uid = builder[dbFormat.Uid].ToString();
            dbFormat.Pwd = builder[dbFormat.Pwd].ToString();
        }

        /// <summary>
        /// 创建SQL命令
        /// </summary>
        /// <returns>表示要对数据源执行的 SQL 语句或存储过程。 提供表示命令的数据库特定类的基类</returns>
        public override DbCommand CreateCommand()
        {
            return CreateCommand(string.Empty);
        }

        /// <summary>
        /// 创建SQL命令
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns>表示要对数据源执行的 SQL 语句或存储过程。 提供表示命令的数据库特定类的基类</returns>
        public override DbCommand CreateCommand(string sql)
        {
            MySqlCommand command = new MySqlCommand();
            command.CommandTimeout = COMMAND_TIME_OUT;
            command.CommandText = sql;
            return command;
        }


    }
}
