using System;
using System.Windows.Forms;
using VehicleRental.Contracts.DTOs;
using VehicleRental.WinClient.VehicleServiceRef;
using VehicleRental.WinClient.ReservationServiceRef;

namespace VehicleRental.WinClient
{
    public partial class BookingForm : Form
    {
        private readonly int _vehicleId;
        private VehicleDTO _vehicle;

        public BookingForm(int vehicleId)
        {
            InitializeComponent();
            _vehicleId = vehicleId;
        }

        private void BookingForm_Load(object sender, EventArgs e)
        {
            dtpStart.MinDate = DateTime.Today;
            dtpEnd.MinDate = DateTime.Today.AddDays(1);

            using (VehicleServiceClient client = new VehicleServiceClient())
            {
                _vehicle = client.GetVehicleById(_vehicleId);

                if (_vehicle != null)
                    lblVehicle.Text =
                        $"{_vehicle.Brand} {_vehicle.Model} ({_vehicle.Year})" +
                        $" — ${_vehicle.PricePerDay}/day";
            }

            UpdatePrice();
        }

        private void UpdatePrice()
        {
            if (_vehicle == null) return;

            int days = (dtpEnd.Value.Date - dtpStart.Value.Date).Days;

            if (days <= 0)
            {
                lblPrice.ForeColor = System.Drawing.Color.Red;
                lblPrice.Text = "End date must be after start date.";
            }
            else
            {
                decimal total = days * _vehicle.PricePerDay;
                lblPrice.ForeColor = System.Drawing.Color.Green;
                lblPrice.Text =
                    $"Total: {days} day(s) × ${_vehicle.PricePerDay} = ${total}";
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

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            int days = (dtpEnd.Value.Date - dtpStart.Value.Date).Days;

            if (days <= 0)
            {
                MessageBox.Show("End date must be after start date.");
                return;
            }

            using (ReservationServiceClient client = new ReservationServiceClient())
            {
                bool success = client.BookVehicle(
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