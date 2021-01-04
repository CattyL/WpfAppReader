using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neko.Database
{
    /// <summary>
    /// 表特性
    /// </summary>
    public class DataTableAttribute : Attribute
    {
        private string _AliasName;
        /// <summary>
        /// 
        /// </summary>
        public string Schema { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string TableName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FullName { get { return string.Format("{0}.{1}", Schema, TableName); } }
        /// <summary>
        /// 
        /// </summary>
        public string AliasName
        {
            get { return string.IsNullOrEmpty(_AliasName) ? TableName : _AliasName; }
            set { _AliasName = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DataTableAttribute()
           : this(string.Empty)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        public DataTableAttribute(string name)
            : this("dbo", name)
        {
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="schema">数据库</param>
        /// <param name="name"></param>
        public DataTableAttribute(string schema, string name)
        {
            Schema = schema;
            TableName = name;
        }
    }
}
