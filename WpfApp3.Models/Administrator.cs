using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3.Models
{
    public class Administrator : Employee
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
