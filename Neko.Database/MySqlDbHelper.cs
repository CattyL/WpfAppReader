using System;
using System.Collections.Generic;
using System.Data;
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
        public override IDbCommand CreateCommand()
        {
            return CreateCommand(string.Empty);
        }

        /// <summary>
        /// 创建SQL命令
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns>表示要对数据源执行的 SQL 语句或存储过程。 提供表示命令的数据库特定类的基类</returns>
        public override IDbCommand CreateCommand(string sql)
        {
            MySqlCommand command = new MySqlCommand
            {
                CommandTimeout = COMMAND_TIME_OUT,
                CommandText = sql
            };
            return command;
        }

        /// <summary>
        /// 创建参数
        /// </summary>
        /// <param name="name">参数名</param>
        /// <param name="value">参数值</param>
        /// <returns></returns>
        public override DbParameter CreateParameter(string name, object value)
        {
            if (value == null)
                value = DBNull.Value;
            MySqlParameter mySqlParameter = new MySqlParameter(name, value);
            return mySqlParameter;
        }

        /// <summary>
        /// 创建参数
        /// </summary>
        /// <param name="name">参数名</param>
        /// <param name="value">参数值</param>
        /// <param name="dbType">Specifies the data type of a field, a property, or a Parameter object of a .NET</param>
        /// <returns></returns>
        public override DbParameter CreateParameter(string name, object value, DbType dbType)
        {
            if (value == null)
                value = DBNull.Value;
            MySqlParameter mySqlParameter = new MySqlParameter(name, value)
            {
                DbType = dbType
            };
            return mySqlParameter;
        }

        /// <summary>
        /// 执行SQL命令
        /// </summary>
        /// <param name="comm">表示要对数据源执行的 SQL 语句或存储过程。 提供表示命令的数据库特定类的基类</param>
        /// <returns>是否成功执行</returns>
        public override int ExecuteNonQuery(IDbCommand comm)
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(connectionstring))
            {
                mySqlConnection.Open();
                try
                {
#if DEBUG
                    Console.WriteLine(comm.CommandText);
#endif
                    comm.CommandTimeout = COMMAND_TIME_OUT;
                    comm.Connection = mySqlConnection;
                    return comm.ExecuteNonQuery();
                }
                catch
                {
                    if (comm != null)
                        comm.Dispose();
                    throw;
                }
                finally
                {
                    mySqlConnection.Close();
                }
            }
        }

        /// <summary>
        /// 执行Command
        /// </summary>
        /// <param name="tran">事务的基类</param>
        /// <param name="comm">表示要对数据源执行的 SQL 语句或存储过程。 提供表示命令的数据库特定类的基类</param>
        /// <returns>受影响的行数</returns>
        public override int ExecuteNonQuery(IDbTransaction tran, IDbCommand comm)
        {
            using (MySqlConnection mySqlConnection = (MySqlConnection)tran.Connection)
            {
                mySqlConnection.Open();
                try
                {
#if DEBUG
                    Console.WriteLine(comm.CommandText);
#endif
                    comm.CommandTimeout = COMMAND_TIME_OUT;
                    comm.Connection = mySqlConnection;
                    comm.Transaction = tran;
                    return comm.ExecuteNonQuery();
                }
                catch
                {
                    tran.Rollback();
                    if (comm != null)
                        comm.Dispose();
                    throw;
                }
            }
                
        }

        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="tran">事务的基类</param>
        /// <param name="sql"></param>
        /// <returns>是否成功执行</returns>
        public override int ExecuteNonQuery(IDbTransaction tran, string sql)
        {
            MySqlCommand mySqlCommand = new MySqlCommand(sql);
            return ExecuteNonQuery(tran, mySqlCommand);
        }

        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns>是否成功执行</returns>
        public override int ExecuteNonQuery(string sql)
        {
            MySqlCommand mySqlCommand = new MySqlCommand(sql);
            return ExecuteNonQuery(mySqlCommand);
        }

        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="lstParameters">参数列表</param>
        /// <returns>受影响的行数</returns>
        public override int ExecuteNonQuery(string sql, IEnumerable<DbParameter> lstParameters)
        {
            MySqlCommand comm = new MySqlCommand(sql);
            return ExecuteNonQuery(comm, lstParameters);
        }

        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="tran">事务</param>
        /// <param name="lstParameters">参数列表</param>
        /// <returns>受影响的行数</returns>
        public override int ExecuteNonQuery(string sql, IDbTransaction tran, IEnumerable<DbParameter> lstParameters)
        {
            MySqlCommand mySqlCommand = new MySqlCommand(sql);
            return ExecuteNonQuery(mySqlCommand, tran, lstParameters);
        }

        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="comm">表示要对数据源执行的 SQL 语句或存储过程。 提供表示命令的数据库特定类的基类</param>
        /// <param name="tran">事务</param>
        /// <param name="lstParameters">参数列表</param>
        /// <returns>受影响的行数</returns>
        public override int ExecuteNonQuery(IDbCommand comm, IDbTransaction tran, IEnumerable<DbParameter> lstParameters)
        {
            using (MySqlConnection mySqlConnection = (MySqlConnection)tran.Connection)
            {
                mySqlConnection.Open();
                try
                {
                    comm.CommandTimeout = COMMAND_TIME_OUT;
                    comm.Connection = mySqlConnection;
                    if (lstParameters != null)
                    {
                        foreach (var item in lstParameters)
                        {
                            comm.Parameters.Add(item);
#if DEBUG
                            Console.WriteLine("item.ParameterName:" + item.ParameterName + " " + "item.Value:" + item.Value);
#endif
                        }
                    }
                    var result = comm.ExecuteNonQuery();
                    return result;
                }
                catch
                {
                    tran.Rollback();
                    throw;
                }
                finally
                {
                    if (comm != null)
                        comm.Dispose();
                    mySqlConnection.Close();
                    mySqlConnection.Dispose();
                }
            }
        }

        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="comm">表示要对数据源执行的 SQL 语句或存储过程。 提供表示命令的数据库特定类的基类</param>
        /// <param name="lstParameters">参数列表</param>
        /// <returns>受影响的行数</returns>
        public override int ExecuteNonQuery(IDbCommand comm, IEnumerable<DbParameter> lstParameters)
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(connectionstring))
            {

                mySqlConnection.Open();
                try
                {
#if DEBUG
                    Console.WriteLine(comm.CommandText);
#endif
                    comm.CommandTimeout = COMMAND_TIME_OUT;
                    comm.Connection = mySqlConnection;
                    if (lstParameters != null)
                        foreach (var item in lstParameters)
                        {
                            comm.Parameters.Add(item);
#if DEBUG
                            Console.WriteLine("item.ParameterName:" + item.ParameterName + " " + "item.Value:" + item.Value);
#endif
                        }
                    return comm.ExecuteNonQuery();
                }
                catch
                {
                    if (comm != null)
                        comm.Dispose();
                    throw;
                }
                finally
                {
                    mySqlConnection.Close();
                }

            }
        }

        /// <summary>
        /// 执行Command获取数据
        /// </summary>
        /// <param name="comm">表示要对数据源执行的 SQL 语句或存储过程。 提供表示命令的数据库特定类的基类</param>
        /// <param name="fun">获取数据后的处理函数</param>
        public override void ExecuteReader(IDbCommand comm, Func<IDataReader, bool> fun)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionstring))
            {
                conn.Open();

                comm.Connection = conn;
                comm.CommandTimeout = COMMAND_TIME_OUT;
                try
                {
#if DEBUG
                    System.Console.WriteLine(comm.CommandText);
#endif
                    using (var reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (fun != null)
                            {
                                if (!fun(reader))
                                    break;
                            }
                        }
                    }
                }
                catch
                {
                    throw;
                }
                finally
                {
                    if (comm != null)
                        comm.Dispose();
                    conn.Close();
                    conn.Dispose();
                }
            }
                
        }

        /// <summary>
        /// 执行Command获取数据
        /// </summary>
        /// <param name="tran">事务的基类</param>
        /// <param name="comm">表示要对数据源执行的 SQL 语句或存储过程。 提供表示命令的数据库特定类的基类</param>
        /// <param name="fun">获取数据后的处理函数</param>
        public override void ExecuteReader(IDbTransaction tran, IDbCommand comm, Func<IDataReader, bool> fun)
        {
            using (MySqlConnection conn = (MySqlConnection)tran.Connection)
            {
                conn.Open();
                try
                {
#if DEBUG
                    Console.WriteLine(comm.CommandText);
#endif
                    comm.Transaction = tran;
                    comm.CommandTimeout = COMMAND_TIME_OUT;
                    using (var reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (fun != null)
                            {
                                if (!fun(reader))
                                    break;
                            }
                        }
                    }
                }
                catch
                {
                    tran.Rollback();
                    throw;
                }
                finally
                {
                    if (comm != null)
                        comm.Dispose();
                    conn.Close();
                    conn.Dispose();
                }
            }

        }

        /// <summary>
        /// 执行SQL语句获取数据
        /// </summary>
        /// <param name="tran">事务的基类</param>
        /// <param name="sql">SQL语句</param>
        /// <param name="fun">获取数据后的处理函数</param>
        public override void ExecuteReader(IDbTransaction tran, string sql, Func<IDataReader, bool> fun)
        {
            MySqlCommand comm = new MySqlCommand(sql);
            ExecuteReader(tran, comm, fun);
        }

        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="fun">获取数据后的处理函数</param>
        public override void ExecuteReader(string sql, Func<IDataReader, bool> fun)
        {
           
        }

    }
}
