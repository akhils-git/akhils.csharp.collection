using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ImageFS
{
    public class Convertions
    {
        //  [Serializable]
        public static byte[] ObjectToByteArray(Object obj)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }
        public static Object ByteArrayToObject(byte[] byteArray)
        {
            using (var memStream = new MemoryStream())
            {
                var binForm = new BinaryFormatter();
                memStream.Write(byteArray, 0, byteArray.Length);
                memStream.Seek(0, SeekOrigin.Begin);
                var obj = binForm.Deserialize(memStream);
                return obj;
            }
        }
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
