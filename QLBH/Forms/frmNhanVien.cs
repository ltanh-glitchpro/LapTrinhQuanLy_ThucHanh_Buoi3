using QLBH.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BC = BCrypt.Net.BCrypt; // Thư viện mã hóa mật khẩu BCrypt
using System.IO;
namespace QLBH.Forms
{
    public partial class frmNhanVien : Form
    {
        QLBHDbContext context = new QLBHDbContext(); // Khởi tạo biến ngữ cảnh CSDL 
        bool xuLyThem = false; // Kiểm tra có nhấn vào nút Thêm hay không? 
        int id; // Lấy mã nhân viên (dùng cho Sửa và Xóa)

        // BindingSource dùng chung để đồng bộ dữ liệu giữa Grid và các TextBox
        private readonly BindingSource bindingSource = new BindingSource();
        public frmNhanVien()
        {
            InitializeComponent();
        }
        private void BatTatChucNang(bool giaTri)
        {
            btnLuu.Enabled = giaTri;
            btnHuybo.Enabled = giaTri;
            txtHoVaTen.Enabled = giaTri;
            txtDienThoai.Enabled = giaTri;
            txtDiaChi.Enabled = giaTri;
            txtTenDangNhap.Enabled = giaTri;
            txtMatKhau.Enabled = giaTri;
            cboQuyenHan.Enabled = giaTri;

            btnThem.Enabled = !giaTri;
            btnSua.Enabled = !giaTri;
            btnXoa.Enabled = !giaTri;
            btnTimKiem.Enabled = !giaTri;
            btnNhap.Enabled = !giaTri;
            btnXuat.Enabled = !giaTri;
        }
        private void LoadData(IEnumerable<NhanVien> items)
        {
            bindingSource.DataSource = items.ToList();

            txtHoVaTen.DataBindings.Clear();
            txtHoVaTen.DataBindings.Add("Text", bindingSource, "HoVaTen", false, DataSourceUpdateMode.Never, string.Empty);

            txtDienThoai.DataBindings.Clear();
            txtDienThoai.DataBindings.Add("Text", bindingSource, "DienThoai", false, DataSourceUpdateMode.Never, string.Empty);

            txtDiaChi.DataBindings.Clear();
            txtDiaChi.DataBindings.Add("Text", bindingSource, "DiaChi", false, DataSourceUpdateMode.Never, string.Empty);

            // Bổ sung binding cho các trường còn lại của Nhân viên
            txtTenDangNhap.DataBindings.Clear();
            txtTenDangNhap.DataBindings.Add("Text", bindingSource, "TenDangNhap", false, DataSourceUpdateMode.Never, string.Empty);

            cboQuyenHan.DataBindings.Clear();
            cboQuyenHan.DataBindings.Add("SelectedIndex", bindingSource, "QuyenHan", false, DataSourceUpdateMode.Never, 0);

            dataGridView.DataSource = bindingSource;
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            BatTatChucNang(false);
            dataGridView.AutoGenerateColumns = false;

            List<NhanVien> nv = new List<NhanVien>();
            nv = context.NhanVien.ToList();

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = nv;

            txtHoVaTen.DataBindings.Clear();
            txtHoVaTen.DataBindings.Add("Text", bindingSource, "HoVaTen", false, DataSourceUpdateMode.Never);

            // Tương tự đối với txtDienThoai, txtDiaChi, txtTenDangNhap 

            cboQuyenHan.DataBindings.Clear();
            cboQuyenHan.DataBindings.Add("SelectedIndex", bindingSource, "QuyenHan", false, DataSourceUpdateMode.Never);

            dataGridView.DataSource = bindingSource;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            xuLyThem = true;
            BatTatChucNang(true);
            txtHoVaTen.Clear();
            txtDienThoai.Clear();
            txtDiaChi.Clear();
            txtTenDangNhap.Clear();
            txtMatKhau.Clear();
            cboQuyenHan.Text = "";
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            xuLyThem = false;
            BatTatChucNang(true);
            id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHoVaTen.Text))
                MessageBox.Show("Vui lòng nhập họ và tên nhân viên?", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text))
                MessageBox.Show("Vui lòng nhập tên đăng nhập?", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (string.IsNullOrWhiteSpace(cboQuyenHan.Text))
                MessageBox.Show("Vui lòng chọn quyền hạn cho nhân viên?", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (xuLyThem)
                {
                    if (string.IsNullOrWhiteSpace(txtMatKhau.Text))
                        MessageBox.Show("Vui lòng nhập mật khẩu?", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        NhanVien nv = new NhanVien();
                        nv.HoVaTen = txtHoVaTen.Text;
                        nv.DienThoai = txtDienThoai.Text;
                        nv.DiaChi = txtDiaChi.Text;
                        nv.TenDangNhap = txtTenDangNhap.Text;
                        nv.MatKhau = BC.HashPassword(txtMatKhau.Text); // Mã hóa mật khẩu 
                        nv.QuyenHan = cboQuyenHan.SelectedIndex == 0 ? true : false;
                        context.NhanVien.Add(nv);

                        context.SaveChanges();
                    }
                }
                else
                {
                    NhanVien nv = context.NhanVien.Find(id);
                    if (nv != null)
                    {
                        nv.HoVaTen = txtHoVaTen.Text;
                        nv.DienThoai = txtDienThoai.Text;
                        nv.DiaChi = txtDiaChi.Text;
                        nv.TenDangNhap = txtTenDangNhap.Text;
                        nv.QuyenHan = cboQuyenHan.SelectedIndex == 0 ? true : false;
                        context.NhanVien.Update(nv);

                        if (string.IsNullOrEmpty(txtMatKhau.Text))
                            context.Entry(nv).Property(x => x.MatKhau).IsModified = false; // Giữ nguyên mật khẩu cũ 
                        else
                            nv.MatKhau = BC.HashPassword(txtMatKhau.Text); // Cập nhật mật khẩu mới 

                        context.SaveChanges();
                    }
                }

                frmNhanVien_Load(sender, e);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận xóa nhân viên " + txtHoVaTen.Text + "?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value.ToString());
                NhanVien nv = context.NhanVien.Find(id);
                if (nv != null)
                {
                    context.NhanVien.Remove(nv);
                }
                context.SaveChanges();

                frmNhanVien_Load(sender, e);
            }
        }

        private void btnHuybo_Click(object sender, EventArgs e)
        {
            frmNhanVien_Load(sender, e);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            // Hiển thị hộp thoại nhập từ khóa
            string searchTerm = Microsoft.VisualBasic.Interaction.InputBox("Nhập từ khóa tìm kiếm (họ tên, điện thoại, địa chỉ):", "Tìm kiếm nhân viên", "");

            if (string.IsNullOrEmpty(searchTerm))
            {
                // Nếu trống thì hiện lại toàn bộ danh sách
                LoadData(context.NhanVien.ToList());
                BatTatChucNang(false);
                return;
            }

            string lower = searchTerm.ToLower();

            // Truy vấn LINQ tìm kiếm gần đúng (có xử lý null cho dữ liệu trong DB)
            var results = context.NhanVien
                .Where(k =>
                    ((k.HoVaTen ?? "").ToLower().Contains(lower)) ||
                    ((k.DienThoai ?? "").ToLower().Contains(lower)) ||
                    ((k.DiaChi ?? "").ToLower().Contains(lower)))
                .ToList();

            if (results.Count == 0)
            {
                MessageBox.Show("Không tìm thấy kết quả phù hợp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData(context.NhanVien.ToList());
            }
            else
            {
                LoadData(results); // Hiển thị kết quả tìm được
            }

            BatTatChucNang(false);
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            // 1. Cấu hình hộp thoại chọn file
            using OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*",
                Title = "Chọn file CSV chứa danh sách nhân viên",
                Multiselect = false
            };

            if (ofd.ShowDialog() != DialogResult.OK) return;

            string path = ofd.FileName;
            List<string> lines;
            try
            {
                // Đọc file với Encoding UTF8 để giữ được tiếng Việt
                lines = File.ReadAllLines(path, Encoding.UTF8).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể đọc file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (lines.Count == 0) return;

            // 2. Hàm hỗ trợ tách dòng CSV (giữ nguyên logic xử lý dấu nháy kép của bạn)
            static List<string> ParseCsvLine(string line)
            {
                var result = new List<string>();
                var cur = new StringBuilder();
                bool inQuotes = false;
                for (int i = 0; i < line.Length; i++)
                {
                    char c = line[i];
                    if (inQuotes)
                    {
                        if (c == '"')
                        {
                            if (i + 1 < line.Length && line[i + 1] == '"') { cur.Append('"'); i++; }
                            else inQuotes = false;
                        }
                        else cur.Append(c);
                    }
                    else
                    {
                        if (c == '"') inQuotes = true;
                        else if (c == ',') { result.Add(cur.ToString()); cur.Clear(); }
                        else cur.Append(c);
                    }
                }
                result.Add(cur.ToString());
                return result;
            }

            // 3. Kiểm tra Header
            var headerFields = ParseCsvLine(lines[0]);
            bool hasHeader = headerFields.Any(h => h.Trim().ToLower().Contains("ten") || h.Trim().ToLower().Contains("ho"));
            int startLine = hasHeader ? 1 : 0;

            int added = 0, skipped = 0;
            string defaultPassword = BC.HashPassword("123456"); // Mật khẩu mặc định cho NV mới

            for (int i = startLine; i < lines.Count; i++)
            {
                var fields = ParseCsvLine(lines[i]);
                if (fields.Count < 1) { skipped++; continue; }

                string ten = "", sdt = "", diachi = "";

                if (hasHeader)
                {
                    for (int c = 0; c < headerFields.Count && c < fields.Count; c++)
                    {
                        string col = headerFields[c].Trim().ToLower();
                        string val = fields[c].Trim();
                        if (col.Contains("ten") || col.Contains("ho")) ten = val;
                        else if (col.Contains("sdt") || col.Contains("dien")) sdt = val;
                        else if (col.Contains("diachi") || col.Contains("dia chi")) diachi = val;
                    }
                }
                else
                {
                    ten = fields[0].Trim();
                    sdt = fields.Count > 1 ? fields[1].Trim() : "";
                    diachi = fields.Count > 2 ? fields[2].Trim() : "";
                }

                if (string.IsNullOrWhiteSpace(ten)) { skipped++; continue; }

                try
                {
                    // TẠO NHÂN VIÊN: Cần bổ sung các trường bắt buộc (Required) trong DB
                    NhanVien nv = new NhanVien
                    {
                        HoVaTen = ten,
                        DienThoai = sdt,
                        DiaChi = diachi,
                        // Quan trọng: Phải có tên đăng nhập và mật khẩu thì mới SaveChanges được
                        TenDangNhap = !string.IsNullOrEmpty(sdt) ? sdt : "nv_" + Guid.NewGuid().ToString().Substring(0, 5),
                        MatKhau = defaultPassword,
                        QuyenHan = false // Mặc định là nhân viên thường
                    };
                    context.NhanVien.Add(nv);
                    added++;
                }
                catch { skipped++; }
            }

            // 4. Lưu vào CSDL
            try
            {
                context.SaveChanges();
                LoadData(context.NhanVien.ToList()); // Cập nhật lại Grid
                MessageBox.Show($"Thành công! Đã thêm: {added}, Bỏ qua: {skipped}.\nLưu ý: Tên đăng nhập mặc định là SĐT, mật khẩu là '123456'.",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu dữ liệu: " + ex.InnerException?.Message ?? ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra xem có dữ liệu để xuất không
            if (dataGridView.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Cấu hình hộp thoại lưu file
            using SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "CSV files (*.csv)|*.csv",
                FileName = "DanhSachNhanVien.csv",
                Title = "Chọn nơi lưu file CSV"
            };

            if (sfd.ShowDialog() != DialogResult.OK) return;

            try
            {
                StringBuilder sb = new StringBuilder();

                // 3. Tạo dòng tiêu đề (Header)
                // Bạn có thể tùy chỉnh các cột muốn xuất ở đây
                sb.AppendLine("ID,HoVaTen,DienThoai,DiaChi,TenDangNhap,QuyenHan");

                // 4. Duyệt qua danh sách dữ liệu trong BindingSource (đã ép kiểu về NhanVien)
                var danhSach = (List<NhanVien>)bindingSource.DataSource;

                foreach (var nv in danhSach)
                {
                    // Xử lý dữ liệu để tránh lỗi định dạng CSV (nếu địa chỉ có dấu phẩy thì bọc trong dấu nháy kép)
                    string hoTen = $"\"{nv.HoVaTen}\"";
                    string dienThoai = $"\"{nv.DienThoai}\"";
                    string diaChi = $"\"{nv.DiaChi}\"";
                    string tenDN = $"\"{nv.TenDangNhap}\"";
                    string quyen = nv.QuyenHan ? "Quản lí" : "Nhân viên";

                    // Nối thành một dòng CSV
                    sb.AppendLine($"{nv.ID},{hoTen},{dienThoai},{diaChi},{tenDN},{quyen}");
                }

                // 5. Ghi dữ liệu ra file với encoding UTF-8 (để hiển thị đúng tiếng Việt)
                File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);

                MessageBox.Show("Xuất dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
