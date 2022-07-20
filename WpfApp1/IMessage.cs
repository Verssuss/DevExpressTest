using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public interface IMessage
    {
        public TypeMessage TypeMessage { get; set; }
        public string Message { get; set; }
    }
}
