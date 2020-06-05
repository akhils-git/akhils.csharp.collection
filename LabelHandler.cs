using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyClassLibraryBuild.MyClass
{
    public class LabelHandler
    {
        public static void ChangeBackColorForeColor(Label label,string backColorName=null, string foreColorName=null,string text=null)
        {
            if (backColorName != null) label.BackColor = Color.FromName(backColorName);
            if (foreColorName != null) label.ForeColor = Color.FromName(foreColorName);
            if (text != null) label.Text = text;
        }

    }
}
