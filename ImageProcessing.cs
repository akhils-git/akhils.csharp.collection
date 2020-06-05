using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ImageFS
{
    public class ImageProcessing
    {
        public static string ImageToBase64(Image image, ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, format);
                byte[] imageBytes = ms.ToArray();
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
        }
        public static byte[] ImageToByteArray(Image image, ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, format);
                byte[] imageBytes = ms.ToArray();
                return imageBytes;
            }
        }
        public static Image ByteArrayToImage(byte[] byteArray)
        {
            byte[] imageBytes = byteArray;
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = Image.FromStream(ms, true);
            return image;

        }
        public static Image Base64ToImage(string base64String)
        {
            byte[] imageBytes = Convert.FromBase64String(base64String);
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = Image.FromStream(ms, true);
            return image;

        }
        public static byte[] ImageToBytes(Image image, ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, format);
                byte[] imageBytes = ms.ToArray();
                // string base64String = Convert.ToBase64String(imageBytes);
                return imageBytes;
            }
        }
        public static Image BytesToImage(byte[] byteArray)
        {
            byte[] imageBytes = byteArray;
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = Image.FromStream(ms, true);
            return image;

        }
        public static void WriteFile(string fileName, string text, string fileFormat)
        {
            using (StreamWriter stream = File.CreateText(fileName + "." + fileFormat))
            {
                stream.WriteLine(text);
            }
        }
        public static bool WriteFile(string fileName, byte[] bytes, string fileFormat)
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

        public static byte[] ReadFile(string filePath)
        {
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            byte[] b = new byte[fs.Length];
            fs.Read(b, 0, System.Convert.ToInt32(fs.Length));
            fs.Close();
            return b;

        }
        public static void SaveImage(Image image, string path)
        {
            image.Save(path);
        }

    }
}
