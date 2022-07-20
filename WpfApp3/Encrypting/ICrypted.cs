using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3.Encrypting
{
    public interface ICrypted
    {
        bool VerifyHashedPassword(string hashedPassword, string password);
        string HashPassword(string password);
    }
}
