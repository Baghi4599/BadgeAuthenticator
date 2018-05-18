using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prova__
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            String usr = Convert.ToString(textN.Text);
            String pwd = Convert.ToString(textP.Text);
            if (usr != "Admin" || pwd != "")
            {
                MessageBox.Show(" Username o Password non corretti");
                textN.Text = "";
                textP.Text = "";
            }
            else
            {
                Form2 frm = new Form2();
                textN.Text = "";
                textP.Text = "";
                this.Visible = false;
                frm.ShowDialog();
                this.Visible = true;
            }
        }
    }
}
