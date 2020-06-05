using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageFS
{
    public class BaseBinary
    {
        public static string StringToBinary(string text)
        {

            string binary = string.Empty;

            foreach (char ch in text)
            {

                if (Convert.ToString((int)ch, 2).Length == 6)
                {
                    binary = binary + "0";
                    binary += Convert.ToString((int)ch, 2);
                }
                else
                {
                    binary += Convert.ToString((int)ch, 2);
                }
            }
            return binary;
        }
        public static string BinaryToString(string binaryString)
        {
            int start = 0;
            string tS = string.Empty;
            string text = string.Empty;
            foreach (char ch in binaryString)
            {

                int tI = 0;
                if (binaryString.Length - start >= 7)
                {
                    tS = binaryString.Substring(start, 7);
                    try
                    {
                        tI = Convert.ToInt32(tS, 2);
                    }
                    catch (Exception)
                    {

                    }
                    char a = (char)tI;
                    text = text + a.ToString();
                    start = start + 7;
                }


            }
            return text;
        }
    }
}
