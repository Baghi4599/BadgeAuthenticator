using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace Prova__
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label5.Text = DateTime.Now.Day.ToString()+"/"+ DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString() + "  " + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //richiamare la funzione orario per ricavare l' orario di sistema
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //richiamare la funzione orario per ricavare l' orario di sistema
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 frm = new Form4();
            this.Visible = false;
            frm.ShowDialog();
            this.Visible = true;
        }

        public  string orario()
        {
            string hh;
            hh = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString();
            return hh;
        }
    }
}
