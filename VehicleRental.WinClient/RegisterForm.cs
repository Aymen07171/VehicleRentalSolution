using System;
using System.Windows.Forms;
using VehicleRental.WinClient.UserServiceRef;

namespace VehicleRental.WinClient
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Please fill in all required fields.";
                return;
            }

            using (UserServiceClient client = new UserServiceClient())
            {
                bool success = client.Register(
                    txtFullName.Text.Trim(),
                    txtEmail.Text.Trim(),
                    txtPassword.Text,
                    txtPhone.Text.Trim());

                if (success)
                {
                    MessageBox.Show(
                        "Registration successful! You can now log in.",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Registration failed. Email may already exist.";
                }
            }
        }
    }
}