using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyClassLibraryBuild.MyClass
{
    public class StringHandler
    {
        public static string[] SplitString(string text, string splitText = " ")
        {
            return text.Trim().Split(new string[] { splitText }, StringSplitOptions.RemoveEmptyEntries);
        }
        public static string JoinString(string[] stringArray, string joinText = " ")
        {
            string temp = String.Empty;
            for (int i = 0; i < stringArray.Length; i++)
            {
                temp = temp + joinText + stringArray[i];
            }
            return temp.Remove(0, 1);
        }
        public static string AddValueOfTwoStrings(params string[] strings)
        {
            decimal temp = 0;
            foreach (string str in strings)
            {
                temp = temp + Convert.ToDecimal(str);
            }
            return temp.ToString();
        }
    }
}
