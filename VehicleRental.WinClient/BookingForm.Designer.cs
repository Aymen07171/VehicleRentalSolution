namespace VehicleRental.WinClient
{
    partial class BookingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblVehicle = new Label();
            label1 = new Label();
            dtpStart = new DateTimePicker();
            label2 = new Label();
            dtpEnd = new DateTimePicker();
            lblPrice = new Label();
            btnConfirm = new Button();
            SuspendLayout();
            // 
            // lblVehicle
            // 
            lblVehicle.AutoSize = true;
            lblVehicle.Location = new Point(49, 54);
            lblVehicle.Name = "lblVehicle";
            lblVehicle.Size = new Size(129, 20);
            lblVehicle.TabIndex = 0;
            lblVehicle.Text = "shows vehicle info";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(49, 95);
            label1.Name = "label1";
            label1.Size = new Size(79, 20);
            label1.TabIndex = 0;
            label1.Text = "Start Date:";
            // 
            // dtpStart
            // 
            dtpStart.Location = new Point(49, 130);
            dtpStart.Name = "dtpStart";
            dtpStart.Size = new Size(250, 27);
            dtpStart.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(49, 180);
            label2.Name = "label2";
            label2.Size = new Size(73, 20);
            label2.TabIndex = 0;
            label2.Text = "End Date:";
            // 
            // dtpEnd
            // 
            dtpEnd.Location = new Point(49, 228);
            dtpEnd.Name = "dtpEnd";
            dtpEnd.Size = new Size(250, 27);
            dtpEnd.TabIndex = 2;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(49, 279);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(142, 20);
            lblPrice.TabIndex = 0;
            lblPrice.Text = "shows price preview";
            // 
            // btnConfirm
            // 
            btnConfirm.Location = new Point(55, 315);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(94, 29);
            btnConfirm.TabIndex = 3;
            btnConfirm.Text = "Confirm Booking";
            btnConfirm.UseVisualStyleBackColor = true;
            // 
            // BookingForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnConfirm);
            Controls.Add(dtpEnd);
            Controls.Add(dtpStart);
            Controls.Add(lblPrice);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblVehicle);
            Name = "BookingForm";
            Text = "BookingForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblVehicle;
        private Label label1;
        private DateTimePicker dtpStart;
        private Label label2;
        private DateTimePicker dtpEnd;
        private Label lblPrice;
        private Button btnConfirm;
    }
}