using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tiny_Compiler
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Input getInputCode;
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            try
            {
                DialogResult res = op.ShowDialog();
                string name = op.FileName;
                if (res == System.Windows.Forms.DialogResult.OK)
                {
                    textBox1.Text = System.IO.File.ReadAllText(name);
                    getInputCode = new Input(name);
                }
            }
            catch
            {
                MessageBox.Show("error");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
