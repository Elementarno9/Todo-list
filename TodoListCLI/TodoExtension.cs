using System;
using System.Collections.Generic;
using System.Text;

namespace TodoListCLI
{
    static class TodoExtension
    {
        public static string PadCenter(this string s, int length)
        {
            int spaces = length - s.Length;
            if (spaces <= 0) return s;
            return s.PadLeft(length - spaces / 2).PadRight(length);
        }

        public static string PadCenter(this string s, int length, bool equally) => PadCenter(s, !equally || length % 2 == s.Length % 2 ? length : length + 1);
    }
}
