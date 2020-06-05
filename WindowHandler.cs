using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyClassLibraryBuild.MyClass
{
    public class WindowHandler
    {
        public static void SaveWindowPosition(Form form,string root)
        {
            SystemRegistryHandler.SaveRegistry(root, "Top", form.Top.ToString(), EncryptionOptions.NoEncryption);
            SystemRegistryHandler.SaveRegistry(root, "Left", form.Left.ToString(), EncryptionOptions.NoEncryption);
        }
        public static void ReadWindowPosition(Form form, string root)
        {
            form.Top = Convert.ToInt32(SystemRegistryHandler.ReadRegistry(root, "Top", EncryptionOptions.NoEncryption));
            form.Left = Convert.ToInt32(SystemRegistryHandler.ReadRegistry(root, "Left", EncryptionOptions.NoEncryption));
        }
    }
}
