using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SKRIPSI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = 10;
            dataGridView1.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 20);
            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dataGridView1.Columns[0].Name = "Product ID";
            //dataGridView1.Columns[1].Name = "Product Name";
            //dataGridView1.Columns[2].Name = "Product Price";

            for (int k = 0; k < 10; k++)
            {
                dataGridView1.Rows.Add();
                //dataGridView1.Rows[i].Height = 505 / tts_board.GetLength(0);
            }

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if(j % 2 == 0)
                    {
                        dataGridView1.Rows[i].Cells[j].ReadOnly = true;
                        dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.Black;
                        dataGridView1.Rows[i].Cells[j].Style.SelectionBackColor = Color.Black;
                    }
                    else
                        dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.White;

                    dataGridView1.Rows[i].Cells[j].Value = "";
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Grid grid = new Grid(12, 12);
            Kamus dic = new Kamus();

            List<String> words = new List<String>();
            foreach (Object item in dic.getAll().Keys)
            {
                words.Add(item.ToString());
            }
            Generator gen = new Generator(grid, words);

            int usedCount = gen.generate();
            //grid.show();
            Console.WriteLine(grid.getValue(0,0));
            
        }
    }
}
