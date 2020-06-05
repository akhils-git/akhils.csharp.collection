using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLibraryBuild.MyClass
{
    public static class StringUtilities
    {
        public static string[] SplitToWords(this string input)
        {
            return input.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
