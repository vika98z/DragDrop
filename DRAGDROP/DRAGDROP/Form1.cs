using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DRAGDROP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label6_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void label6_DragDrop(object sender, DragEventArgs e)
        {
            TextBox src = e.Data.GetData(typeof(TextBox)) as TextBox;
            (sender as Label).Text = src.Text;
            (sender as Label).Font = src.Font;
        }

        private void textBox6_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                DoDragDrop(sender, DragDropEffects.Move);
        }

        private void exit1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bold1_Click(object sender, EventArgs e)
        {
            TextBox[] t = new TextBox[] { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6 };
            ToolStripMenuItem mi = sender as ToolStripMenuItem;
            for (int i = 0; i <=5; ++i)
            {
                if (t[i].Focused)
                {
                    mi.Checked = !mi.Checked;
                    FontStyle fs = t[i].Font.Style;
                    fs = mi.Checked ? (fs | mi.Font.Style) : (fs & ~mi.Font.Style);
                    Font f = t[i].Font;
                    t[i].Font = new Font(f, fs);
                    f.Dispose();
                }
            }
        }
    }
}
