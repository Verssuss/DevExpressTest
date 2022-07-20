using System;
using System.Reflection;

namespace WpfApp3.Extensions
{
    public static class EnumExtensions
    {
        public static string GetEnumTextValue(this Enum e)
        {
            string text = string.Empty;
            Type t = e.GetType();
            MemberInfo[] members = t.GetMember(e.ToString());
            if (members.Length == 1)
            {
                object[] attrs = members[0].GetCustomAttributes(typeof(EnumTextValueAttribute), false);
                if (attrs.Length == 1)
                {
                    text = ((EnumTextValueAttribute)attrs[0]).Text;
                }
            }
            return text;
        }
    }
}