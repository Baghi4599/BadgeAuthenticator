using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.IO.Ports;
using System.Windows.Input;
using System.Security.Cryptography;
using MySql.Data.MySqlClient;

namespace Prova__
{
    public partial class Form2 : Form
    {
        public const int max_car = 6;

        public Form2()
        {
            InitializeComponent();
            textPwd.Text = CreateRandomPassword(max_car);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(controllo(textNome.Text)==false || controllo(textCognome.Text) == false)
            {
                MessageBox.Show("Nome e Cognome non possono contenere numeri");
                textNome.Text = ("");
                textCognome.Text = ("");
            }
            if (controllo(textKey.Text) == true )
            {
                MessageBox.Show("La chiave del Badge deve contenere solo caratteri numerici");
                textNome.Text = ("");
            }
        }

        public bool controllo(string stringa)
        {
            int n;
            int lettere = 0;
            int val = stringa.Length - 1;
            char[] c;

            for (n = 0; n <= (val); n++)
            {
                c = (stringa.ToCharArray(n, 1));
                char a = c[0];
                if ((char.IsLetter(a)))
                {
                    lettere = lettere + 1;
                }
                else
                {
                    if ((char.IsNumber(a)))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void button3_Click(object sender, EventArgs e)
        { 
            OpenFileDialog open = new OpenFileDialog(); 
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(open.FileName);
            }
        }

        public void InvioMail()
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

            mail.From = new MailAddress("autenticacredenziali@gmail.com");
            mail.To.Add(textMail.Text);
            mail.Subject = "Test Mail";
            mail.Body = "Benvenuto all' interno dell' azienda BLM ecco le tue credenziali d' accesso per controllare le tue attività all' interno dell' azienda => username : "+ textUser.Text.ToString()+" password : " + textPwd.Text.ToString();

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("autenticacredenziali@gmail.com", "!123456789!");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);
            MessageBox.Show("mail Sent");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string pwd = Hash(textPwd.Text);
            InvioMail();
        }

        public string Hash(string password)
        {
            var bytes = new UTF8Encoding().GetBytes(password);
            byte[] hashBytes;
            using (var algorithm = new SHA512Managed())
            {
                hashBytes = algorithm.ComputeHash(bytes);
            }
            return Convert.ToBase64String(hashBytes);
        }

        public string CreateRandomPassword(int passwordLength)
        {
            string allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789";
            char[] chars = new char[passwordLength];
            Random rd = new Random();

            for (int i = 0; i < passwordLength; i++)
            {
                chars[i] = allowedChars[rd.Next(0, allowedChars.Length)];
            }

            return new string(chars);
        }

        private void textKey_MouseClick(object sender, MouseEventArgs e)
        {
            string key = Console.ReadLine();
            textUser.Text = key;
        }

        private void textKey_Enter(object sender, EventArgs e)
        {
            string key = Console.ReadLine();
            textUser.Text = key;
        }

        private void textUser_Enter(object sender, EventArgs e)
        {
            string key = Console.ReadLine();
            textKey.Text = key;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //ar g = new GetUSBDevices();

            SerialPort serialPort1 = new SerialPort();
            serialPort1.PortName = "COM4";
            serialPort1.BaudRate = 9600;
            serialPort1.DataBits = 8;
            serialPort1.Open();
            string ciao = serialPort1.ReadLine();
            Console.Out.WriteLine(ciao);
        }
    }
}

