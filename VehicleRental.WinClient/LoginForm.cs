using System;
using System.Windows.Forms;
using VehicleRental.Contracts.DTOs;
using VehicleRental.WinClient.UserServiceRef;

namespace VehicleRental.WinClient
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Please enter email and password.";
                return;
            }

            using (UserServiceClient client = new UserServiceClient())
            {
                UserDTO user = client.Login(
                    txtEmail.Text.Trim(),
                    txtPassword.Text);

                if (user != null)
                {
                    Session.CurrentUser = user;
                    MainForm mainForm = new MainForm();
                    mainForm.Show();
                    this.Hide();
                }
                else
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Invalid email or password.";
                }
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.ShowDialog();
        }
    }
}