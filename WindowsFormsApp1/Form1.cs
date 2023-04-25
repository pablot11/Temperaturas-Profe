using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        Localidades l;
        Temperaturas t;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // OPCION 1
            // t.buscar(Convert.ToInt32(comboBox1.SelectedValue), dateTimePicker1.Value.ToString("dd/MM/yyyy"), textBox1, textBox2);

            // OPCION 2
            string[] encontro = t.buscar(Convert.ToInt32(comboBox1.SelectedValue), dateTimePicker1.Value.ToString("dd/MM/yyyy"));
            textBox1.Text = encontro[0];
            textBox2.Text = encontro[1];

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            l = new Localidades();
            l.llenar(comboBox1);
            t = new Temperaturas();
        }

        
    }
}
