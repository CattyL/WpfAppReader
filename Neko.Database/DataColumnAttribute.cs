using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neko.Database
{
    /// <summary>
    /// 列特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class DataColumnAttribute : Attribute
    {
        private string _AliasName;

        /// <summary>
        /// 字段名
        /// </summary>
        public string ColumnName { get; set; }
        /// <summary>
        /// 说明
        /// </summary>
        public string AliasName
        {
            get { return string.IsNullOrEmpty(_AliasName) ? ColumnName : _AliasName; }
            set { _AliasName = value; }
        }
        /// <summary>
        /// 自增长
        /// </summary>
        public bool IsAuto { get; set; }

        /// <summary>
        /// 数据库字段类型
        /// </summary>
        public string ColumnType { get; set; }
        /// <summary>
        /// 长度
        /// </summary>
        public int Length { get; set; }
        /// <summary>
        /// 小数位数
        /// </summary>
        public int Decimal { get; set; }
        /// <summary>
        /// 是否为NULL
        /// </summary>
        public bool NotNull { get; set; }
        /// <summary>
        /// 是否主键
        /// </summary>
        public bool IsPrimaryKey { get; set; }

        /// <summary>
        /// 重写ToString()
        /// </summary>
        /// <returns>ColumnName</returns>
        public override string ToString()
        {
            return ColumnName;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public DataColumnAttribute() : this(string.Empty) { }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="name">ColumnName</param>
        public DataColumnAttribute(string name)
        {
            ColumnName = name;
        }
    }
}
