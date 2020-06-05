using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheDisplayHandler
{
    public class DisplayHandler
    {
        Form form = new Form();
        Timer tmrFormAnimation = new Timer();

        bool loadUnload, AnimationFlag;
        bool localAnimationFlag = false;


        public static void ChangeVisibility(bool visibleOnOff, params Control[] controls)
        {
            foreach (Control ctrl in controls)
            {
                ctrl.Visible = visibleOnOff;
            }
        }
       
        public static void ToggleDisplay  (params Control[] controls)
        {
            //string a = controls[0].GetType().Name;

            foreach (Control ctrl in controls)
            {
                ctrl.Visible = !ctrl.Visible;
            }
        }

        public static void TotalVisibility(bool visibleOnOff, Form from)
        {
            Form frm = (Form)from;
            
            foreach (Control ctrl in frm.Controls)
            {
                ctrl.Visible = visibleOnOff;
            }
        }


        public void FormAnimation(Form form, bool loadUnload, int speed)
        {
            AnimationFlag = true;
            localAnimationFlag = false;
            this.form = form;
            tmrFormAnimation.Enabled = true;
            tmrFormAnimation.Interval = speed;
            tmrFormAnimation.Tick += tmrFormAnimation_Tick;
        }
        public void FormLocalAnimation(Form form, bool loadUnload, int speed)
        {
            localAnimationFlag = true;
            AnimationFlag = false;
            this.form = form;
            tmrFormAnimation.Enabled = true;
            tmrFormAnimation.Interval = speed;
            tmrFormAnimation.Tick += tmrFormAnimation_Tick;
        }
        private void tmrFormAnimation_Tick(object sender, EventArgs e)
        {
            if (AnimationFlag == true)
            {
                if (loadUnload == false)
                {
                    this.form.Opacity = form.Opacity + .010;
                    form.Top = form.Top - 1;
                    if (form.Opacity == 1)
                    {
                        loadUnload = true;
                        AnimationFlag = false;
                        tmrFormAnimation.Enabled = false;
                    }
                }
                if (loadUnload == true)
                {
                    form.Opacity = form.Opacity - .03;
                    form.Top = form.Top + 1;
                    if (form.Opacity == 0)
                    {
                        AnimationFlag = false;
                        Environment.Exit(0);
                        tmrFormAnimation.Enabled = false;
                    }

                }
            }


            if (localAnimationFlag == true)
            {
                if (loadUnload == false)
                {
                    this.form.Opacity = form.Opacity + .010;
                    if (form.Opacity == 1)
                    {
                        loadUnload = true;
                        localAnimationFlag = false;
                        tmrFormAnimation.Enabled = false;
                    }
                }
                if (loadUnload == true)
                {
                    form.Opacity = form.Opacity - .03;
                    if (form.Opacity == 0)
                    {
                        localAnimationFlag = false;
                        form.Close();
                        tmrFormAnimation.Enabled = false;
                    }

                }
            }
        }

        static List<string> GetList()
        {
            List<string> tmp = new List<string>();

            for (int i = 0; i < 10; i++)
            {
                tmp.Add("String " + i.ToString());
            }

            string ssss = tmp.ElementAt(6);

            return tmp;
        }


        public static IEnumerable<Control> controls { get; set; }
    }
}
