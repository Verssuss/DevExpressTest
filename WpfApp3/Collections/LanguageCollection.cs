using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using WpfApp3.Common;
using WpfApp3.Enums;

namespace WpfApp3.Collections
{
    class LanguageCollection : ObservableCollection<Language>
    {

    }

    class Language
    {
        public Enums.Language Lang { get; set; }
        public ImageSource SourceImage { get; set; }
    }
}
