namespace QuanLyLuongCtyNN
{
    partial class frmHeSoLuong
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnHeSoLuong = new Guna.UI2.WinForms.Guna2Button();
            this.btnNhanVien = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(47)))), ((int)(((byte)(25)))));
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1080, 111);
            this.panel1.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.panel3.Controls.Add(this.btnHeSoLuong);
            this.panel3.Controls.Add(this.btnNhanVien);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 61);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1080, 50);
            this.panel3.TabIndex = 1;
            // 
            // btnHeSoLuong
            // 
            this.btnHeSoLuong.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnHeSoLuong.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(47)))), ((int)(((byte)(25)))));
            this.btnHeSoLuong.CheckedState.FillColor = System.Drawing.Color.White;
            this.btnHeSoLuong.CustomBorderColor = System.Drawing.Color.White;
            this.btnHeSoLuong.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.btnHeSoLuong.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnHeSoLuong.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnHeSoLuong.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnHeSoLuong.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnHeSoLuong.FillColor = System.Drawing.Color.White;
            this.btnHeSoLuong.Font = new System.Drawing.Font("Roboto Condensed", 10F);
            this.btnHeSoLuong.ForeColor = System.Drawing.Color.Black;
            this.btnHeSoLuong.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnHeSoLuong.Location = new System.Drawing.Point(106, 0);
            this.btnHeSoLuong.Name = "btnHeSoLuong";
            this.btnHeSoLuong.Size = new System.Drawing.Size(116, 50);
            this.btnHeSoLuong.TabIndex = 1;
            this.btnHeSoLuong.Text = "Hệ số lương";
            this.btnHeSoLuong.Click += new System.EventHandler(this.btnHeSoLuong_Click);
            // 
            // btnNhanVien
            // 
            this.btnNhanVien.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnNhanVien.Checked = true;
            this.btnNhanVien.CheckedState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(47)))), ((int)(((byte)(25)))));
            this.btnNhanVien.CheckedState.FillColor = System.Drawing.Color.White;
            this.btnNhanVien.CustomBorderColor = System.Drawing.Color.White;
            this.btnNhanVien.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.btnNhanVien.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnNhanVien.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnNhanVien.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnNhanVien.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnNhanVien.FillColor = System.Drawing.Color.White;
            this.btnNhanVien.Font = new System.Drawing.Font("Roboto Condensed", 10F);
            this.btnNhanVien.ForeColor = System.Drawing.Color.Black;
            this.btnNhanVien.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnNhanVien.Location = new System.Drawing.Point(0, 0);
            this.btnNhanVien.Name = "btnNhanVien";
            this.btnNhanVien.Size = new System.Drawing.Size(109, 50);
            this.btnNhanVien.TabIndex = 0;
            this.btnNhanVien.Text = "Nhân viên";
            this.btnNhanVien.Click += new System.EventHandler(this.btnNhanVien_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto Condensed", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(216)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(405, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hệ số lương nhân viên";
            // 
            // panelContainer
            // 
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(0, 111);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(1080, 424);
            this.panelContainer.TabIndex = 5;
            // 
            // frmHeSoLuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 535);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.panel1);
            this.Name = "frmHeSoLuong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ số lương";
            this.Load += new System.EventHandler(this.frmHeSoLuong_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private Guna.UI2.WinForms.Guna2Button btnHeSoLuong;
        private Guna.UI2.WinForms.Guna2Button btnNhanVien;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelContainer;
    }
}