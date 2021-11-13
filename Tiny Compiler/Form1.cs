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

        public static List<string> scannerResults;
        Input input_instance;
        private DataGridView dataGridView;
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public void printOnGrid(bool errorGrid, string s1, string s2)
        {
            checkCurrentGrid(errorGrid);

            DataGridViewRow row = (DataGridViewRow)dataGridView.Rows[0].Clone();
            row.Cells[0].Value = s1;
            row.Cells[1].Value = s2;
            if (s2 == "Number")
                scannerResults.Add("Number" + s1);
            else if (s2 == "ID")
                scannerResults.Add("ID" + s1);
            else
                scannerResults.Add(s2);
            dataGridView.Rows.Add(row);
        }

        private void checkCurrentGrid(bool errorGrid)
        {
            if (errorGrid == true)
                dataGridView = dataGridView2;
            else
                dataGridView = dataGridView1;
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
                    input_instance = new Input(name);
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
            Initializer initializer_instace = new Initializer();
            Scanner scanner_instace = new Scanner();
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            scannerResults = new List<string>();
            dataGridView1.Refresh();
            dataGridView2.Refresh();
            scanner_instace.
                startScanning(
                    input_instance.getInput(), 
                    this, 
                    initializer_instace.getReservedWords(),
                    initializer_instace.getSpecialSymbols()
                );
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
