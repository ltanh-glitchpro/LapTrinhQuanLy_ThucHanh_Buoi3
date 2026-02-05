using QLBH;
using QLBH.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace QLBH.Forms
{
    public partial class frmSanPham : Form
    {
        QLBHDbContext context = new QLBHDbContext();    // Khởi tạo biến ngữ cảnh CSDL 
        bool xuLyThem = false;                          // Kiểm tra có nhấn vào nút Thêm hay không? 
        int id;                                         // Lấy mã sản phẩm (dùng cho Sửa và Xóa) 
        string imagesFolder = Application.StartupPath.Replace("bin\\Debug\\net8.0-windows\\Images", "Images");
        public frmSanPham()
        {
            InitializeComponent();
        }

        private void BatTatChucNang(bool giaTri)
        {
            btnLuu.Enabled = giaTri;
            btnHuybo.Enabled = giaTri;
            cboHangSanXuat.Enabled = giaTri;
            cboLoaiSanPham.Enabled = giaTri;
            txtTenSanPham.Enabled = giaTri;
            numSoLuong.Enabled = giaTri;
            numDonGia.Enabled = giaTri;
            txtMoTa.Enabled = giaTri;
            picHinhAnh.Enabled = giaTri;

            btnThem.Enabled = !giaTri;
            btnDoiAnh.Enabled = !giaTri;
            btnSua.Enabled = !giaTri;
            btnXoa.Enabled = !giaTri;
            btnTimKiem.Enabled = !giaTri;
            btnNhap.Enabled = !giaTri;
            btnXuat.Enabled = !giaTri;
        }

        public void LayLoaiSanPhamVaoComboBox()
        {
            cboLoaiSanPham.DataSource = context.LoaiSanPham.ToList();
            cboLoaiSanPham.ValueMember = "ID";
            cboLoaiSanPham.DisplayMember = "TenLoai";
        }

        public void LayHangSanXuatVaoComboBox()
        {
            cboHangSanXuat.DataSource = context.HangSanXuat.ToList();
            cboHangSanXuat.ValueMember = "ID";
            cboHangSanXuat.DisplayMember = "TenHangSanXuat";
        }

        private void frmSanPham_Load(object sender, EventArgs e)
        {
            BatTatChucNang(false);
            LayLoaiSanPhamVaoComboBox();
            LayHangSanXuatVaoComboBox();
            picThem.Enabled = false;
            picXoa.Enabled = false;
            picXoay.Enabled = false;

            dataGridView.AutoGenerateColumns = false;

            List<DanhSachSanPham> sp = new List<DanhSachSanPham>();
            sp = context.SanPham.Select(r => new DanhSachSanPham
            {
                ID = r.ID,
                LoaiSanPhamID = r.LoaiSanPhamID,
                TenLoai = r.LoaiSanPham.TenLoai,
                HangSanXuatID = r.HangSanXuatID,
                TenHangSanXuat = r.HangSanXuat.TenHangSanXuat,
                TenSanPham = r.TenSanPham,
                SoLuong = r.SoLuong,
                DonGia = r.DonGia,
                HinhAnh = r.HinhAnh
            }).ToList();

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = sp;

            cboLoaiSanPham.DataBindings.Clear();
            cboLoaiSanPham.DataBindings.Add("SelectedValue", bindingSource, "LoaiSanPhamID", false, DataSourceUpdateMode.Never);

            // Tương tự đối với cboHangSanXuat
            cboHangSanXuat.DataBindings.Clear();
            cboHangSanXuat.DataBindings.Add(
                "SelectedValue",
                bindingSource,
                "HangSanXuatID",
                false,
                DataSourceUpdateMode.Never
            );


            txtTenSanPham.DataBindings.Clear();
            txtTenSanPham.DataBindings.Add("Text", bindingSource, "TenSanPham", false, DataSourceUpdateMode.Never);

            // Tương tự đối với txtMoTa 
            txtMoTa.DataBindings.Clear();
            txtMoTa.DataBindings.Add(
                "Text",
                bindingSource,
                "MoTa",
                false,
                DataSourceUpdateMode.Never
            );


            numSoLuong.DataBindings.Clear();
            numSoLuong.DataBindings.Add("Value", bindingSource, "SoLuong", false, DataSourceUpdateMode.Never);

            // Tương tự đối với numDonGia 
            numDonGia.DataBindings.Clear();
            numDonGia.DataBindings.Add(
                "Value",
                bindingSource,
                "DonGia",
                false,
                DataSourceUpdateMode.Never
            );

            picHinhAnh.DataBindings.Clear();
            Binding hinhAnh = new Binding("ImageLocation", bindingSource, "HinhAnh");
            hinhAnh.Format += (s, e) =>
            {
                e.Value = Path.Combine(imagesFolder, e.Value.ToString());
            };
            picHinhAnh.DataBindings.Add(hinhAnh);
            dataGridView.DataSource = bindingSource;
            dataGridView.Columns["ID"].Width = 50;
            dataGridView.Columns["TenLoai"].Width = 120;
            dataGridView.Columns["TenHangSanXuat"].Width = 140;
            dataGridView.Columns["TenSanPham"].Width = 200;
            dataGridView.Columns["SoLuong"].Width = 80;
            dataGridView.Columns["DonGia"].Width = 120;
            dataGridView.Columns["HinhAnh"].Width = 100;

        }

        private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView.Columns[e.ColumnIndex].Name == "HinhAnh")
            {
                if (e.Value == null) return;

                string fileName = e.Value.ToString();
                if (string.IsNullOrWhiteSpace(fileName)) return;

                string fullPath = Path.Combine(imagesFolder, fileName);
                if (!File.Exists(fullPath)) return;

                using (Image img = Image.FromFile(fullPath))
                {
                    e.Value = new Bitmap(img, 50, 50);
                }

                e.FormattingApplied = true; // ⭐ BẮT BUỘC
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            xuLyThem = true;
            BatTatChucNang(true);
            cboLoaiSanPham.Text = "";
            cboHangSanXuat.Text = "";
            txtTenSanPham.Clear();
            txtMoTa.Clear();
            numSoLuong.Value = 0;
            numDonGia.Value = 0;
            picHinhAnh.Image = null;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null)
                return;

            xuLyThem = false;
            BatTatChucNang(true);

            id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cboLoaiSanPham.Text))
                MessageBox.Show("Vui lòng chọn loại sản phẩm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (string.IsNullOrWhiteSpace(cboHangSanXuat.Text))
                MessageBox.Show("Vui lòng chọn hãng sản xuất.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (string.IsNullOrWhiteSpace(txtTenSanPham.Text))
                MessageBox.Show("Vui lòng nhập tên sản phẩm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (numSoLuong.Value <= 0)
                MessageBox.Show("Số lượng phải lớn hơn 0.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (numDonGia.Value <= 0)
                MessageBox.Show("Đơn giá sản phẩm phải lớn hơn 0.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (xuLyThem)
                {
                    int loaiId = cboLoaiSanPham.SelectedValue != null ? Convert.ToInt32(cboLoaiSanPham.SelectedValue) : 0;
                    int hangId = cboHangSanXuat.SelectedValue != null ? Convert.ToInt32(cboHangSanXuat.SelectedValue) : 0;

                    SanPham sp = new SanPham
                    {
                        LoaiSanPhamID = loaiId,
                        HangSanXuatID = hangId,
                        TenSanPham = txtTenSanPham.Text,
                        MoTa = txtMoTa.Text,
                        SoLuong = (int)numSoLuong.Value,
                        DonGia = (int)numDonGia.Value,
                        HinhAnh = !string.IsNullOrWhiteSpace(picHinhAnh?.ImageLocation)
                                    ? Path.GetFileName(picHinhAnh.ImageLocation)
                                    : null
                    };

                    context.SanPham.Add(sp);
                    context.SaveChanges();
                }

                else
                {
                    SanPham sp = context.SanPham.Find(id);
                    if (sp != null)
                    {
                        if (cboLoaiSanPham.SelectedValue != null)
                            sp.LoaiSanPhamID = Convert.ToInt32(cboLoaiSanPham.SelectedValue);

                        if (cboHangSanXuat.SelectedValue != null)
                            sp.HangSanXuatID = Convert.ToInt32(cboHangSanXuat.SelectedValue);

                        sp.TenSanPham = txtTenSanPham.Text;
                        sp.MoTa = txtMoTa.Text;
                        sp.SoLuong = (int)numSoLuong.Value;
                        sp.DonGia = (int)numDonGia.Value;

                        if (!string.IsNullOrWhiteSpace(picHinhAnh?.ImageLocation))
                            sp.HinhAnh = Path.GetFileName(picHinhAnh.ImageLocation);

                        context.SanPham.Update(sp);
                        context.SaveChanges();
                    }
                }

                frmSanPham_Load(sender, e);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận xóa sản phẩm " + txtTenSanPham.Text + "?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
                SanPham sp = context.SanPham.Find(id);
                if (sp != null)
                {
                    context.SanPham.Remove(sp);
                }
                context.SaveChanges();

                frmSanPham_Load(sender, e);
            }
        }

        private void btnHuybo_Click(object sender, EventArgs e)
        {
            frmSanPham_Load(sender, e);
        }


        private string GenerateSlug(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return "";

            input = input.ToLower();
            input = System.Text.RegularExpressions.Regex.Replace(input, @"\s+", "-");
            input = System.Text.RegularExpressions.Regex.Replace(input, @"[^a-z0-9\-]", "");
            input = System.Text.RegularExpressions.Regex.Replace(input, @"-+", "-");

            return input.Trim('-');
        }

        private void btnDoiAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Cập nhật hình ảnh sản phẩm";
            openFileDialog.Filter = "Tập tin hình ảnh|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = Path.GetFileNameWithoutExtension(openFileDialog.FileName);
                string ext = Path.GetExtension(openFileDialog.FileName);

                // ✅ dùng hàm thường, KHÔNG dùng extension
                string newFileName = GenerateSlug(fileName) + ext;
                string fileSavePath = Path.Combine(imagesFolder, newFileName);

                File.Copy(openFileDialog.FileName, fileSavePath, true);

                id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value);
                SanPham sp = context.SanPham.Find(id);

                if (sp != null)
                {
                    sp.HinhAnh = newFileName;
                    context.SanPham.Update(sp);
                    context.SaveChanges();
                }

                frmSanPham_Load(sender, e);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
