using System;
using System.Reflection;

namespace Neko.Database
{
    /// <summary>
    /// 展示名称特性
    /// </summary>
    public class EnumDisplayTextAttribute : Attribute
    {
        /// <summary>
        /// 展示的名称
        /// </summary>
        public string DisplayText { get; private set; }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="displayText">展示的名称</param>
        public EnumDisplayTextAttribute(string displayText)
        {
            DisplayText = displayText;
        }
        /// <summary>
        /// 获得value的类型名称
        /// </summary>
        /// <param name="value"></param>
        /// <param name="nameInstead"></param>
        /// <returns></returns>
        public static string GetDispText(object value, bool nameInstead = true)
        {
            Type type = value.GetType();
            string name = Enum.GetName(type, value);
            if (name == null)
            {
                return "";
            }

            FieldInfo field = type.GetField(name);

            EnumDisplayTextAttribute attribute = GetCustomAttribute(field, typeof(EnumDisplayTextAttribute)) as EnumDisplayTextAttribute;
            if (attribute == null && nameInstead == true)
            {
                return name;
            }
            return attribute == null ? null : attribute.DisplayText;
        }
    }
}
