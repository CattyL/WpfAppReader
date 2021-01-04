using Neko.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neko.DAL
{
    /// <summary>
    /// 学生表信息
    /// </summary>
    [DataTable(AliasName = "学生表信息", Schema = "test", TableName = "student")]
    public class Student : UINotifyPropertyChanged
    {
        /// <summary>
        /// ID
        /// </summary>
        [DataColumn(AliasName = "ID", ColumnName = "ID", ColumnType = "long", IsAuto = true, IsPrimaryKey = true, NotNull = true)]
        public long ID
        {
            get => ID;
            set
            {
                if (value != ID)
                {
                    ID = value;
                    NotifyPropertyChanged(nameof(ID));
                }
            }
        }

        /// <summary>
        /// 姓名
        /// </summary>
        [DataColumn(AliasName = "姓名", ColumnName = "Name", ColumnType = "string", Length = 20, NotNull = true)]
        public string Name
        {
            get => Name;
            set 
            {
                if (value != Name)
                {
                    Name = value;
                    NotifyPropertyChanged(nameof(Name));
                }
            }
        }

        /// <summary>
        /// 年级
        /// </summary>
        [DataColumn(AliasName = "年级", ColumnName = "Grade", ColumnType = "int", NotNull = true)]
        public int Grade
        {
            get => Grade;
            set
            {
                if (value != Grade)
                {
                    Grade = value;
                    NotifyPropertyChanged(nameof(Grade));
                }
            }
        }

        /// <summary>
        /// 入学时间
        /// </summary>
        public DateTime AdmissionDate
        {
            get => AdmissionDate;
            set
            {
                if (value != AdmissionDate)
                {
                    AdmissionDate = value;
                    NotifyPropertyChanged(nameof(AdmissionDate));
                }
            }
        }
    }
}
