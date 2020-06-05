using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageFS
{
    public class FileManage
    {
        public static bool WriteByteFile(string fileName, byte[] bytes, string fileFormat)
        {
            BinaryWriter writer = null;
            try
            {
                writer = new BinaryWriter(File.OpenWrite(fileName + "." + fileFormat));
                writer.Write(bytes);
                writer.Flush();
                writer.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;

        }

        public static void ByteArrayWriteToFile(byte[] byteArray, string destnationPath)
        {
            BinaryWriter writer = null;
            //try
            //{
                writer = new BinaryWriter(File.OpenWrite(destnationPath));
                writer.Write(byteArray);
                writer.Flush();
                writer.Close();
            //}
            //catch (Exception)
            //{ }
        }

        public static byte[] ReadByteFile(string filePath)
        {
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            byte[] b = new byte[fs.Length];
            fs.Read(b, 0, System.Convert.ToInt32(fs.Length));
            fs.Close();
            return b;

        }
        public static string SeekFile(string filePath, int offSet, int length = 0, bool complite = false)
        {
            using (FileStream inFile = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                inFile.Seek(offSet, SeekOrigin.Begin);
                byte[] b = new byte[inFile.Length];
                if (complite == false)
                    inFile.Read(b, 0, length);
                else if (complite == true)
                    inFile.Read(b, 0, b.Length);
                return System.Text.Encoding.UTF8.GetString(b);

            }
        }

        public static byte[] FSeekFile(string filePath, int offSet, int length = 0, bool complite = false)
        {
            using (FileStream inFile = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                inFile.Seek(offSet, SeekOrigin.Begin);
                byte[] b = new byte[length - offSet];
                if (complite == false)
                    inFile.Read(b, 0, length);
                else if (complite == true)
                    inFile.Read(b, 0, b.Length);
                return b;

            }
        }

        public static bool WriteFile(string filePath, string text, string fileFormat)
        {
            try
            {
                using (StreamWriter stream = File.CreateText(filePath + "." + fileFormat))
                {

                    stream.WriteLine(text);
                    stream.Close();
                }
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }
        public static string ReadFile(string filePath, string fileFormat)
        {
            FileStream fs = new FileStream(filePath + "." + fileFormat, FileMode.Open, FileAccess.Read);
            byte[] temp = new byte[fs.Length];
            fs.Read(temp, 0, System.Convert.ToInt32(fs.Length));
            return System.Text.Encoding.UTF8.GetString(temp);
        }
        public static void FileUppEnd(string filePath, string text, string fileFormat)
        {

        }
        public static bool FindTextReplace(string filePath, string oldText, string newText)
        {
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                for (int i = 0; i < lines.Length; i++)
                {
                    lines[i] = lines[i].Replace(oldText, newText);
                }
                File.WriteAllLines(filePath, lines);
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        ///
        public static int FindPosition(string filePath,string findText)
        {
            return 0;
        }
        public static string ByteArrayToString(byte[] byteArray)
        {
            byte[] temp = byteArray;
            //return System.Text.Encoding.UTF8.GetString(temp);
            return Convert.ToBase64String(temp);

        }
    }
}
