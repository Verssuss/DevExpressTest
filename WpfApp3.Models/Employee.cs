using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3.Models
{
    [PropertyChanged.AddINotifyPropertyChangedInterface()]
    public class Employee : ICloneable
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FullName { get; set; }
        public string Position { get; set; }
        public string PhotoSource { get; set; }
        public decimal Salary { get; set; }
        public byte Experience { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone() as Employee;
        }
    }
}
