using System;
using System.Windows.Forms;
using VehicleRental.Contracts.DTOs;
using VehicleRental.WinClient.VehicleServiceRef;
using VehicleRental.WinClient.ReservationServiceRef;

namespace VehicleRental.WinClient
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = $"Welcome, {Session.CurrentUser.FullName}!";
            LoadVehicles();
        }

        private void LoadVehicles()
        {
            using (VehicleServiceClient client = new VehicleServiceClient())
            {
                VehicleDTO[] vehicles = client.GetAvailableVehicles();
                dgvVehicles.DataSource = vehicles;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadVehicles();
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            if (dgvVehicles.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a vehicle first.");
                return;
            }

            int vehicleId = (int)dgvVehicles.SelectedRows[0].Cells["VehicleId"].Value;

            BookingForm bookingForm = new BookingForm(vehicleId);
            bookingForm.ShowDialog();

            // Refresh after booking
            LoadVehicles();
        }

        private void btnLoadReservations_Click(object sender, EventArgs e)
        {
            using (ReservationServiceClient client = new ReservationServiceClient())
            {
                ReservationDTO[] reservations =
                    client.GetUserReservations(Session.CurrentUser.UserId);

                dgvReservations.DataSource = reservations;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (dgvReservations.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a reservation first.");
                return;
            }

            int reservationId =
                (int)dgvReservations.SelectedRows[0].Cells["ReservationId"].Value;

            DialogResult confirm = MessageBox.Show(
                "Are you sure you want to cancel this reservation?",
                "Confirm",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                using (ReservationServiceClient client = new ReservationServiceClient())
                {
                    bool success = client.CancelReservation(reservationId);

                    if (success)
                    {
                        MessageBox.Show("Reservation cancelled successfully.");
                        btnLoadReservations_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Cancellation failed.");
                    }
                }
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Session.CurrentUser = null;
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }

        private void lblWelcome_Click(object sender, EventArgs e)
        {

        }
    }
}