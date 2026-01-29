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

namespace QLBH.Forms
{
    public partial class frmKhachHang : Form
    {
        // Khởi tạo ngữ cảnh cơ sở dữ liệu (Entity Framework)
        QLBHDbContext context = new QLBHDbContext();

        // Biến đánh dấu: true là đang thêm mới, false là đang chỉnh sửa
        bool xuLyThem = false;

        // Lưu trữ ID của khách hàng đang được chọn
        int id;

        // BindingSource dùng chung để đồng bộ dữ liệu giữa Grid và các TextBox
        private readonly BindingSource bindingSource = new BindingSource();

        public frmKhachHang()
        {
            InitializeComponent();
        }
        private void BatTatChucNang(bool giaTri)
        {
            btnLuu.Enabled = giaTri;
            btnHuybo.Enabled = giaTri;
            txtTenKH.Enabled = giaTri;
            txtSDT.Enabled = giaTri;
            txtDiaChi.Enabled = giaTri;

            // Các nút chức năng chính sẽ ngược lại với trạng thái nhập liệu
            btnThem.Enabled = !giaTri;
            btnSua.Enabled = !giaTri;
            btnXoa.Enabled = !giaTri;
        }

        private void LoadData(IEnumerable<KhachHang> items)
        {
            bindingSource.DataSource = items.ToList();

            // Xóa bỏ các liên kết cũ trước khi gán mới để tránh lỗi trùng lặp
            txtTenKH.DataBindings.Clear();
            txtTenKH.DataBindings.Add("Text", bindingSource, "HoVaTen", false, DataSourceUpdateMode.Never, string.Empty);

            txtSDT.DataBindings.Clear();
            txtSDT.DataBindings.Add("Text", bindingSource, "DienThoai", false, DataSourceUpdateMode.Never, string.Empty);

            txtDiaChi.DataBindings.Clear();
            txtDiaChi.DataBindings.Add("Text", bindingSource, "DiaChi", false, DataSourceUpdateMode.Never, string.Empty);

            // Cập nhật nguồn dữ liệu cho bảng hiển thị
            dataGridView.DataSource = bindingSource;
        }

        // Sự kiện khi Form được tải lên lần đầu
        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            BatTatChucNang(false); // Khóa các ô nhập liệu

            // Lấy toàn bộ danh sách khách hàng từ DB và hiển thị
            var all = context.KhachHang.ToList();
            LoadData(all);
        }

        // Sự kiện khi nhấn nút Thêm
        private void btnThem_Click(object sender, EventArgs e)
        {
            xuLyThem = true; // Đặt trạng thái là Thêm mới
            BatTatChucNang(true); // Mở các ô nhập liệu

            // Xóa sạch nội dung cũ trong các ô nhập
            txtTenKH.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();
            txtTenKH.Focus(); // Đưa con trỏ vào ô tên
        }

        // Sự kiện khi nhấn nút Sửa
        private void btnSua_Click(object sender, EventArgs e)
        {
            xuLyThem = false; // Đặt trạng thái là Chỉnh sửa

            // Kiểm tra xem người dùng đã chọn dòng nào trên bảng chưa
            DataGridViewRow? currentRow = dataGridView.CurrentRow;
            object? cellValue = currentRow?.Cells["ID"]?.Value;

            // Kiểm tra giá trị ID có hợp lệ không
            if (cellValue == null || !int.TryParse(cellValue.ToString(), out id))
            {
                MessageBox.Show("Vui lòng chọn một khách hàng hợp lệ để sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            BatTatChucNang(true); // Mở các ô để sửa thông tin
        }

        // Sự kiện khi nhấn nút Lưu (Dùng cho cả Thêm và Sửa)
        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Kiểm tra ràng buộc dữ liệu không được để trống
            if (string.IsNullOrWhiteSpace(txtTenKH.Text) || string.IsNullOrWhiteSpace(txtSDT.Text) || string.IsNullOrWhiteSpace(txtDiaChi.Text))
            {
                MessageBox.Show("Thông tin bạn nhập còn thiếu\nVui lòng nhập đầy đủ thông tin.");
            }
            else
            {
                if (xuLyThem) // Trường hợp THÊM MỚI
                {
                    KhachHang kh = new KhachHang
                    {
                        HoVaTen = txtTenKH.Text,
                        DienThoai = txtSDT.Text,
                        DiaChi = txtDiaChi.Text
                    };
                    context.KhachHang.Add(kh);
                }
                else // Trường hợp CHỈNH SỬA
                {
                    KhachHang? kh = context.KhachHang.Find(id);
                    if (kh != null)
                    {
                        kh.HoVaTen = txtTenKH.Text;
                        kh.DienThoai = txtSDT.Text;
                        kh.DiaChi = txtDiaChi.Text;
                        context.KhachHang.Update(kh);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy khách hàng để cập nhật.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                context.SaveChanges(); // Lưu thay đổi xuống Database
                frmKhachHang_Load(sender, e); // Tải lại dữ liệu lên giao diện
            }
        }

        // Sự kiện khi nhấn nút Xóa
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận xóa khách hàng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DataGridViewRow? currentRow = dataGridView.CurrentRow;
                object? cellValue = currentRow?.Cells["ID"]?.Value;

                if (cellValue == null || !int.TryParse(cellValue.ToString(), out id))
                {
                    MessageBox.Show("Vui lòng chọn khách hàng cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                KhachHang? kh = context.KhachHang.Find(id);
                if (kh != null)
                {
                    context.KhachHang.Remove(kh);
                    context.SaveChanges();
                }

                frmKhachHang_Load(sender, e); // Refresh lại danh sách
            }
        }

        // Sự kiện khi nhấn nút Hủy bỏ
        private void btnHuybo_Click(object sender, EventArgs e)
        {
            frmKhachHang_Load(sender, e); // Quay lại trạng thái ban đầu
        }

        // Thoát form
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Chức năng tìm kiếm khách hàng
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            // Hiển thị hộp thoại nhập từ khóa
            string searchTerm = Microsoft.VisualBasic.Interaction.InputBox("Nhập tên, SĐT hoặc địa chỉ:", "Tìm kiếm", "").Trim();

            if (string.IsNullOrEmpty(searchTerm))
            {
                // Nếu trống thì hiện lại toàn bộ danh sách
                LoadData(context.KhachHang.ToList());
                BatTatChucNang(false);
                return;
            }

            string lower = searchTerm.ToLower();

            // Truy vấn LINQ tìm kiếm gần đúng (có xử lý null cho dữ liệu trong DB)
            var results = context.KhachHang
                .Where(k =>
                    ((k.HoVaTen ?? "").ToLower().Contains(lower)) ||
                    ((k.DienThoai ?? "").ToLower().Contains(lower)) ||
                    ((k.DiaChi ?? "").ToLower().Contains(lower)))
                .ToList();

            if (results.Count == 0)
            {
                MessageBox.Show("Không tìm thấy kết quả phù hợp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData(context.KhachHang.ToList());
            }
            else
            {
                LoadData(results); // Hiển thị kết quả tìm được
            }

            BatTatChucNang(false);
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            // Hỏi chọn file CSV
            using OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*",
                Title = "Chọn file CSV để nhập",
                Multiselect = false
            };

            if (ofd.ShowDialog() != DialogResult.OK)
            {
                return; // Người dùng hủy
            }

            string path = ofd.FileName;
            List<string> lines;
            try
            {
                // Đọc tất cả dòng với encoding UTF8 (hỗ trợ tiếng Việt)
                lines = File.ReadAllLines(path, Encoding.UTF8).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể đọc file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (lines.Count == 0)
            {
                MessageBox.Show("File rỗng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Hàm tách dòng CSV (hỗ trợ dấu nháy kép)
            static List<string> ParseCsvLine(string line)
            {
                var result = new List<string>();
                if (line == null) return result;

                var cur = new StringBuilder();
                bool inQuotes = false;
                for (int i = 0; i < line.Length; i++)
                {
                    char c = line[i];
                    if (inQuotes)
                    {
                        if (c == '"')
                        {
                            // Nếu là "" coi là dấu " trong dữ liệu
                            if (i + 1 < line.Length && line[i + 1] == '"')
                            {
                                cur.Append('"');
                                i++;
                            }
                            else
                            {
                                inQuotes = false;
                            }
                        }
                        else
                        {
                            cur.Append(c);
                        }
                    }
                    else
                    {
                        if (c == '"')
                        {
                            inQuotes = true;
                        }
                        else if (c == ',')
                        {
                            result.Add(cur.ToString());
                            cur.Clear();
                        }
                        else
                        {
                            cur.Append(c);
                        }
                    }
                }
                result.Add(cur.ToString());
                return result;
            }

            // Kiểm tra header (nếu có)
            var headerFields = ParseCsvLine(lines[0]);
            bool hasHeader = headerFields.Any(h =>
                new[] { "hovaten", "hovaten", "hoten", "ten", "tenkh", "hovaten".ToLower(), "tenkh".ToLower(), "hovaten".ToLower(), "dienthoai", "sodienthoai", "sdt", "diachi", "address" }
                .Contains(headerFields[0].Trim().ToLower())) // heuristic: nếu trường đầu giống tên thì coi là header
                || headerFields.Any(h => new[] { "hovaten", "dienthoai", "diachi", "ten", "sdt", "sodienthoai" }.Contains(h.Trim().ToLower()));

            int startLine = hasHeader ? 1 : 0;

            int added = 0, skipped = 0;
            for (int i = startLine; i < lines.Count; i++)
            {
                var fields = ParseCsvLine(lines[i]);
                if (fields.Count < 1)
                {
                    skipped++;
                    continue;
                }

                // Nếu header có tên cột, tìm index tương ứng; nếu không, giả sử thứ tự: HoVaTen, DienThoai, DiaChi
                string ten = string.Empty;
                string sdt = string.Empty;
                string diachi = string.Empty;

                if (hasHeader)
                {
                    // map dựa trên headerFields
                    for (int c = 0; c < headerFields.Count && c < fields.Count; c++)
                    {
                        string col = headerFields[c].Trim().ToLower();
                        string val = fields[c].Trim();
                        if (col.Contains("ten") || col.Contains("ho") || col.Contains("ho va ten") || col.Contains("hovaten") || col.Contains("hoten"))
                        {
                            ten = val;
                        }
                        else if (col.Contains("sdt") || col.Contains("dien") || col.Contains("sodienthoai") || col.Contains("dienthoai"))
                        {
                            sdt = val;
                        }
                        else if (col.Contains("diachi") || col.Contains("address") || col.Contains("dia chi"))
                        {
                            diachi = val;
                        }
                    }
                }
                else
                {
                    // không có header -> giả định cột: HoVaTen, DienThoai, DiaChi
                    ten = fields.Count > 0 ? fields[0].Trim() : string.Empty;
                    sdt = fields.Count > 1 ? fields[1].Trim() : string.Empty;
                    diachi = fields.Count > 2 ? fields[2].Trim() : string.Empty;
                }

                // Nếu tất cả rỗng thì bỏ qua
                if (string.IsNullOrWhiteSpace(ten) && string.IsNullOrWhiteSpace(sdt) && string.IsNullOrWhiteSpace(diachi))
                {
                    skipped++;
                    continue;
                }

                try
                {
                    KhachHang kh = new KhachHang
                    {
                        HoVaTen = ten,
                        DienThoai = sdt,
                        DiaChi = diachi
                    };
                    context.KhachHang.Add(kh);
                    added++;
                }
                catch
                {
                    skipped++;
                }
            }

            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu vào database: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Tải lại dữ liệu và thông báo kết quả
            LoadData(context.KhachHang.ToList());
            MessageBox.Show($"Nhập xong. Đã thêm: {added}, Bỏ qua: {skipped}", "Kết quả nhập", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnXuat_Click(object sender, EventArgs e)
        { // Hỏi nơi lưu file CSV
            using SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*",
                Title = "Lưu danh sách khách hàng ra CSV",
                FileName = "KhachHang.csv",
                OverwritePrompt = true
            };

            if (sfd.ShowDialog() != DialogResult.OK)
            {
                return; // Người dùng hủy
            }

            string path = sfd.FileName;

            // Lấy dữ liệu hiện tại (ưu tiên dữ liệu hiển thị trên BindingSource để xuất theo filter nếu có)
            var items = (bindingSource.DataSource as List<KhachHang>) ?? context.KhachHang.ToList();

            // Hàm escape trường CSV (bọc bằng " và thay " thành "")
            static string EscapeCsv(string? s)
            {
                if (string.IsNullOrEmpty(s)) return "";
                string v = s.Replace("\"", "\"\"");
                if (v.Contains(",") || v.Contains("\"") || v.Contains("\n") || v.Contains("\r"))
                {
                    return $"\"{v}\"";
                }
                return v;
            }

            var sb = new StringBuilder();
            // Header
            sb.AppendLine("HoVaTen,DienThoai,DiaChi");
            foreach (var k in items)
            {
                string line = string.Join(",",
                    EscapeCsv(k.HoVaTen),
                    EscapeCsv(k.DienThoai),
                    EscapeCsv(k.DiaChi));
                sb.AppendLine(line);
            }

            try
            {
                // Ghi file với BOM UTF8 để hiển thị tiếng Việt tốt trong Excel
                File.WriteAllText(path, sb.ToString(), new UTF8Encoding(true));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi ghi file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Xuất file CSV thành công.", "Xuất", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}