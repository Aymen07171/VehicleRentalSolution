namespace VehicleRental.WinClient
{
    partial class MainForm
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
            lblWelcome = new Label();
            tabControl = new TabControl();
            tabPage3 = new TabPage();
            tabPage4 = new TabPage();
            btnLogout = new Button();
            dgvVehicles = new DataGridView();
            btnRefresh = new Button();
            btnBook = new Button();
            dgvReservations = new DataGridView();
            btnLoadReservations = new Button();
            btnCancel = new Button();
            tabControl.SuspendLayout();
            tabPage3.SuspendLayout();
            tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVehicles).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvReservations).BeginInit();
            SuspendLayout();
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Location = new Point(83, 34);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(75, 20);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Welcome!";
            lblWelcome.Click += label1_Click;
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabPage3);
            tabControl.Controls.Add(tabPage4);
            tabControl.Location = new Point(30, 80);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(758, 285);
            tabControl.TabIndex = 2;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(btnBook);
            tabPage3.Controls.Add(btnRefresh);
            tabPage3.Controls.Add(dgvVehicles);
            tabPage3.Location = new Point(4, 29);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(750, 252);
            tabPage3.TabIndex = 0;
            tabPage3.Text = "Vehicles";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(btnCancel);
            tabPage4.Controls.Add(btnLoadReservations);
            tabPage4.Controls.Add(dgvReservations);
            tabPage4.Location = new Point(4, 29);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(750, 252);
            tabPage4.TabIndex = 1;
            tabPage4.Text = "My Reservations";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(346, 389);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(94, 29);
            btnLogout.TabIndex = 3;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            // 
            // dgvVehicles
            // 
            dgvVehicles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVehicles.Location = new Point(6, 18);
            dgvVehicles.Name = "dgvVehicles";
            dgvVehicles.ReadOnly = true;
            dgvVehicles.RowHeadersWidth = 51;
            dgvVehicles.ShowEditingIcon = false;
            dgvVehicles.Size = new Size(548, 228);
            dgvVehicles.TabIndex = 0;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(616, 70);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(94, 29);
            btnRefresh.TabIndex = 1;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            // 
            // btnBook
            // 
            btnBook.Location = new Point(589, 136);
            btnBook.Name = "btnBook";
            btnBook.Size = new Size(145, 29);
            btnBook.TabIndex = 2;
            btnBook.Text = "Book Selected";
            btnBook.UseVisualStyleBackColor = true;
            // 
            // dgvReservations
            // 
            dgvReservations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReservations.Location = new Point(6, 17);
            dgvReservations.Name = "dgvReservations";
            dgvReservations.ReadOnly = true;
            dgvReservations.RowHeadersWidth = 51;
            dgvReservations.Size = new Size(580, 215);
            dgvReservations.TabIndex = 0;
            // 
            // btnLoadReservations
            // 
            btnLoadReservations.Location = new Point(626, 54);
            btnLoadReservations.Name = "btnLoadReservations";
            btnLoadReservations.Size = new Size(94, 29);
            btnLoadReservations.TabIndex = 1;
            btnLoadReservations.Text = "Load";
            btnLoadReservations.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(595, 126);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(152, 29);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel Selected";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnLogout);
            Controls.Add(tabControl);
            Controls.Add(lblWelcome);
            Name = "MainForm";
            Text = "MainForm";
            tabControl.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
            tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvVehicles).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvReservations).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblWelcome;
        private TabControl tabControl;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private DataGridView dgvVehicles;
        private Button btnLogout;
        private Button btnBook;
        private Button btnRefresh;
        private Button btnCancel;
        private Button btnLoadReservations;
        private DataGridView dgvReservations;
    }
}