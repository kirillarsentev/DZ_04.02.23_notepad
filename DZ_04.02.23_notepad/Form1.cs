using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Printing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DZ_04._02._23_notepad
{
    public partial class Form1 : Form
    {
        string openfile;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        Point LastPoint;
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left = e.X - LastPoint.X;
                this.Top = e.Y - LastPoint.Y;
            }

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            LastPoint = new Point(e.X, e.Y);
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "all(*.*) | *.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = File.ReadAllText(dialog.FileName);
                openfile = dialog.FileName;

            }
        }

        private void шрифтToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog font = new FontDialog();
            if (font.ShowDialog() == DialogResult.OK)
            {
                textBox1.Font = font.Font;
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                File.WriteAllText(openfile, textBox1.Text);


            }
            catch (ArgumentException)
            {
                MessageBox.Show("Ошибка!");
            }
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog Sdialog = new SaveFileDialog();
            Sdialog.Filter = "all(*.*) | *.*";
            if (Sdialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(Sdialog.FileName, textBox1.Text);
                openfile = Sdialog.FileName;

            }

        }

        private void Create_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void изменитьЦветToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.textBox1.ForeColor = System.Drawing.Color.Red;

        }

    }
}
