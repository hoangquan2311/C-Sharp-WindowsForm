namespace QuanLyLuongCtyNN
{
    partial class frmSearch
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvSearch = new System.Windows.Forms.DataGridView();
            this.gbThongTin = new System.Windows.Forms.GroupBox();
            this.btnSearchTen = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTen = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbChuyenMon = new System.Windows.Forms.ComboBox();
            this.cbTrinhDo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbHSL = new System.Windows.Forms.ComboBox();
            this.btnSearchCM = new System.Windows.Forms.Button();
            this.btnSearchTD = new System.Windows.Forms.Button();
            this.btnSearchHSL = new System.Windows.Forms.Button();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearch)).BeginInit();
            this.gbThongTin.SuspendLayout();
            this.panelContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(47)))), ((int)(((byte)(25)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1057, 73);
            this.panel1.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto Condensed", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(216)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(411, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tìm kiếm nhân viên";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvSearch);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(0, 121);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1057, 512);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách";
            // 
            // dgvSearch
            // 
            this.dgvSearch.AllowUserToAddRows = false;
            this.dgvSearch.AllowUserToDeleteRows = false;
            this.dgvSearch.AllowUserToOrderColumns = true;
            this.dgvSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSearch.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSearch.Location = new System.Drawing.Point(16, 23);
            this.dgvSearch.MultiSelect = false;
            this.dgvSearch.Name = "dgvSearch";
            this.dgvSearch.RowHeadersWidth = 51;
            this.dgvSearch.RowTemplate.Height = 24;
            this.dgvSearch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSearch.ShowEditingIcon = false;
            this.dgvSearch.Size = new System.Drawing.Size(1029, 477);
            this.dgvSearch.TabIndex = 0;
            // 
            // gbThongTin
            // 
            this.gbThongTin.Controls.Add(this.button1);
            this.gbThongTin.Controls.Add(this.cbHSL);
            this.gbThongTin.Controls.Add(this.cbTrinhDo);
            this.gbThongTin.Controls.Add(this.cbChuyenMon);
            this.gbThongTin.Controls.Add(this.label5);
            this.gbThongTin.Controls.Add(this.btnSearchHSL);
            this.gbThongTin.Controls.Add(this.btnSearchTD);
            this.gbThongTin.Controls.Add(this.btnSearchCM);
            this.gbThongTin.Controls.Add(this.btnSearchTen);
            this.gbThongTin.Controls.Add(this.label4);
            this.gbThongTin.Controls.Add(this.label3);
            this.gbThongTin.Controls.Add(this.txtTen);
            this.gbThongTin.Controls.Add(this.label2);
            this.gbThongTin.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbThongTin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbThongTin.Location = new System.Drawing.Point(0, 0);
            this.gbThongTin.Name = "gbThongTin";
            this.gbThongTin.Size = new System.Drawing.Size(1057, 121);
            this.gbThongTin.TabIndex = 13;
            this.gbThongTin.TabStop = false;
            this.gbThongTin.Text = "Tìm kiếm";
            // 
            // btnSearchTen
            // 
            this.btnSearchTen.BackColor = System.Drawing.Color.LimeGreen;
            this.btnSearchTen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchTen.ForeColor = System.Drawing.Color.White;
            this.btnSearchTen.Location = new System.Drawing.Point(38, 76);
            this.btnSearchTen.Name = "btnSearchTen";
            this.btnSearchTen.Size = new System.Drawing.Size(68, 30);
            this.btnSearchTen.TabIndex = 16;
            this.btnSearchTen.Text = "Search";
            this.btnSearchTen.UseVisualStyleBackColor = false;
            this.btnSearchTen.Click += new System.EventHandler(this.btnSearchTen_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(526, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "Trình độ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(275, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Chuyên môn";
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(38, 46);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(209, 23);
            this.txtTen.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Họ tên nhân viên";
            // 
            // cbChuyenMon
            // 
            this.cbChuyenMon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbChuyenMon.FormattingEnabled = true;
            this.cbChuyenMon.Location = new System.Drawing.Point(278, 46);
            this.cbChuyenMon.Name = "cbChuyenMon";
            this.cbChuyenMon.Size = new System.Drawing.Size(217, 24);
            this.cbChuyenMon.TabIndex = 17;
            // 
            // cbTrinhDo
            // 
            this.cbTrinhDo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTrinhDo.FormattingEnabled = true;
            this.cbTrinhDo.Location = new System.Drawing.Point(529, 46);
            this.cbTrinhDo.Name = "cbTrinhDo";
            this.cbTrinhDo.Size = new System.Drawing.Size(118, 24);
            this.cbTrinhDo.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(683, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 17);
            this.label5.TabIndex = 13;
            this.label5.Text = "Hệ số lương";
            // 
            // cbHSL
            // 
            this.cbHSL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHSL.FormattingEnabled = true;
            this.cbHSL.Location = new System.Drawing.Point(686, 46);
            this.cbHSL.Name = "cbHSL";
            this.cbHSL.Size = new System.Drawing.Size(92, 24);
            this.cbHSL.TabIndex = 17;
            // 
            // btnSearchCM
            // 
            this.btnSearchCM.BackColor = System.Drawing.Color.LimeGreen;
            this.btnSearchCM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchCM.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchCM.ForeColor = System.Drawing.Color.White;
            this.btnSearchCM.Location = new System.Drawing.Point(278, 76);
            this.btnSearchCM.Name = "btnSearchCM";
            this.btnSearchCM.Size = new System.Drawing.Size(74, 30);
            this.btnSearchCM.TabIndex = 16;
            this.btnSearchCM.Text = "Search";
            this.btnSearchCM.UseVisualStyleBackColor = false;
            this.btnSearchCM.Click += new System.EventHandler(this.btnSearchCM_Click);
            // 
            // btnSearchTD
            // 
            this.btnSearchTD.BackColor = System.Drawing.Color.LimeGreen;
            this.btnSearchTD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchTD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchTD.ForeColor = System.Drawing.Color.White;
            this.btnSearchTD.Location = new System.Drawing.Point(529, 76);
            this.btnSearchTD.Name = "btnSearchTD";
            this.btnSearchTD.Size = new System.Drawing.Size(74, 30);
            this.btnSearchTD.TabIndex = 16;
            this.btnSearchTD.Text = "Search";
            this.btnSearchTD.UseVisualStyleBackColor = false;
            this.btnSearchTD.Click += new System.EventHandler(this.btnSearchTD_Click);
            // 
            // btnSearchHSL
            // 
            this.btnSearchHSL.BackColor = System.Drawing.Color.LimeGreen;
            this.btnSearchHSL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchHSL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchHSL.ForeColor = System.Drawing.Color.White;
            this.btnSearchHSL.Location = new System.Drawing.Point(686, 76);
            this.btnSearchHSL.Name = "btnSearchHSL";
            this.btnSearchHSL.Size = new System.Drawing.Size(74, 30);
            this.btnSearchHSL.TabIndex = 16;
            this.btnSearchHSL.Text = "Search";
            this.btnSearchHSL.UseVisualStyleBackColor = false;
            this.btnSearchHSL.Click += new System.EventHandler(this.btnSearchHSL_Click);
            // 
            // panelContainer
            // 
            this.panelContainer.Controls.Add(this.groupBox2);
            this.panelContainer.Controls.Add(this.gbThongTin);
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(0, 73);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(1057, 633);
            this.panelContainer.TabIndex = 18;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LimeGreen;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(888, 35);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 55);
            this.button1.TabIndex = 18;
            this.button1.Text = "REFRESH";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1057, 706);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.panel1);
            this.Name = "frmSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tìm kiếm";
            this.Load += new System.EventHandler(this.frmSearch_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearch)).EndInit();
            this.gbThongTin.ResumeLayout(false);
            this.gbThongTin.PerformLayout();
            this.panelContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvSearch;
        private System.Windows.Forms.GroupBox gbThongTin;
        private System.Windows.Forms.ComboBox cbHSL;
        private System.Windows.Forms.ComboBox cbTrinhDo;
        private System.Windows.Forms.ComboBox cbChuyenMon;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSearchTen;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox txtTen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSearchHSL;
        private System.Windows.Forms.Button btnSearchTD;
        private System.Windows.Forms.Button btnSearchCM;
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.Button button1;
    }
}