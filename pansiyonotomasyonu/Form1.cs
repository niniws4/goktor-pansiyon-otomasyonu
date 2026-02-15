using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sinav
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static int odano;
        private void button1_Click(object sender, EventArgs e)
        {
            odano = 1;
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            odano = 2;
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            odano = 3;
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            odano = 4;
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.ShowDialog();
        }
    }
}
