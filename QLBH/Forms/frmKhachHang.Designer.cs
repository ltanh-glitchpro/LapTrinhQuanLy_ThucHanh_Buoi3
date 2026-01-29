namespace QLBH.Forms
{
    partial class frmKhachHang
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
            gpbThongTinKhachHang = new GroupBox();
            btnXuat = new Button();
            btnTimKiem = new Button();
            btnNhap = new Button();
            lblDiaChi = new Label();
            lblSDT = new Label();
            txtDiaChi = new TextBox();
            txtSDT = new TextBox();
            btnThoat = new Button();
            btnHuybo = new Button();
            btnLuu = new Button();
            btnXoa = new Button();
            btnSua = new Button();
            btnThem = new Button();
            txtTenKH = new TextBox();
            lblTenLoaiKH = new Label();
            gpbDanhSach = new GroupBox();
            dataGridView = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            HoVaTen = new DataGridViewTextBoxColumn();
            DienThoai = new DataGridViewTextBoxColumn();
            DiaChi = new DataGridViewTextBoxColumn();
            gpbThongTinKhachHang.SuspendLayout();
            gpbDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // gpbThongTinKhachHang
            // 
            gpbThongTinKhachHang.Controls.Add(btnXuat);
            gpbThongTinKhachHang.Controls.Add(btnTimKiem);
            gpbThongTinKhachHang.Controls.Add(btnNhap);
            gpbThongTinKhachHang.Controls.Add(lblDiaChi);
            gpbThongTinKhachHang.Controls.Add(lblSDT);
            gpbThongTinKhachHang.Controls.Add(txtDiaChi);
            gpbThongTinKhachHang.Controls.Add(txtSDT);
            gpbThongTinKhachHang.Controls.Add(btnThoat);
            gpbThongTinKhachHang.Controls.Add(btnHuybo);
            gpbThongTinKhachHang.Controls.Add(btnLuu);
            gpbThongTinKhachHang.Controls.Add(btnXoa);
            gpbThongTinKhachHang.Controls.Add(btnSua);
            gpbThongTinKhachHang.Controls.Add(btnThem);
            gpbThongTinKhachHang.Controls.Add(txtTenKH);
            gpbThongTinKhachHang.Controls.Add(lblTenLoaiKH);
            gpbThongTinKhachHang.Location = new Point(12, 12);
            gpbThongTinKhachHang.Name = "gpbThongTinKhachHang";
            gpbThongTinKhachHang.Size = new Size(872, 126);
            gpbThongTinKhachHang.TabIndex = 2;
            gpbThongTinKhachHang.TabStop = false;
            gpbThongTinKhachHang.Text = "Thông tin khách hàng";
            // 
            // btnXuat
            // 
            btnXuat.ForeColor = Color.Black;
            btnXuat.Location = new Point(766, 87);
            btnXuat.Name = "btnXuat";
            btnXuat.Size = new Size(94, 29);
            btnXuat.TabIndex = 6;
            btnXuat.Text = "Xuất...";
            btnXuat.UseVisualStyleBackColor = true;
            btnXuat.Click += btnXuat_Click;
            // 
            // btnTimKiem
            // 
            btnTimKiem.ForeColor = Color.Black;
            btnTimKiem.Location = new Point(766, 19);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(94, 29);
            btnTimKiem.TabIndex = 7;
            btnTimKiem.Text = "Tìm Kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // btnNhap
            // 
            btnNhap.ForeColor = Color.Black;
            btnNhap.Location = new Point(766, 53);
            btnNhap.Name = "btnNhap";
            btnNhap.Size = new Size(94, 29);
            btnNhap.TabIndex = 12;
            btnNhap.Text = "Nhập...";
            btnNhap.UseVisualStyleBackColor = true;
            btnNhap.Click += btnNhap_Click;
            // 
            // lblDiaChi
            // 
            lblDiaChi.AutoSize = true;
            lblDiaChi.Location = new Point(28, 91);
            lblDiaChi.Name = "lblDiaChi";
            lblDiaChi.Size = new Size(78, 20);
            lblDiaChi.TabIndex = 11;
            lblDiaChi.Text = "Địa chỉ (*):";
            // 
            // lblSDT
            // 
            lblSDT.AutoSize = true;
            lblSDT.Location = new Point(28, 61);
            lblSDT.Name = "lblSDT";
            lblSDT.Size = new Size(120, 20);
            lblSDT.TabIndex = 10;
            lblSDT.Text = "Số điện thoại (*):";
            // 
            // txtDiaChi
            // 
            txtDiaChi.Location = new Point(168, 84);
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new Size(271, 27);
            txtDiaChi.TabIndex = 9;
            // 
            // txtSDT
            // 
            txtSDT.Location = new Point(168, 54);
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(271, 27);
            txtSDT.TabIndex = 8;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(664, 87);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(94, 29);
            btnThoat.TabIndex = 7;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // btnHuybo
            // 
            btnHuybo.Location = new Point(564, 87);
            btnHuybo.Name = "btnHuybo";
            btnHuybo.Size = new Size(94, 29);
            btnHuybo.TabIndex = 6;
            btnHuybo.Text = "Hủy bỏ";
            btnHuybo.UseVisualStyleBackColor = true;
            btnHuybo.Click += btnHuybo_Click;
            // 
            // btnLuu
            // 
            btnLuu.ForeColor = Color.Blue;
            btnLuu.Location = new Point(664, 53);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(94, 29);
            btnLuu.TabIndex = 5;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnXoa
            // 
            btnXoa.ForeColor = Color.Red;
            btnXoa.Location = new Point(464, 87);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(94, 29);
            btnXoa.TabIndex = 4;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(564, 53);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(94, 29);
            btnSua.TabIndex = 3;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(464, 53);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(94, 29);
            btnThem.TabIndex = 2;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // txtTenKH
            // 
            txtTenKH.Location = new Point(168, 20);
            txtTenKH.Name = "txtTenKH";
            txtTenKH.Size = new Size(584, 27);
            txtTenKH.TabIndex = 1;
            // 
            // lblTenLoaiKH
            // 
            lblTenLoaiKH.AutoSize = true;
            lblTenLoaiKH.Location = new Point(28, 27);
            lblTenLoaiKH.Name = "lblTenLoaiKH";
            lblTenLoaiKH.Size = new Size(134, 20);
            lblTenLoaiKH.TabIndex = 0;
            lblTenLoaiKH.Text = "Tên khách hàng (*):";
            // 
            // gpbDanhSach
            // 
            gpbDanhSach.Controls.Add(dataGridView);
            gpbDanhSach.Location = new Point(12, 144);
            gpbDanhSach.Name = "gpbDanhSach";
            gpbDanhSach.Size = new Size(872, 373);
            gpbDanhSach.TabIndex = 3;
            gpbDanhSach.TabStop = false;
            gpbDanhSach.Text = "Danh sách khách hàng:";
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { ID, HoVaTen, DienThoai, DiaChi });
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.Location = new Point(3, 23);
            dataGridView.MultiSelect = false;
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersVisible = false;
            dataGridView.RowHeadersWidth = 51;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.Size = new Size(866, 347);
            dataGridView.TabIndex = 1;
            // 
            // ID
            // 
            ID.DataPropertyName = "ID";
            ID.FillWeight = 24.1228065F;
            ID.HeaderText = "ID";
            ID.MinimumWidth = 6;
            ID.Name = "ID";
            // 
            // HoVaTen
            // 
            HoVaTen.DataPropertyName = "HoVaTen";
            HoVaTen.FillWeight = 118.5598F;
            HoVaTen.HeaderText = "Tên Khách Hàng";
            HoVaTen.MinimumWidth = 6;
            HoVaTen.Name = "HoVaTen";
            // 
            // DienThoai
            // 
            DienThoai.DataPropertyName = "DienThoai";
            DienThoai.FillWeight = 106.951874F;
            DienThoai.HeaderText = "Điện Thoại";
            DienThoai.MinimumWidth = 6;
            DienThoai.Name = "DienThoai";
            // 
            // DiaChi
            // 
            DiaChi.DataPropertyName = "DiaChi";
            DiaChi.FillWeight = 150.365509F;
            DiaChi.HeaderText = "Địa Chỉ";
            DiaChi.MinimumWidth = 6;
            DiaChi.Name = "DiaChi";
            // 
            // frmKhachHang
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(896, 529);
            Controls.Add(gpbThongTinKhachHang);
            Controls.Add(gpbDanhSach);
            Name = "frmKhachHang";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Khách hàng";
            Load += frmKhachHang_Load;
            gpbThongTinKhachHang.ResumeLayout(false);
            gpbThongTinKhachHang.PerformLayout();
            gpbDanhSach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gpbThongTinKhachHang;
        private Button btnThoat;
        private Button btnHuybo;
        private Button btnLuu;
        private Button btnXoa;
        private Button btnSua;
        private Button btnThem;
        private TextBox txtTenKH;
        private Label lblTenLoaiKH;
        private GroupBox gpbDanhSach;
        private Label lblDiaChi;
        private Label lblSDT;
        private TextBox txtDiaChi;
        private TextBox txtSDT;
        private DataGridView dataGridView;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn HoVaTen;
        private DataGridViewTextBoxColumn DienThoai;
        private DataGridViewTextBoxColumn DiaChi;
        private Button btnXuat;
        private Button btnTimKiem;
        private Button btnNhap;
    }
}