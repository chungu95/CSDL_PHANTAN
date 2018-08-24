namespace QLVT.View 
{
    partial class frmAddLogin
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
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.lblHoten = new System.Windows.Forms.Label();
            this.cbbGiaoDichVien = new System.Windows.Forms.ComboBox();
            this.lblLoginName = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.rbChinhanh = new System.Windows.Forms.RadioButton();
            this.rbCongty = new System.Windows.Forms.RadioButton();
            this.lblNhom = new System.Windows.Forms.Label();
            this.lblThongBao = new System.Windows.Forms.Label();
            this.rbUser = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDe.ForeColor = System.Drawing.Color.Red;
            this.lblTieuDe.Location = new System.Drawing.Point(163, 39);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(283, 16);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "TẠO USERNAME ĐĂNG NHẬP CHƯƠNG TRÌNH";
            // 
            // lblHoten
            // 
            this.lblHoten.AutoSize = true;
            this.lblHoten.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHoten.Location = new System.Drawing.Point(190, 96);
            this.lblHoten.Name = "lblHoten";
            this.lblHoten.Size = new System.Drawing.Size(113, 14);
            this.lblHoten.TabIndex = 1;
            this.lblHoten.Text = "Họ tên nhân viên";
            // 
            // cbbGiaoDichVien
            // 
            this.cbbGiaoDichVien.FormattingEnabled = true;
            this.cbbGiaoDichVien.Location = new System.Drawing.Point(403, 94);
            this.cbbGiaoDichVien.Name = "cbbGiaoDichVien";
            this.cbbGiaoDichVien.Size = new System.Drawing.Size(209, 21);
            this.cbbGiaoDichVien.TabIndex = 2;
            this.cbbGiaoDichVien.SelectionChangeCommitted += new System.EventHandler(this.cbbGiaoDichVien_SelectionChangeCommitted);
            // 
            // lblLoginName
            // 
            this.lblLoginName.AutoSize = true;
            this.lblLoginName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoginName.Location = new System.Drawing.Point(190, 148);
            this.lblLoginName.Name = "lblLoginName";
            this.lblLoginName.Size = new System.Drawing.Size(82, 14);
            this.lblLoginName.TabIndex = 3;
            this.lblLoginName.Text = "Login name:";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(403, 146);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(135, 21);
            this.txtUserName.TabIndex = 4;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(190, 201);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(70, 14);
            this.lblPassword.TabIndex = 5;
            this.lblPassword.Text = "Password:";
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(403, 199);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(135, 21);
            this.txtPass.TabIndex = 6;
            // 
            // btnAddUser
            // 
            this.btnAddUser.Enabled = false;
            this.btnAddUser.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddUser.Location = new System.Drawing.Point(166, 327);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(123, 42);
            this.btnAddUser.TabIndex = 7;
            this.btnAddUser.Text = "Tạo User";
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Location = new System.Drawing.Point(500, 327);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(131, 42);
            this.btnThoat.TabIndex = 9;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // rbChinhanh
            // 
            this.rbChinhanh.AutoSize = true;
            this.rbChinhanh.Location = new System.Drawing.Point(403, 254);
            this.rbChinhanh.Name = "rbChinhanh";
            this.rbChinhanh.Size = new System.Drawing.Size(73, 17);
            this.rbChinhanh.TabIndex = 10;
            this.rbChinhanh.TabStop = true;
            this.rbChinhanh.Text = "Chi nhánh";
            this.rbChinhanh.UseVisualStyleBackColor = true;
            this.rbChinhanh.CheckedChanged += new System.EventHandler(this.rbChinhanh_CheckedChanged);
            // 
            // rbCongty
            // 
            this.rbCongty.AutoSize = true;
            this.rbCongty.Location = new System.Drawing.Point(521, 254);
            this.rbCongty.Name = "rbCongty";
            this.rbCongty.Size = new System.Drawing.Size(63, 17);
            this.rbCongty.TabIndex = 11;
            this.rbCongty.TabStop = true;
            this.rbCongty.Text = "Công ty";
            this.rbCongty.UseVisualStyleBackColor = true;
            this.rbCongty.CheckedChanged += new System.EventHandler(this.rbCongty_CheckedChanged);
            // 
            // lblNhom
            // 
            this.lblNhom.AutoSize = true;
            this.lblNhom.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNhom.Location = new System.Drawing.Point(190, 254);
            this.lblNhom.Name = "lblNhom";
            this.lblNhom.Size = new System.Drawing.Size(91, 14);
            this.lblNhom.TabIndex = 12;
            this.lblNhom.Text = "Thuộc nhóm: ";
            // 
            // lblThongBao
            // 
            this.lblThongBao.AutoSize = true;
            this.lblThongBao.Font = new System.Drawing.Font("Tahoma", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThongBao.ForeColor = System.Drawing.Color.Red;
            this.lblThongBao.Location = new System.Drawing.Point(305, 295);
            this.lblThongBao.Name = "lblThongBao";
            this.lblThongBao.Size = new System.Drawing.Size(0, 14);
            this.lblThongBao.TabIndex = 13;
            this.lblThongBao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rbUser
            // 
            this.rbUser.AutoSize = true;
            this.rbUser.Location = new System.Drawing.Point(614, 254);
            this.rbUser.Name = "rbUser";
            this.rbUser.Size = new System.Drawing.Size(47, 17);
            this.rbUser.TabIndex = 14;
            this.rbUser.TabStop = true;
            this.rbUser.Text = "User";
            this.rbUser.UseVisualStyleBackColor = true;
            this.rbUser.CheckedChanged += new System.EventHandler(this.rbUser_CheckedChanged);
            // 
            // frmAddLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 423);
            this.Controls.Add(this.rbUser);
            this.Controls.Add(this.lblThongBao);
            this.Controls.Add(this.lblNhom);
            this.Controls.Add(this.rbCongty);
            this.Controls.Add(this.rbChinhanh);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnAddUser);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.lblLoginName);
            this.Controls.Add(this.cbbGiaoDichVien);
            this.Controls.Add(this.lblHoten);
            this.Controls.Add(this.lblTieuDe);
            this.Name = "frmAddLogin";
            this.Text = "frmAddLogin";
            this.Load += new System.EventHandler(this.frmAddLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblHoten;
        private System.Windows.Forms.ComboBox cbbGiaoDichVien;
        private System.Windows.Forms.Label lblLoginName;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.RadioButton rbChinhanh;
        private System.Windows.Forms.RadioButton rbCongty;
        private System.Windows.Forms.Label lblNhom;
        private System.Windows.Forms.Label lblThongBao;
        private System.Windows.Forms.RadioButton rbUser;
    }
}