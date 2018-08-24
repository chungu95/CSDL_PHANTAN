namespace QLVT.View
{
    partial class frmPhieuNhap
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbDonDDH = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaPhieuNhap = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.txtSoLuongNhap = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbMaVT = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtSoLuongTrongPhieu = new System.Windows.Forms.TextBox();
            this.txtSoLuongDat = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnLapPhieuNhap = new System.Windows.Forms.Button();
            this.btnLuuPhieuNhap = new System.Windows.Forms.Button();
            this.btnHoanTat = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(108, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã Đơn Hàng";
            // 
            // cmbDonDDH
            // 
            this.cmbDonDDH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDonDDH.FormattingEnabled = true;
            this.cmbDonDDH.Location = new System.Drawing.Point(186, 43);
            this.cmbDonDDH.Name = "cmbDonDDH";
            this.cmbDonDDH.Size = new System.Drawing.Size(121, 21);
            this.cmbDonDDH.TabIndex = 1;
            this.cmbDonDDH.SelectedIndexChanged += new System.EventHandler(this.cmbDonDDH_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(405, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mã Phiếu Nhập";
            // 
            // txtMaPhieuNhap
            // 
            this.txtMaPhieuNhap.Location = new System.Drawing.Point(509, 43);
            this.txtMaPhieuNhap.Name = "txtMaPhieuNhap";
            this.txtMaPhieuNhap.Size = new System.Drawing.Size(133, 21);
            this.txtMaPhieuNhap.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnThem);
            this.groupBox1.Controls.Add(this.txtSoLuongNhap);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmbMaVT);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(111, 112);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(291, 273);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chi Tiết Phiếu Nhập";
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(106, 164);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 6;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // txtSoLuongNhap
            // 
            this.txtSoLuongNhap.Location = new System.Drawing.Point(136, 98);
            this.txtSoLuongNhap.Name = "txtSoLuongNhap";
            this.txtSoLuongNhap.Size = new System.Drawing.Size(121, 21);
            this.txtSoLuongNhap.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Số Lượng Nhập";
            // 
            // cmbMaVT
            // 
            this.cmbMaVT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMaVT.FormattingEnabled = true;
            this.cmbMaVT.Location = new System.Drawing.Point(136, 33);
            this.cmbMaVT.Name = "cmbMaVT";
            this.cmbMaVT.Size = new System.Drawing.Size(121, 21);
            this.cmbMaVT.TabIndex = 1;
            this.cmbMaVT.SelectedIndexChanged += new System.EventHandler(this.cmbMaVT_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Mã VT";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtSoLuongTrongPhieu);
            this.groupBox2.Controls.Add(this.txtSoLuongDat);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(398, 112);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(244, 273);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            // 
            // txtSoLuongTrongPhieu
            // 
            this.txtSoLuongTrongPhieu.Location = new System.Drawing.Point(156, 95);
            this.txtSoLuongTrongPhieu.Name = "txtSoLuongTrongPhieu";
            this.txtSoLuongTrongPhieu.ReadOnly = true;
            this.txtSoLuongTrongPhieu.Size = new System.Drawing.Size(72, 21);
            this.txtSoLuongTrongPhieu.TabIndex = 3;
            // 
            // txtSoLuongDat
            // 
            this.txtSoLuongDat.Location = new System.Drawing.Point(113, 33);
            this.txtSoLuongDat.Name = "txtSoLuongDat";
            this.txtSoLuongDat.ReadOnly = true;
            this.txtSoLuongDat.Size = new System.Drawing.Size(115, 21);
            this.txtSoLuongDat.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 98);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Số Lượng trong phiếu";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Số Lượng Đặt";
            // 
            // btnLapPhieuNhap
            // 
            this.btnLapPhieuNhap.Location = new System.Drawing.Point(668, 112);
            this.btnLapPhieuNhap.Name = "btnLapPhieuNhap";
            this.btnLapPhieuNhap.Size = new System.Drawing.Size(75, 54);
            this.btnLapPhieuNhap.TabIndex = 6;
            this.btnLapPhieuNhap.Text = "Lập Phiếu Nhập";
            this.btnLapPhieuNhap.UseVisualStyleBackColor = true;
            // 
            // btnLuuPhieuNhap
            // 
            this.btnLuuPhieuNhap.Location = new System.Drawing.Point(668, 189);
            this.btnLuuPhieuNhap.Name = "btnLuuPhieuNhap";
            this.btnLuuPhieuNhap.Size = new System.Drawing.Size(75, 54);
            this.btnLuuPhieuNhap.TabIndex = 7;
            this.btnLuuPhieuNhap.Text = "Lưu Phiếu Nhập";
            this.btnLuuPhieuNhap.UseVisualStyleBackColor = true;
            this.btnLuuPhieuNhap.Click += new System.EventHandler(this.btnLuuPhieuNhap_Click);
            // 
            // btnHoanTat
            // 
            this.btnHoanTat.Location = new System.Drawing.Point(668, 261);
            this.btnHoanTat.Name = "btnHoanTat";
            this.btnHoanTat.Size = new System.Drawing.Size(75, 53);
            this.btnHoanTat.TabIndex = 8;
            this.btnHoanTat.Text = "Hoàn Tất";
            this.btnHoanTat.UseVisualStyleBackColor = true;
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(668, 333);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 52);
            this.btnThoat.TabIndex = 9;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            // 
            // frmPhieuNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 426);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnHoanTat);
            this.Controls.Add(this.btnLuuPhieuNhap);
            this.Controls.Add(this.btnLapPhieuNhap);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtMaPhieuNhap);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbDonDDH);
            this.Controls.Add(this.label1);
            this.Name = "frmPhieuNhap";
            this.Text = "frmPhieuNhap";
            this.Load += new System.EventHandler(this.frmPhieuNhap_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbDonDDH;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMaPhieuNhap;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtSoLuongNhap;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbMaVT;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtSoLuongDat;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnLapPhieuNhap;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnLuuPhieuNhap;
        private System.Windows.Forms.Button btnHoanTat;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.TextBox txtSoLuongTrongPhieu;
        private System.Windows.Forms.Label label7;
    }
}