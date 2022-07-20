using System;

namespace WpfApp3.Extensions
{
    public class EnumTextValueAttribute : Attribute
    {
        public string Text { get; set; }

        public EnumTextValueAttribute(string text)
        {
            Text = text;
        }
    }
}