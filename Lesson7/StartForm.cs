using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lesson7
{
    static class StartForm
    {
        public static int Width { get; set; }
        public static int Height { get; set; }

        public static void CreatForms(ref Form Name)
        {
            Name.StartPosition = FormStartPosition.CenterScreen;
            Width = Name.Width = 400;
            Height = Name.Height = 100;
            Name.Text = "Text";
            Name.AutoSize = false;
            Name.MinimizeBox = false;
            Name.MinimumSize = new System.Drawing.Size(Name.Width, Name.Height = 100);
            Name.MaximumSize = new System.Drawing.Size(Name.Width, Name.Height = 100);
            Label lbl = new Label();
            lbl.Text = "Имя игрока: ";
            var textNumb1 = new System.Windows.Forms.TextBox();
            lbl.Location = new System.Drawing.Point(5,20);
            textNumb1.Location = new System.Drawing.Point(150,20);
            textNumb1.Text=  "Name";
            textNumb1.Name = "TextUserName";
            textNumb1.UseWaitCursor = false;
            Name.Controls.Add(lbl);
            Name.Controls.Add(textNumb1);
        }
    }
}
