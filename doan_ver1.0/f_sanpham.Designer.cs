namespace doan_ver1._0
{
    partial class f_sanpham
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cbDanhMuc_Sp = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtMa_sp = new System.Windows.Forms.TextBox();
            this.txtThanhTien = new System.Windows.Forms.TextBox();
            this.txtDonGia = new System.Windows.Forms.TextBox();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.txtTenSp = new System.Windows.Forms.TextBox();
            this.btnLamMoi_Sp = new System.Windows.Forms.Button();
            this.btnSua_Sp = new System.Windows.Forms.Button();
            this.btnXoa_Sp = new System.Windows.Forms.Button();
            this.btnThem_Sp = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dataGV_sanPham = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btn_TK_LamMoi = new System.Windows.Forms.Button();
            this.data_GV_timKiem = new System.Windows.Forms.DataGridView();
            this.btn_TK_timKiem = new System.Windows.Forms.Button();
            this.cmb_TK_DanhMuc = new System.Windows.Forms.ComboBox();
            this.txt_TK_Ten = new System.Windows.Forms.TextBox();
            this.txt_TK_MaSP = new System.Windows.Forms.TextBox();
            this.rad_TK_DanhMuc = new System.Windows.Forms.RadioButton();
            this.rad_TK_Ten = new System.Windows.Forms.RadioButton();
            this.rad_TK_Ma = new System.Windows.Forms.RadioButton();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGV_sanPham)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data_GV_timKiem)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1035, 575);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cbDanhMuc_Sp);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.txtMa_sp);
            this.tabPage1.Controls.Add(this.txtThanhTien);
            this.tabPage1.Controls.Add(this.txtDonGia);
            this.tabPage1.Controls.Add(this.txtSoLuong);
            this.tabPage1.Controls.Add(this.txtTenSp);
            this.tabPage1.Controls.Add(this.btnLamMoi_Sp);
            this.tabPage1.Controls.Add(this.btnSua_Sp);
            this.tabPage1.Controls.Add(this.btnXoa_Sp);
            this.tabPage1.Controls.Add(this.btnThem_Sp);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.dataGV_sanPham);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(871, 454);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Quản Lý Sản Phẩm";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cbDanhMuc_Sp
            // 
            this.cbDanhMuc_Sp.FormattingEnabled = true;
            this.cbDanhMuc_Sp.Items.AddRange(new object[] {
            "Điện Lạnh",
            "Gia Dụng ",
            "Điện Tử"});
            this.cbDanhMuc_Sp.Location = new System.Drawing.Point(580, 32);
            this.cbDanhMuc_Sp.Name = "cbDanhMuc_Sp";
            this.cbDanhMuc_Sp.Size = new System.Drawing.Size(196, 24);
            this.cbDanhMuc_Sp.TabIndex = 34;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(21, 13);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(91, 16);
            this.label13.TabIndex = 33;
            this.label13.Text = "Mã Sản Phẩm";
            // 
            // txtMa_sp
            // 
            this.txtMa_sp.Location = new System.Drawing.Point(21, 37);
            this.txtMa_sp.Name = "txtMa_sp";
            this.txtMa_sp.Size = new System.Drawing.Size(196, 22);
            this.txtMa_sp.TabIndex = 32;
            // 
            // txtThanhTien
            // 
            this.txtThanhTien.Location = new System.Drawing.Point(580, 100);
            this.txtThanhTien.Name = "txtThanhTien";
            this.txtThanhTien.ReadOnly = true;
            this.txtThanhTien.Size = new System.Drawing.Size(196, 22);
            this.txtThanhTien.TabIndex = 25;
            // 
            // txtDonGia
            // 
            this.txtDonGia.Location = new System.Drawing.Point(311, 31);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.Size = new System.Drawing.Size(196, 22);
            this.txtDonGia.TabIndex = 23;
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(311, 100);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(196, 22);
            this.txtSoLuong.TabIndex = 21;
            // 
            // txtTenSp
            // 
            this.txtTenSp.Location = new System.Drawing.Point(21, 98);
            this.txtTenSp.Name = "txtTenSp";
            this.txtTenSp.Size = new System.Drawing.Size(196, 22);
            this.txtTenSp.TabIndex = 19;
            // 
            // btnLamMoi_Sp
            // 
            this.btnLamMoi_Sp.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnLamMoi_Sp.ForeColor = System.Drawing.Color.Black;
            this.btnLamMoi_Sp.Location = new System.Drawing.Point(650, 138);
            this.btnLamMoi_Sp.Name = "btnLamMoi_Sp";
            this.btnLamMoi_Sp.Size = new System.Drawing.Size(158, 59);
            this.btnLamMoi_Sp.TabIndex = 31;
            this.btnLamMoi_Sp.Text = "Làm Mới";
            this.btnLamMoi_Sp.UseVisualStyleBackColor = false;
            this.btnLamMoi_Sp.Click += new System.EventHandler(this.btnLamMoi_Sp_Click_1);
            // 
            // btnSua_Sp
            // 
            this.btnSua_Sp.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnSua_Sp.ForeColor = System.Drawing.Color.Black;
            this.btnSua_Sp.Location = new System.Drawing.Point(438, 138);
            this.btnSua_Sp.Name = "btnSua_Sp";
            this.btnSua_Sp.Size = new System.Drawing.Size(158, 59);
            this.btnSua_Sp.TabIndex = 30;
            this.btnSua_Sp.Text = "Cập Nhật";
            this.btnSua_Sp.UseVisualStyleBackColor = false;
            this.btnSua_Sp.Click += new System.EventHandler(this.btnSua_Sp_Click);
            // 
            // btnXoa_Sp
            // 
            this.btnXoa_Sp.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnXoa_Sp.ForeColor = System.Drawing.Color.Black;
            this.btnXoa_Sp.Location = new System.Drawing.Point(235, 138);
            this.btnXoa_Sp.Name = "btnXoa_Sp";
            this.btnXoa_Sp.Size = new System.Drawing.Size(158, 59);
            this.btnXoa_Sp.TabIndex = 29;
            this.btnXoa_Sp.Text = "Xóa";
            this.btnXoa_Sp.UseVisualStyleBackColor = false;
            this.btnXoa_Sp.Click += new System.EventHandler(this.btnXoa_Sp_Click);
            // 
            // btnThem_Sp
            // 
            this.btnThem_Sp.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnThem_Sp.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnThem_Sp.Location = new System.Drawing.Point(24, 142);
            this.btnThem_Sp.Name = "btnThem_Sp";
            this.btnThem_Sp.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnThem_Sp.Size = new System.Drawing.Size(158, 59);
            this.btnThem_Sp.TabIndex = 28;
            this.btnThem_Sp.Text = "Thêm";
            this.btnThem_Sp.UseVisualStyleBackColor = false;
            this.btnThem_Sp.Click += new System.EventHandler(this.btnThem_Sp_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(580, 11);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(73, 20);
            this.label12.TabIndex = 27;
            this.label12.Text = "Danh Mục\r\n";
            this.label12.UseCompatibleTextRendering = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(580, 74);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 20);
            this.label11.TabIndex = 26;
            this.label11.Text = "Thành Tiền";
            this.label11.UseCompatibleTextRendering = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(311, 8);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 20);
            this.label10.TabIndex = 24;
            this.label10.Text = "Đơn Giá";
            this.label10.UseCompatibleTextRendering = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(312, 77);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 16);
            this.label9.TabIndex = 22;
            this.label9.Text = "Số Lượng";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(21, 74);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 16);
            this.label8.TabIndex = 20;
            this.label8.Text = "Tên Sản Phẩm";
            // 
            // dataGV_sanPham
            // 
            this.dataGV_sanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGV_sanPham.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGV_sanPham.Location = new System.Drawing.Point(3, 214);
            this.dataGV_sanPham.Name = "dataGV_sanPham";
            this.dataGV_sanPham.RowHeadersWidth = 51;
            this.dataGV_sanPham.RowTemplate.Height = 24;
            this.dataGV_sanPham.Size = new System.Drawing.Size(865, 237);
            this.dataGV_sanPham.TabIndex = 18;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btn_TK_LamMoi);
            this.tabPage2.Controls.Add(this.data_GV_timKiem);
            this.tabPage2.Controls.Add(this.btn_TK_timKiem);
            this.tabPage2.Controls.Add(this.cmb_TK_DanhMuc);
            this.tabPage2.Controls.Add(this.txt_TK_Ten);
            this.tabPage2.Controls.Add(this.txt_TK_MaSP);
            this.tabPage2.Controls.Add(this.rad_TK_DanhMuc);
            this.tabPage2.Controls.Add(this.rad_TK_Ten);
            this.tabPage2.Controls.Add(this.rad_TK_Ma);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1027, 546);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Tìm Kiếm Sản Phẩm";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btn_TK_LamMoi
            // 
            this.btn_TK_LamMoi.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btn_TK_LamMoi.ForeColor = System.Drawing.Color.Black;
            this.btn_TK_LamMoi.Location = new System.Drawing.Point(246, 148);
            this.btn_TK_LamMoi.Name = "btn_TK_LamMoi";
            this.btn_TK_LamMoi.Size = new System.Drawing.Size(173, 44);
            this.btn_TK_LamMoi.TabIndex = 9;
            this.btn_TK_LamMoi.Text = "Làm mới";
            this.btn_TK_LamMoi.UseVisualStyleBackColor = false;
            // 
            // data_GV_timKiem
            // 
            this.data_GV_timKiem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data_GV_timKiem.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.data_GV_timKiem.Location = new System.Drawing.Point(3, 297);
            this.data_GV_timKiem.Name = "data_GV_timKiem";
            this.data_GV_timKiem.RowHeadersWidth = 51;
            this.data_GV_timKiem.RowTemplate.Height = 24;
            this.data_GV_timKiem.Size = new System.Drawing.Size(1021, 246);
            this.data_GV_timKiem.TabIndex = 8;
            // 
            // btn_TK_timKiem
            // 
            this.btn_TK_timKiem.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btn_TK_timKiem.ForeColor = System.Drawing.Color.Black;
            this.btn_TK_timKiem.Location = new System.Drawing.Point(27, 148);
            this.btn_TK_timKiem.Name = "btn_TK_timKiem";
            this.btn_TK_timKiem.Size = new System.Drawing.Size(173, 44);
            this.btn_TK_timKiem.TabIndex = 6;
            this.btn_TK_timKiem.Text = "Tìm Kiếm";
            this.btn_TK_timKiem.UseVisualStyleBackColor = false;
            this.btn_TK_timKiem.Click += new System.EventHandler(this.btn_TK_timKiem_Click);
            // 
            // cmb_TK_DanhMuc
            // 
            this.cmb_TK_DanhMuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_TK_DanhMuc.FormattingEnabled = true;
            this.cmb_TK_DanhMuc.Items.AddRange(new object[] {
            "Điện Lạnh",
            "Điện Tử",
            "Gia Dụng"});
            this.cmb_TK_DanhMuc.Location = new System.Drawing.Point(246, 106);
            this.cmb_TK_DanhMuc.Name = "cmb_TK_DanhMuc";
            this.cmb_TK_DanhMuc.Size = new System.Drawing.Size(281, 24);
            this.cmb_TK_DanhMuc.TabIndex = 5;
            // 
            // txt_TK_Ten
            // 
            this.txt_TK_Ten.Location = new System.Drawing.Point(246, 59);
            this.txt_TK_Ten.Name = "txt_TK_Ten";
            this.txt_TK_Ten.Size = new System.Drawing.Size(281, 22);
            this.txt_TK_Ten.TabIndex = 4;
            // 
            // txt_TK_MaSP
            // 
            this.txt_TK_MaSP.Location = new System.Drawing.Point(246, 14);
            this.txt_TK_MaSP.Name = "txt_TK_MaSP";
            this.txt_TK_MaSP.Size = new System.Drawing.Size(281, 22);
            this.txt_TK_MaSP.TabIndex = 3;
            // 
            // rad_TK_DanhMuc
            // 
            this.rad_TK_DanhMuc.AutoSize = true;
            this.rad_TK_DanhMuc.ForeColor = System.Drawing.Color.Black;
            this.rad_TK_DanhMuc.Location = new System.Drawing.Point(27, 110);
            this.rad_TK_DanhMuc.Name = "rad_TK_DanhMuc";
            this.rad_TK_DanhMuc.Size = new System.Drawing.Size(173, 20);
            this.rad_TK_DanhMuc.TabIndex = 2;
            this.rad_TK_DanhMuc.Text = "Tìm kiếm theo danh mục";
            this.rad_TK_DanhMuc.UseVisualStyleBackColor = true;
            // 
            // rad_TK_Ten
            // 
            this.rad_TK_Ten.AutoSize = true;
            this.rad_TK_Ten.ForeColor = System.Drawing.Color.Black;
            this.rad_TK_Ten.Location = new System.Drawing.Point(27, 62);
            this.rad_TK_Ten.Name = "rad_TK_Ten";
            this.rad_TK_Ten.Size = new System.Drawing.Size(195, 20);
            this.rad_TK_Ten.TabIndex = 1;
            this.rad_TK_Ten.Text = "Tìm kiếm theo tên sản phẩm";
            this.rad_TK_Ten.UseVisualStyleBackColor = true;
            // 
            // rad_TK_Ma
            // 
            this.rad_TK_Ma.AutoSize = true;
            this.rad_TK_Ma.Checked = true;
            this.rad_TK_Ma.ForeColor = System.Drawing.Color.Black;
            this.rad_TK_Ma.Location = new System.Drawing.Point(27, 17);
            this.rad_TK_Ma.Name = "rad_TK_Ma";
            this.rad_TK_Ma.Size = new System.Drawing.Size(196, 20);
            this.rad_TK_Ma.TabIndex = 0;
            this.rad_TK_Ma.TabStop = true;
            this.rad_TK_Ma.Text = "Tìm kiếm theo mã sản phẩm";
            this.rad_TK_Ma.UseVisualStyleBackColor = true;
            // 
            // f_sanpham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1059, 599);
            this.Controls.Add(this.tabControl1);
            this.Name = "f_sanpham";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.f_sanpham_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGV_sanPham)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data_GV_timKiem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ComboBox cbDanhMuc_Sp;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtMa_sp;
        private System.Windows.Forms.TextBox txtThanhTien;
        private System.Windows.Forms.TextBox txtDonGia;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.TextBox txtTenSp;
        private System.Windows.Forms.Button btnLamMoi_Sp;
        private System.Windows.Forms.Button btnSua_Sp;
        private System.Windows.Forms.Button btnXoa_Sp;
        private System.Windows.Forms.Button btnThem_Sp;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dataGV_sanPham;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btn_TK_LamMoi;
        private System.Windows.Forms.DataGridView data_GV_timKiem;
        private System.Windows.Forms.Button btn_TK_timKiem;
        private System.Windows.Forms.ComboBox cmb_TK_DanhMuc;
        private System.Windows.Forms.TextBox txt_TK_Ten;
        private System.Windows.Forms.TextBox txt_TK_MaSP;
        private System.Windows.Forms.RadioButton rad_TK_DanhMuc;
        private System.Windows.Forms.RadioButton rad_TK_Ten;
        private System.Windows.Forms.RadioButton rad_TK_Ma;
    }
}