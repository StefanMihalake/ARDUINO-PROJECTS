using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ArduinoConsole
{
    public partial class LoginPage : Form
    {
        Form1 form = new Form1();

        List<string> username = new List<string>() {"stefan", "Gigi" };
        List<string> password = new List<string>() {"pass", "ciao" };

        public LoginPage()
        {
            InitializeComponent();
            label3.Text = "";
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string user = usernameTextbox.Text;
            string pass = passwordTextbox.Text;

            if (username.Contains(user) && password.Contains(pass))
            {
                Form1 form = new Form1();
                form.FormClosed += new FormClosedEventHandler(CloseLoginForm);
                this.Hide();
                form.ShowDialog();
            }
            else
            {
                label3.Text = "USER OR PASSWORD NOT VALID!";
            }
        }

        private void CloseLoginForm(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void usernameTextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            passwordTextbox.UseSystemPasswordChar = !passwordTextbox.UseSystemPasswordChar;
        }
    }
}
