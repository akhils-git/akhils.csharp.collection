using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassForEncryptDecrypt;
using System.Security.AccessControl;
using System.Threading;
using MyClassLibraryBuild.MyClass;

namespace MyClassLibraryBuild
{
    public enum EncryptionOptionsWithSubKey
    {
        FullEncryption,
        SubKeyAndValue,
        OnlyValue,
        NoEncryption
    }
    public enum EncryptionOptions
    {
        FullEncryption,
        KeyNameAndValue,
        OnlyValue,
        NoEncryption
    }
    public class SystemRegistryHandler 
    {
        public static void SaveRegistryWithSubKey(string title, string subTitle, string keyName, string keyValue, EncryptionOptionsWithSubKey encryptionOptions, string encryptionKey = "123") //Save a value to Reg
        {

            if (EncryptionOptionsWithSubKey.NoEncryption == encryptionOptions)
            {
            RegistryKey Test = Registry.CurrentUser.CreateSubKey(title + "\\" + subTitle);
                Test.SetValue(keyName, keyValue);
            }
            else if (EncryptionOptionsWithSubKey.FullEncryption == encryptionOptions)
            {
                RegistryKey Test = Registry.CurrentUser.CreateSubKey(EncryptDecrypt.Encrypt(title, encryptionKey) + "\\" + EncryptDecrypt.Encrypt(subTitle, encryptionKey));
               Test.SetValue(EncryptDecrypt.Encrypt(keyName,encryptionKey),EncryptDecrypt.Encrypt(keyValue,encryptionKey)) ;
            }
            else if (EncryptionOptionsWithSubKey.SubKeyAndValue == encryptionOptions)
            {
                RegistryKey Test = Registry.CurrentUser.CreateSubKey(title + "\\" + EncryptDecrypt.Encrypt(subTitle, encryptionKey));
                Test.SetValue(EncryptDecrypt.Encrypt(keyName, encryptionKey), EncryptDecrypt.Encrypt(keyValue, encryptionKey));
            }
            else if (EncryptionOptionsWithSubKey.OnlyValue== encryptionOptions)
            {
                RegistryKey Test = Registry.CurrentUser.CreateSubKey(title + "\\" + subTitle);
                Test.SetValue(keyName,EncryptDecrypt.Encrypt( keyValue,encryptionKey));
            }
            
        }
        public static string ReadRegistryWithSubKey(string title, string subTitle, string keyName, EncryptionOptionsWithSubKey encryptionOptions, string DecryptionKey = "123")//Read a value to Reg
        {
            string temp;

            if (EncryptionOptionsWithSubKey.NoEncryption == encryptionOptions)
            {
                RegistryKey Test = Registry.CurrentUser.OpenSubKey(title + "\\" + subTitle);
                try
                {
                    if (Test != null)
                    {
                        Test.OpenSubKey(keyName);
                        temp = Test.GetValue(keyName).ToString();

                    }
                    else
                    {
                        temp = null;
                    }
                    return temp;
                }
                catch (NullReferenceException)
                {
                    return null;
                }
            }
         else   if (EncryptionOptionsWithSubKey.OnlyValue == encryptionOptions)
            {
                RegistryKey Test = Registry.CurrentUser.OpenSubKey(title + "\\" + subTitle);
                try
                {
                    if (Test != null)
                    {
                        Test.OpenSubKey(keyName);
                        temp = Test.GetValue(keyName).ToString();

                    }
                    else
                    {
                        temp = null;
                    }
                    return EncryptDecrypt.Decrypt( temp,DecryptionKey);
                }
                catch (NullReferenceException)
                {
                    return null;
                }
            }
            else if (EncryptionOptionsWithSubKey.FullEncryption == encryptionOptions)
            {
                RegistryKey Test = Registry.CurrentUser.OpenSubKey(EncryptDecrypt.Encrypt(title, DecryptionKey) + "\\" + EncryptDecrypt.Encrypt(subTitle,DecryptionKey));
                try
                {
                    if (Test != null)
                    {
                        Test.OpenSubKey(EncryptDecrypt.Encrypt(keyName, DecryptionKey));
                        temp = Test.GetValue(EncryptDecrypt.Encrypt(keyName, DecryptionKey)).ToString();

                    }
                    else
                    {
                        temp = null;
                    }
                    return EncryptDecrypt.Decrypt( temp,DecryptionKey);
                }
                catch (NullReferenceException)
                {
                    return null;
                }
            }
            else if (EncryptionOptionsWithSubKey.SubKeyAndValue == encryptionOptions)
            {
                RegistryKey Test = Registry.CurrentUser.OpenSubKey(title+ "\\" + EncryptDecrypt.Encrypt(subTitle, DecryptionKey));
                try
                {
                    if (Test != null)
                    {
                        Test.OpenSubKey(EncryptDecrypt.Encrypt(keyName, DecryptionKey));
                        temp = Test.GetValue(EncryptDecrypt.Encrypt(keyName, DecryptionKey)).ToString();

                    }
                    else
                    {
                        temp = null;
                    }
                    return EncryptDecrypt.Decrypt(temp, DecryptionKey);
                }
                catch (NullReferenceException)
                {
                    return null;
                }
            }
            return null;
        }
        public static int SubKeyCount(string root)
        {
            try
            {
                RegistryKey Test = Registry.CurrentUser.OpenSubKey(root);
                return Test.SubKeyCount;
            }
            catch (NullReferenceException)
            {
                return 0;
            }
        }

        public static string[] GetSubKeyNames(string root)
        {
            try
            {
                RegistryKey Test = Registry.CurrentUser.OpenSubKey(root);
                return Test.GetSubKeyNames();
            }
            catch (NullReferenceException)
            {
                return null;
            }
        }
        public static int RootKeyCount(string root)
        {
            try
            {
                RegistryKey Test = Registry.CurrentUser.OpenSubKey(root);
                return Test.ValueCount;
            }
            catch (NullReferenceException)
            {
                return 0;
            }

        }
        public static string[] GetValuesNames(string root)
        {
            try
            {
                RegistryKey Test = Registry.CurrentUser.OpenSubKey(root);
                return Test.GetValueNames();
            }
            catch (NullReferenceException)
            {
                return null;
            }
        }

        public static bool DeleteAllSubKeys(string root, string subKey)
        {
            try
            {
                RegistryKey Test = Registry.CurrentUser.OpenSubKey(root);

                RegistrySecurity s = new RegistrySecurity();
                //s = Test.GetAccessControl();
                //Registry.CurrentUser.DeleteSubKeyTree(root);
                Registry.CurrentUser.ValueCount.ToString();
                //Test.SetAccessControl(s);
                //Test.DeleteValue(subKey, true);
               // Test.DeleteSubKey(subKey);
                return true;
            }
            catch (NullReferenceException)
            {
                return false;
            }
        }

        public static void SaveRegistry(string title, string keyName, string keyValue, EncryptionOptions encryptionOptions, string encryptionKey = "123") //Save Local value to Reg
        {

            if (EncryptionOptions.FullEncryption == encryptionOptions)
            {
                RegistryKey Test = Registry.CurrentUser.CreateSubKey(EncryptDecrypt.Encrypt(title, encryptionKey));
                Test.SetValue(EncryptDecrypt.Encrypt(keyName, encryptionKey), EncryptDecrypt.Encrypt(keyValue, encryptionKey));
            }
            else if (EncryptionOptions.KeyNameAndValue == encryptionOptions)
            {
                RegistryKey Test = Registry.CurrentUser.CreateSubKey(title);
                Test.SetValue(EncryptDecrypt.Encrypt(keyName,encryptionKey), EncryptDecrypt.Encrypt(keyValue, encryptionKey));
            }
            else if (EncryptionOptions.OnlyValue == encryptionOptions)
            {
                RegistryKey Test = Registry.CurrentUser.CreateSubKey(title);
                Test.SetValue(keyName,EncryptDecrypt.Encrypt( keyValue,encryptionKey));
            }
            else if (EncryptionOptions.NoEncryption == encryptionOptions)
            {
                RegistryKey Test = Registry.CurrentUser.CreateSubKey(title);
                Test.SetValue(keyName, keyValue);
            }
           
        }

        public static string ReadRegistry(string Title, string keyName, EncryptionOptions encryptionOptions, string encryptionKey = "123")//ReadLocal  value to Reg
        {
            string t="";
            if (EncryptionOptions.NoEncryption==encryptionOptions)
            {
                RegistryKey Test = Registry.CurrentUser.OpenSubKey(Title);
                try
                {
                    if (Test != null)
                    {
                        Test.OpenSubKey(keyName);
                        t = Test.GetValue(keyName).ToString();

                    }
                    else
                    {
                        t = null;
                    }
                    return t;
                }
                catch (NullReferenceException)
                {
                    return null;
                } 
            }
            else if (EncryptionOptions.OnlyValue==encryptionOptions)
            {
                RegistryKey Test = Registry.CurrentUser.OpenSubKey(Title);
                try
                {
                    if (Test != null)
                    {
                        Test.OpenSubKey(keyName);
                        t = Test.GetValue(keyName).ToString();

                    }
                    else
                    {
                        t = null;
                    }
                    return EncryptDecrypt.Decrypt( t,encryptionKey);
                }
                catch (NullReferenceException)
                {
                    return null;
                } 
            }
            else if (EncryptionOptions.KeyNameAndValue == encryptionOptions)
            {
                RegistryKey Test = Registry.CurrentUser.OpenSubKey(Title);
                try
                {
                    if (Test != null)
                    {
                        Test.OpenSubKey(EncryptDecrypt.Encrypt( keyName,encryptionKey));
                        t = Test.GetValue(EncryptDecrypt.Encrypt( keyName,encryptionKey)).ToString();

                    }
                    else
                    {
                        t = null;
                    }
                    return EncryptDecrypt.Decrypt(t, encryptionKey);
                }
                catch (NullReferenceException)
                {
                    return null;
                }
            }
            return t;
        }
        
    }
}
