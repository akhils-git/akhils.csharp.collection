using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyClassLibraryBuild.MyClass
{
    public class GlobelControlHandler
    {
        public static string AddValueOfTwoControls(params Control[] control)//
        {
            decimal temp = 0;
            if (control.GetType().ToString() == "TextBox")
            {

                foreach (Control ctrl in control)
                {
                    temp = temp + Convert.ToDecimal(ctrl.Text);
                }
            }
            return null;
        }
    }
}
