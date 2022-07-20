using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp3.Extensions;

namespace WpfApp3.Enums
{
    public enum Language
    {
        [EnumTextValue("ru-RU")]
        Russian,
        [EnumTextValue("en-US")]
        English,
        [EnumTextValue("de-DE")]
        Deutsch
    }
}
