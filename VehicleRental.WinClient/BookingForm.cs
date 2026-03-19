using System;
using System.Windows.Forms;
using VehicleServiceRef;
using ReservationServiceRef;

namespace VehicleRental.WinClient
{
    public partial class BookingForm : Form
    {
        private readonly int _vehicleId;
        private VehicleDTO _vehicle;

        // Constructor receives the vehicle ID from MainForm
        public BookingForm(int vehicleId)
        {
            InitializeComponent();
            _vehicleId = vehicleId;
        }

        private async void BookingForm_Load(object sender, EventArgs e)
        {
            // Set minimum date to today
            dtpStart.MinDate = DateTime.Today;
            dtpEnd.MinDate = DateTime.Today.AddDays(1);

            // Load vehicle details
            using (VehicleServiceClient client = new VehicleServiceClient())
            {
                _vehicle = await client.GetVehicleByIdAsync(_vehicleId);
                lblVehicle.Text =
                    $"{_vehicle.Brand} {_vehicle.Model} — ${_vehicle.PricePerDay}/day";
            }

            UpdatePrice();
        }

        private void UpdatePrice()
        {
            if (_vehicle == null) return;

            int days = (dtpEnd.Value - dtpStart.Value).Days;

            if (days <= 0)
            {
                lblPrice.Text = "End date must be after start date.";
                lblPrice.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                decimal total = days * _vehicle.PricePerDay;
                lblPrice.Text = $"Total: {days} day(s) × ${_vehicle.PricePerDay} = ${total}";
                lblPrice.ForeColor = System.Drawing.Color.Green;
            }
        }

        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {
            UpdatePrice();
        }

        private void dtpEnd_ValueChanged(object sender, EventArgs e)
        {
            UpdatePrice();
        }

        private async void btnConfirm_Click(object sender, EventArgs e)
        {
            int days = (dtpEnd.Value - dtpStart.Value).Days;

            if (days <= 0)
            {
                MessageBox.Show("End date must be after start date.");
                return;
            }

            using (ReservationServiceClient client = new ReservationServiceClient())
            {
                bool success = await client.BookVehicleAsync(
                    Session.CurrentUser.UserId,
                    _vehicleId,
                    dtpStart.Value,
                    dtpEnd.Value);

                if (success)
                {
                    MessageBox.Show(
                        "Booking confirmed!",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    this.Close();
                }
                else
                {
                    MessageBox.Show(
                        "Booking failed. Vehicle may no longer be available.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }
    }
}