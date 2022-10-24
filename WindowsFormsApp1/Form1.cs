using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            captcha = new Captcha(fontSize: 100);
            pictureBox1.Image = captcha.GetCaptchaImage();
            var s = Captcha.GetCaptchaString(new Random(), 5);
        }
        Captcha captcha;
        private void button1_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void Login()
        {
            if (captcha.CheckAnswer(textBox3.Text))
            {


                var t = DataBase.runQuery($"Select * from reg where login ='{textBox1.Text}' and password = '{textBox2.Text}'");
                if (t.Rows.Count == 1)
                {
                    Hide();
                    new Menu().ShowDialog();
                    Close();
                }
            }
        }
        


    }
}
