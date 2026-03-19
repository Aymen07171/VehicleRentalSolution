using System;
using System.Windows.Forms;
using UserServiceRef;
using VehicleRental.Contracts.DTOs;

namespace VehicleRental.WinClient
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            // Basic validation before calling the service
            if (string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Please enter email and password.";
                return;
            }

            using (UserServiceClient client = new UserServiceClient())
            {
                // Call the generated async method and map to local DTO
                UserServiceRef.UserDTO remoteUser = await client.LoginAsync(
                    txtEmail.Text.Trim(),
                    txtPassword.Text);

                if (remoteUser != null)
                {
                    // Map service DTO to contract DTO and save to session
                    Session.CurrentUser = new UserDTO
                    {
                        UserId = remoteUser.UserId,
                        Email = remoteUser.Email,
                        FullName = remoteUser.FullName,
                        Phone = remoteUser.Phone
                    };

                    // Open the main form and close this one
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
            // Open the register form
            RegisterForm registerForm = new RegisterForm();
            registerForm.ShowDialog();
        }
    }
}