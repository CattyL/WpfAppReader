using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neko.Database
{
    /// <summary>
    /// 数据库操作接口
    /// </summary>
    public interface IDbHelper : IDisposable
    {
        /// <summary>
        /// 关闭连接
        /// </summary>
        void Close();
        /// <summary>
        /// 创建Command
        /// </summary>
        /// <returns>表示要对数据源执行的 SQL 语句或存储过程。 提供表示命令的数据库特定类的基类</returns>
        IDbCommand CreateCommand();
        /// <summary>
        /// 创建Command
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns>表示要对数据源执行的 SQL 语句或存储过程。 提供表示命令的数据库特定类的基类</returns>
        IDbCommand CreateCommand(string sql);
        /// <summary>
        /// 创建参数(默认可为空)
        /// </summary>
        /// <param name="name">参数名</param>
        /// <param name="value">参数值</param>
        /// <returns>表示 System.Data.Common.DbCommand 的参数，还可以是它到 System.Data.DataSet 列的映射</returns>
        DbParameter CreateParameter(string name, object value);
        /// <summary>
        /// 创建参数
        /// </summary>
        /// <param name="name">参数名</param>
        /// <param name="value">参数值</param>
        /// <param name="dbType">Specifies the data type of a field, a property, or a Parameter object of a .NET</param>
        /// <returns>表示 System.Data.Common.DbCommand 的参数，还可以是它到 System.Data.DataSet 列的映射</returns>
        DbParameter CreateParameter(string name, object value, DbType dbType);
        /// <summary>
        /// 执行SQL命令
        /// </summary>
        /// <param name="comm">表示要对数据源执行的 SQL 语句或存储过程。 提供表示命令的数据库特定类的基类</param>
        /// <returns>受影响的行数</returns>
        int ExecuteNonQuery(IDbCommand comm);
        /// <summary>
        /// 执行Command
        /// </summary>
        /// <param name="tran">事务的基类</param>
        /// <param name="comm">表示要对数据源执行的 SQL 语句或存储过程。 提供表示命令的数据库特定类的基类</param>
        /// <returns>受影响的行数</returns>
        int ExecuteNonQuery(IDbTransaction tran, IDbCommand comm);
        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns>受影响的行数</returns>
        int ExecuteNonQuery(string sql);
        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="tran">事务的基类</param>
        /// <param name="sql"></param>
        /// <returns>受影响的行数</returns>
        int ExecuteNonQuery(IDbTransaction tran, string sql);
        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="lstParameters">参数列表</param>
        /// <returns>受影响的行数</returns>
        int ExecuteNonQuery(string sql, IEnumerable<DbParameter> lstParameters);
        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="tran">事务</param>
        /// <param name="lstParameters">参数列表</param>
        /// <returns>受影响的行数</returns>
        int ExecuteNonQuery(string sql, IDbTransaction tran, IEnumerable<DbParameter> lstParameters);
        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="comm">表示要对数据源执行的 SQL 语句或存储过程。 提供表示命令的数据库特定类的基类</param>
        /// <param name="lstParameters">参数列表</param>
        /// <returns>受影响的行数</returns>
        int ExecuteNonQuery(IDbCommand comm, IEnumerable<DbParameter> lstParameters);
        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="comm">表示要对数据源执行的 SQL 语句或存储过程。 提供表示命令的数据库特定类的基类</param>
        /// <param name="tran">事务</param>
        /// <param name="lstParameters">参数列表</param>
        /// <returns>受影响的行数</returns>
        int ExecuteNonQuery(IDbCommand comm, IDbTransaction tran, IEnumerable<DbParameter> lstParameters);
        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="fun">获取数据后的处理函数</param>
        void ExecuteReader(string sql, Func<IDataReader, bool> fun);
        /// <summary>
        /// 执行SQL语句获取数据
        /// </summary>
        /// <param name="tran">事务的基类</param>
        /// <param name="sql">SQL语句</param>
        /// <param name="fun">获取数据后的处理函数</param>
        void ExecuteReader(IDbTransaction tran, string sql, Func<IDataReader, bool> fun);
        /// <summary>
        /// 执行Command获取数据
        /// </summary>
        /// <param name="comm">表示要对数据源执行的 SQL 语句或存储过程。 提供表示命令的数据库特定类的基类</param>
        /// <param name="fun">获取数据后的处理函数</param>
        void ExecuteReader(IDbCommand comm, Func<IDataReader, bool> fun);
        /// <summary>
        /// 执行Command获取数据
        /// </summary>
        /// <param name="tran">事务的基类</param>
        /// <param name="comm">表示要对数据源执行的 SQL 语句或存储过程。 提供表示命令的数据库特定类的基类</param>
        /// <param name="fun">获取数据后的处理函数</param>
        void ExecuteReader(IDbTransaction tran, IDbCommand comm, Func<IDataReader, bool> fun);
        /// <summary>
        /// 执行SQL语句获第一个取数据
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns></returns>
        object ExecuteScalar(string sql);
        /// <summary>
        /// 执行Command获第一个取数据
        /// </summary>
        /// <param name="comm">表示要对数据源执行的 SQL 语句或存储过程。 提供表示命令的数据库特定类的基类</param>
        /// <returns></returns>
        object ExecuteScalar(IDbCommand comm);
        /// <summary>
        /// 执行Command获第一个取数据
        /// </summary>
        /// <param name="tran">事务的基类</param>
        /// <param name="comm">表示要对数据源执行的 SQL 语句或存储过程。 提供表示命令的数据库特定类的基类</param>
        /// <returns></returns>
        object ExecuteScalar(IDbTransaction tran, IDbCommand comm);
        /// <summary>
        /// 设置超时时间
        /// </summary>
        /// <param name="time">超时时间（单位：秒）</param>
        void CommandTimeOut(int time);
        /// <summary>
        /// 获取SQL命令中的sql语句
        /// </summary>
        /// <param name="comm">表示要对数据源执行的 SQL 语句或存储过程。 提供表示命令的数据库特定类的基类</param>
        /// <returns></returns>
        string GetSqlString(IDbCommand comm);
        /// <summary>
        ///  表是否存在
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        bool IsExistsTabele(string tableName);
        /// <summary>
        /// 表是否存在
        /// </summary>
        /// <param name="tran">事务</param>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        bool IsExistsTabele(IDbTransaction tran, string tableName);
        /// <summary>
        /// 分页取数据
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="pageSize">每页显示记录数</param>
        /// <param name="pageIndex">当前页数从1开始</param>
        /// <param name="tran">事务</param>
        /// <returns>返回当前数据</returns>
        IList<Dictionary<string, object>> PagingSearch(string sql, int pageSize, int pageIndex, IDbTransaction tran = null);
        /// <summary>
        /// 分页取数据
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="orderby">sql server要单独指定排序字段</param>
        /// <param name="pageSize">每页显示记录数</param>
        /// <param name="pageIndex">当前页数从1开始</param>
        /// <param name="tran">事务</param>
        /// <returns>返回当前数据</returns>
        IList<Dictionary<string, object>> PagingSearch(string sql, string orderby, int pageSize, int pageIndex, IDbTransaction tran = null);
        /// <summary>
        /// 大批量插入数据（仅限SQLSERVER）
        /// </summary>
        /// <param name="dt">数据</param>
        /// <param name="tableName">表名</param>
        void SqlBulkCopyByDatatable(DataTable dt, string tableName);
        /// <summary>
        /// 转义字符
        /// </summary>
        /// <returns>转换后的字符</returns>
        string EscapeFromString(string value);
        /// <summary>
        /// 删除表
        /// </summary>
        /// <param name="tableName">表名</param>
        void DropTable(string tableName);
        
    }
}
