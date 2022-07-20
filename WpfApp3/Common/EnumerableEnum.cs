using System;
using System.Collections;
using System.Collections.Generic;

namespace WpfApp3.Common
{
    public class EnumerableEnum<T> : IEnumerable<Enum>
    {
        public IEnumerator<Enum> GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Enum.GetValues(typeof(T)).GetEnumerator();
        }
    }
}