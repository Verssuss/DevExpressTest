using WpfApp3.Extensions;

namespace WpfApp3.Enums
{
    public enum Position
    {
        [EnumTextValue("Administrator")]
        Administrator,

        [EnumTextValue("Programmer")]
        Programmer,

        [EnumTextValue("Cleaner")]
        Cleaner,

        [EnumTextValue("Accountant")]
        Accountant
    }
}