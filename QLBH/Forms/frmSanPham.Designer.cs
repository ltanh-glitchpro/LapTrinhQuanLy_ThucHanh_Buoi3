namespace QLBH.Forms
{
    partial class frmSanPham
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            btnXoa = new Button();
            gpbThongTinSanPham = new GroupBox();
            btnDoiAnh = new Button();
            picHinhAnh = new PictureBox();
            txtMoTa = new TextBox();
            lblMoTa = new Label();
            numDonGia = new NumericUpDown();
            numSoLuong = new NumericUpDown();
            cboHangSanXuat = new ComboBox();
            cboLoaiSanPham = new ComboBox();
            lblDonGia = new Label();
            lblSoLuong = new Label();
            btnXuat = new Button();
            btnTimKiem = new Button();
            btnNhap = new Button();
            lblTenSanPham = new Label();
            lblHangSanXuat = new Label();
            txtTenSanPham = new TextBox();
            btnThoat = new Button();
            btnHuybo = new Button();
            btnLuu = new Button();
            btnSua = new Button();
            btnThem = new Button();
            lblPhanLoai = new Label();
            dataGridView = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            TenLoai = new DataGridViewTextBoxColumn();
            TenHangSanXuat = new DataGridViewTextBoxColumn();
            TenSanPham = new DataGridViewTextBoxColumn();
            SoLuong = new DataGridViewTextBoxColumn();
            DonGia = new DataGridViewTextBoxColumn();
            HinhAnh = new DataGridViewImageColumn();
            gpbDanhSach = new GroupBox();
            gpbThongTinSanPham.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picHinhAnh).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numDonGia).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numSoLuong).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            gpbDanhSach.SuspendLayout();
            SuspendLayout();
            // 
            // btnXoa
            // 
            btnXoa.ForeColor = Color.Red;
            btnXoa.Location = new Point(355, 188);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(89, 29);
            btnXoa.TabIndex = 4;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // gpbThongTinSanPham
            // 
            gpbThongTinSanPham.Controls.Add(btnDoiAnh);
            gpbThongTinSanPham.Controls.Add(picHinhAnh);
            gpbThongTinSanPham.Controls.Add(txtMoTa);
            gpbThongTinSanPham.Controls.Add(lblMoTa);
            gpbThongTinSanPham.Controls.Add(numDonGia);
            gpbThongTinSanPham.Controls.Add(numSoLuong);
            gpbThongTinSanPham.Controls.Add(cboHangSanXuat);
            gpbThongTinSanPham.Controls.Add(cboLoaiSanPham);
            gpbThongTinSanPham.Controls.Add(lblDonGia);
            gpbThongTinSanPham.Controls.Add(lblSoLuong);
            gpbThongTinSanPham.Controls.Add(btnXuat);
            gpbThongTinSanPham.Controls.Add(btnTimKiem);
            gpbThongTinSanPham.Controls.Add(btnNhap);
            gpbThongTinSanPham.Controls.Add(lblTenSanPham);
            gpbThongTinSanPham.Controls.Add(lblHangSanXuat);
            gpbThongTinSanPham.Controls.Add(txtTenSanPham);
            gpbThongTinSanPham.Controls.Add(btnThoat);
            gpbThongTinSanPham.Controls.Add(btnHuybo);
            gpbThongTinSanPham.Controls.Add(btnLuu);
            gpbThongTinSanPham.Controls.Add(btnXoa);
            gpbThongTinSanPham.Controls.Add(btnSua);
            gpbThongTinSanPham.Controls.Add(btnThem);
            gpbThongTinSanPham.Controls.Add(lblPhanLoai);
            gpbThongTinSanPham.Location = new Point(8, 6);
            gpbThongTinSanPham.Name = "gpbThongTinSanPham";
            gpbThongTinSanPham.Size = new Size(1140, 223);
            gpbThongTinSanPham.TabIndex = 6;
            gpbThongTinSanPham.TabStop = false;
            gpbThongTinSanPham.Text = "Thông tin sản phẩm";
            // 
            // btnDoiAnh
            // 
            btnDoiAnh.ForeColor = Color.Black;
            btnDoiAnh.Location = new Point(830, 26);
            btnDoiAnh.Name = "btnDoiAnh";
            btnDoiAnh.Size = new Size(89, 29);
            btnDoiAnh.TabIndex = 26;
            btnDoiAnh.Text = "Đổi ảnh...";
            btnDoiAnh.UseVisualStyleBackColor = true;
            btnDoiAnh.Click += btnDoiAnh_Click;
            // 
            // picHinhAnh
            // 
            picHinhAnh.Location = new Point(656, 26);
            picHinhAnh.Name = "picHinhAnh";
            picHinhAnh.Size = new Size(140, 145);
            picHinhAnh.SizeMode = PictureBoxSizeMode.StretchImage;
            picHinhAnh.TabIndex = 25;
            picHinhAnh.TabStop = false;
            // 
            // txtMoTa
            // 
            txtMoTa.Location = new Point(165, 144);
            txtMoTa.Name = "txtMoTa";
            txtMoTa.Size = new Size(466, 27);
            txtMoTa.TabIndex = 24;
            // 
            // lblMoTa
            // 
            lblMoTa.AutoSize = true;
            lblMoTa.Location = new Point(16, 151);
            lblMoTa.Name = "lblMoTa";
            lblMoTa.Size = new Size(143, 20);
            lblMoTa.TabIndex = 23;
            lblMoTa.Text = "Mô Tả Sản Phẩm (*):";
            // 
            // numDonGia
            // 
            numDonGia.Location = new Point(484, 73);
            numDonGia.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            numDonGia.Name = "numDonGia";
            numDonGia.Size = new Size(150, 27);
            numDonGia.TabIndex = 22;
            numDonGia.ThousandsSeparator = true;
            // 
            // numSoLuong
            // 
            numSoLuong.Location = new Point(484, 32);
            numSoLuong.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numSoLuong.Name = "numSoLuong";
            numSoLuong.Size = new Size(150, 27);
            numSoLuong.TabIndex = 21;
            numSoLuong.ThousandsSeparator = true;
            // 
            // cboHangSanXuat
            // 
            cboHangSanXuat.FormattingEnabled = true;
            cboHangSanXuat.Items.AddRange(new object[] { "Quản Lí", "Nhân Viên" });
            cboHangSanXuat.Location = new Point(165, 73);
            cboHangSanXuat.Name = "cboHangSanXuat";
            cboHangSanXuat.Size = new Size(171, 28);
            cboHangSanXuat.TabIndex = 20;
            // 
            // cboLoaiSanPham
            // 
            cboLoaiSanPham.FormattingEnabled = true;
            cboLoaiSanPham.Items.AddRange(new object[] { "Quản Lí", "Nhân Viên" });
            cboLoaiSanPham.Location = new Point(165, 39);
            cboLoaiSanPham.Name = "cboLoaiSanPham";
            cboLoaiSanPham.Size = new Size(171, 28);
            cboLoaiSanPham.TabIndex = 19;
            // 
            // lblDonGia
            // 
            lblDonGia.AutoSize = true;
            lblDonGia.Location = new Point(378, 78);
            lblDonGia.Name = "lblDonGia";
            lblDonGia.Size = new Size(86, 20);
            lblDonGia.TabIndex = 14;
            lblDonGia.Text = "Đơn Giá (*):";
            // 
            // lblSoLuong
            // 
            lblSoLuong.AutoSize = true;
            lblSoLuong.Location = new Point(378, 39);
            lblSoLuong.Name = "lblSoLuong";
            lblSoLuong.Size = new Size(95, 20);
            lblSoLuong.TabIndex = 13;
            lblSoLuong.Text = "Số Lượng (*):";
            // 
            // btnXuat
            // 
            btnXuat.ForeColor = Color.Black;
            btnXuat.Location = new Point(925, 188);
            btnXuat.Name = "btnXuat";
            btnXuat.Size = new Size(89, 29);
            btnXuat.TabIndex = 6;
            btnXuat.Text = "Xuất...";
            btnXuat.UseVisualStyleBackColor = true;
            // 
            // btnTimKiem
            // 
            btnTimKiem.ForeColor = Color.Black;
            btnTimKiem.Location = new Point(735, 188);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(89, 29);
            btnTimKiem.TabIndex = 7;
            btnTimKiem.Text = "Tìm Kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            // 
            // btnNhap
            // 
            btnNhap.ForeColor = Color.Black;
            btnNhap.Location = new Point(830, 188);
            btnNhap.Name = "btnNhap";
            btnNhap.Size = new Size(89, 29);
            btnNhap.TabIndex = 12;
            btnNhap.Text = "Nhập...";
            btnNhap.UseVisualStyleBackColor = true;
            // 
            // lblTenSanPham
            // 
            lblTenSanPham.AutoSize = true;
            lblTenSanPham.Location = new Point(16, 116);
            lblTenSanPham.Name = "lblTenSanPham";
            lblTenSanPham.Size = new Size(124, 20);
            lblTenSanPham.TabIndex = 11;
            lblTenSanPham.Text = "Tên Sản Phẩm (*):";
            // 
            // lblHangSanXuat
            // 
            lblHangSanXuat.AutoSize = true;
            lblHangSanXuat.Location = new Point(16, 78);
            lblHangSanXuat.Name = "lblHangSanXuat";
            lblHangSanXuat.Size = new Size(130, 20);
            lblHangSanXuat.TabIndex = 10;
            lblHangSanXuat.Text = "Hãng Sản Xuất (*):";
            // 
            // txtTenSanPham
            // 
            txtTenSanPham.Location = new Point(165, 109);
            txtTenSanPham.Name = "txtTenSanPham";
            txtTenSanPham.Size = new Size(466, 27);
            txtTenSanPham.TabIndex = 9;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(640, 188);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(89, 29);
            btnThoat.TabIndex = 7;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // btnHuybo
            // 
            btnHuybo.Location = new Point(545, 188);
            btnHuybo.Name = "btnHuybo";
            btnHuybo.Size = new Size(89, 29);
            btnHuybo.TabIndex = 6;
            btnHuybo.Text = "Hủy bỏ";
            btnHuybo.UseVisualStyleBackColor = true;
            btnHuybo.Click += btnHuybo_Click;
            // 
            // btnLuu
            // 
            btnLuu.ForeColor = Color.Blue;
            btnLuu.Location = new Point(450, 188);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(89, 29);
            btnLuu.TabIndex = 5;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(260, 188);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(89, 29);
            btnSua.TabIndex = 3;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(165, 188);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(89, 29);
            btnThem.TabIndex = 2;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // lblPhanLoai
            // 
            lblPhanLoai.AutoSize = true;
            lblPhanLoai.Location = new Point(16, 47);
            lblPhanLoai.Name = "lblPhanLoai";
            lblPhanLoai.Size = new Size(96, 20);
            lblPhanLoai.TabIndex = 0;
            lblPhanLoai.Text = "Phân Loại (*):";
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { ID, TenLoai, TenHangSanXuat, TenSanPham, SoLuong, DonGia, HinhAnh });
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.Location = new Point(3, 23);
            dataGridView.MultiSelect = false;
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersVisible = false;
            dataGridView.RowHeadersWidth = 51;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.Size = new Size(1138, 366);
            dataGridView.TabIndex = 1;
            dataGridView.CellFormatting += dataGridView_CellFormatting;
            // 
            // ID
            // 
            ID.DataPropertyName = "ID";
            ID.FillWeight = 25.30435F;
            ID.HeaderText = "ID";
            ID.MinimumWidth = 6;
            ID.Name = "ID";
            // 
            // TenLoai
            // 
            TenLoai.DataPropertyName = "TenLoai";
            TenLoai.HeaderText = "Phân Loại";
            TenLoai.MinimumWidth = 6;
            TenLoai.Name = "TenLoai";
            // 
            // TenHangSanXuat
            // 
            TenHangSanXuat.DataPropertyName = "TenHangSanXuat";
            TenHangSanXuat.HeaderText = "Hãng sản xuất";
            TenHangSanXuat.MinimumWidth = 6;
            TenHangSanXuat.Name = "TenHangSanXuat";
            // 
            // TenSanPham
            // 
            TenSanPham.DataPropertyName = "TenSanPham";
            TenSanPham.HeaderText = "Tên sản phẩm";
            TenSanPham.MinimumWidth = 6;
            TenSanPham.Name = "TenSanPham";
            // 
            // SoLuong
            // 
            SoLuong.DataPropertyName = "SoLuong";
            SoLuong.HeaderText = "Số lượng";
            SoLuong.MinimumWidth = 6;
            SoLuong.Name = "SoLuong";
            // 
            // DonGia
            // 
            DonGia.DataPropertyName = "DonGia";
            DonGia.HeaderText = "Đơn giá";
            DonGia.MinimumWidth = 6;
            DonGia.Name = "DonGia";
            // 
            // HinhAnh
            // 
            HinhAnh.DataPropertyName = "HinhAnh";
            HinhAnh.DefaultCellStyle = dataGridViewCellStyle1;
            HinhAnh.FillWeight = 20F;
            HinhAnh.HeaderText = "Hình ảnh";
            HinhAnh.ImageLayout = DataGridViewImageCellLayout.Zoom;
            HinhAnh.MinimumWidth = 6;
            HinhAnh.Name = "HinhAnh";
            // 
            // gpbDanhSach
            // 
            gpbDanhSach.Controls.Add(dataGridView);
            gpbDanhSach.Location = new Point(7, 235);
            gpbDanhSach.Name = "gpbDanhSach";
            gpbDanhSach.Size = new Size(1144, 392);
            gpbDanhSach.TabIndex = 7;
            gpbDanhSach.TabStop = false;
            gpbDanhSach.Text = "Danh sách sản phẩm:";
            // 
            // frmSanPham
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1157, 631);
            Controls.Add(gpbThongTinSanPham);
            Controls.Add(gpbDanhSach);
            Name = "frmSanPham";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sản Phẩm";
            Load += frmSanPham_Load;
            gpbThongTinSanPham.ResumeLayout(false);
            gpbThongTinSanPham.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picHinhAnh).EndInit();
            ((System.ComponentModel.ISupportInitialize)numDonGia).EndInit();
            ((System.ComponentModel.ISupportInitialize)numSoLuong).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            gpbDanhSach.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ComboBox cboQuyenHan;
        private TextBox txtMatKhau;
        private TextBox txtTenDangNhap;
        private Label lblQuyenHan;
        private Button btnXoa;
        private GroupBox gpbThongTinSanPham;
        private ComboBox cboLoaiSanPham;
        private Label lblDonGia;
        private Label lblSoLuong;
        private Button btnXuat;
        private Button btnTimKiem;
        private Button btnNhap;
        private Label lblTenSanPham;
        private Label lblHangSanXuat;
        private TextBox txtTenSanPham;
        private Button btnThoat;
        private Button btnHuybo;
        private Button btnLuu;
        private Button btnSua;
        private Button btnThem;
        private Label lblPhanLoai;
        private DataGridViewTextBoxColumn QuyenHan;
        private DataGridViewTextBoxColumn TenDangNhap;
        private DataGridViewTextBoxColumn DiaChi;
        private DataGridViewTextBoxColumn DienThoai;
        private DataGridViewTextBoxColumn HoVaTen;
        private DataGridView dataGridView;
        private GroupBox gpbDanhSach;
        private ComboBox cboHangSanXuat;
        private NumericUpDown numSoLuong;
        private TextBox txtMoTa;
        private Label lblMoTa;
        private NumericUpDown numDonGia;
        private Button btnDoiAnh;
        private PictureBox picHinhAnh;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn TenLoai;
        private DataGridViewTextBoxColumn TenHangSanXuat;
        private DataGridViewTextBoxColumn TenSanPham;
        private DataGridViewTextBoxColumn SoLuong;
        private DataGridViewTextBoxColumn DonGia;
        private DataGridViewImageColumn HinhAnh;
    }
}