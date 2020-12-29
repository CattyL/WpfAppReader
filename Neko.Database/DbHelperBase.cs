﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Neko.Database
{
    /// <summary>
    /// 
    /// </summary>
    public class DbHelperBase : IDbHelper
    {
        private int CONNECTION_MANAGER_THREAD_SLEEP_TIME_SPAN = 100;
        private int CONNECTION_TIME_OUT = 3000;
        private int COMMAND_TIME_OUT = 30;
        private Thread m_connectionManagerThread;
        private object m_lockConnection;
        private bool isRunning;
        private List<DbConnection> m_connections;


        /// <summary>
        /// 是否运行
        /// </summary>
        internal bool IsRunning
        {
            get => isRunning;
            set => isRunning = value;
        }

        /// <summary>
        /// 关闭连接
        /// </summary>
        public void Close()
        {
            Dispose();
        }

        /// <summary>
        /// 设置超时时间
        /// </summary>
        /// <param name="time">超时时间（单位：秒）</param>
        public virtual void CommandTimeOut(int time)
        {
            COMMAND_TIME_OUT = time;
        }

        /// <summary>
        /// 创建SQL命令
        /// </summary>
        /// <returns></returns>
        public virtual DbCommand CreateCommand()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 创建SQL命令
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public virtual DbCommand CreateCommand(string sql)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 创建参数(默认可为空)
        /// </summary>
        /// <param name="name">参数名</param>
        /// <param name="value">参数值</param>
        /// <param name="isNullable">是否可为空(默认可为空)</param>
        /// <returns></returns>
        public virtual DbParameter CreateParameter(string name, object value, bool isNullable = true)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 创建参数
        /// </summary>
        /// <param name="name">参数名</param>
        /// <param name="value">参数值</param>
        /// <param name="dbType">Specifies the data type of a field, a property, or a Parameter object of a .NET</param>
        /// <param name="isNullable">默认可为空</param>
        /// <returns></returns>
        public virtual DbParameter CreateParameter(string name, object value, DbType dbType, bool isNullable = true)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 关闭连接释放资源
        /// </summary>
        public void Dispose()
        {
            isRunning = false;
            Thread.Sleep(CONNECTION_MANAGER_THREAD_SLEEP_TIME_SPAN);
            int index = 0;
            while(index <= m_connections.Count)
            {
                try
                {
                    if (m_connections[index].State == ConnectionState.Open)
                        m_connections[index].Close();
                }
                catch
                {

                }

                m_connections[index].Dispose();
                index++;
            }
            m_connections.Clear();
            GC.Collect();
        }
        /// <summary>
        /// 删除表
        /// </summary>
        /// <param name="tableName">表名</param>
        public void DropTable(string tableName)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 转义字符
        /// </summary>
        /// <returns>转换后的字符</returns>
        public string EscapeFromString(string value)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 执行SQL命令
        /// </summary>
        /// <param name="comm">表示要对数据源执行的 SQL 语句或存储过程。 提供表示命令的数据库特定类的基类</param>
        /// <returns>是否成功执行</returns>
        public virtual bool ExecuteNonQuery(DbCommand comm)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 执行Command
        /// </summary>
        /// <param name="tran">事务的基类</param>
        /// <param name="comm">表示要对数据源执行的 SQL 语句或存储过程。 提供表示命令的数据库特定类的基类</param>
        /// <returns>是否成功执行</returns>
        public virtual bool ExecuteNonQuery(DbTransaction tran, DbCommand comm)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns>是否成功执行</returns>
        public virtual bool ExecuteNonQuery(string sql)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="tran">事务的基类</param>
        /// <param name="sql"></param>
        /// <returns>是否成功执行</returns>
        public virtual bool ExecuteNonQuery(DbTransaction tran, string sql)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="lstParameters">参数列表</param>
        /// <returns></returns>
        public virtual bool ExecuteNonQuery(string sql, IEnumerable<DbParameter> lstParameters)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="fun">获取数据后的处理函数</param>
        public virtual void ExecuteReader(string sql, Func<DbDataReader, bool> fun)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 执行SQL语句获取数据
        /// </summary>
        /// <param name="tran">事务的基类</param>
        /// <param name="sql">SQL语句</param>
        /// <param name="fun">获取数据后的处理函数</param>
        public virtual void ExecuteReader(DbTransaction tran, string sql, Func<DbDataReader, bool> fun)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 执行Command获取数据
        /// </summary>
        /// <param name="comm">表示要对数据源执行的 SQL 语句或存储过程。 提供表示命令的数据库特定类的基类</param>
        /// <param name="fun">获取数据后的处理函数</param>
        public virtual void ExecuteReader(DbCommand comm, Func<DbDataReader, bool> fun)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 执行Command获取数据
        /// </summary>
        /// <param name="tran">事务的基类</param>
        /// <param name="comm">表示要对数据源执行的 SQL 语句或存储过程。 提供表示命令的数据库特定类的基类</param>
        /// <param name="fun">获取数据后的处理函数</param>
        public virtual void ExecuteReader(DbTransaction tran, DbCommand comm, Func<DbDataReader, bool> fun)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 执行SQL语句获第一个取数据
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns></returns>
        public virtual object ExecuteScalar(string sql)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 执行Command获第一个取数据
        /// </summary>
        /// <param name="comm">表示要对数据源执行的 SQL 语句或存储过程。 提供表示命令的数据库特定类的基类</param>
        /// <returns></returns>
        public virtual object ExecuteScalar(DbCommand comm)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 执行Command获第一个取数据
        /// </summary>
        /// <param name="tran">事务的基类</param>
        /// <param name="comm">表示要对数据源执行的 SQL 语句或存储过程。 提供表示命令的数据库特定类的基类</param>
        /// <returns></returns>
        public virtual object ExecuteScalar(DbTransaction tran, DbCommand comm)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取SQL命令中的sql语句
        /// </summary>
        /// <param name="comm">表示要对数据源执行的 SQL 语句或存储过程。 提供表示命令的数据库特定类的基类</param>
        /// <returns></returns>
        public virtual string GetSqlString(DbCommand comm)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        ///  表是否存在
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        public virtual bool IsExistsTabele(string tableName)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 表是否存在
        /// </summary>
        /// <param name="tran">事务</param>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        public virtual bool IsExistsTabele(DbTransaction tran, string tableName)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 分页取数据
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="pageSize">每页显示记录数</param>
        /// <param name="pageIndex">当前页数从1开始</param>
        /// <param name="tran">事务</param>
        /// <returns>返回当前数据</returns>
        public virtual IList<Dictionary<string, object>> PagingSearch(string sql, int pageSize, int pageIndex, DbTransaction tran = null)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 分页取数据
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="orderby">sql server要单独指定排序字段</param>
        /// <param name="pageSize">每页显示记录数</param>
        /// <param name="pageIndex">当前页数从1开始</param>
        /// <param name="tran">事务</param>
        /// <returns>返回当前数据</returns>
        public virtual IList<Dictionary<string, object>> PagingSearch(string sql, string orderby, int pageSize, int pageIndex, DbTransaction tran = null)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 大批量插入数据（仅限SQLSERVER）
        /// </summary>
        /// <param name="dt">数据</param>
        /// <param name="tableName">表名</param>
        public virtual void SqlBulkCopyByDatatable(DataTable dt, string tableName)
        {
            throw new NotImplementedException();
        }
    }
}