using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace baitaplonquanlycuahangbanquanao
{
    public partial class f_sanpham : Form
    {
        public string constr = "Data Source=LAPTOP-5D4306EF\\SQLEXPRES;Initial Catalog=BTL_HSK;Integrated Security=True";
        hamdungchung ham = new hamdungchung();

        public f_sanpham()
        {
            InitializeComponent();
            LoadData();
            /*Load data vào dgvmathang ngay khi load form
            để tạo điều kiện cho sự kiện cbtenloaihang_SelectedIndexChanged và cbnhacungcap_SelectedIndexChanged chạy*/
            ham.loadgridview("v_MatHang_ChiTiet", dgvmathang);
        }

        private void LoadData()
        {
            ham.loadgridview("btlLoaiHang", dgvloaihang);
            // Load combobox từ database
            ham.loadcombobox("btlLoaiHang", cbtenloaihang, "sMaLoaiHang", "sTenLoaiHang");
            ham.loadcombobox("btlNhaCungCap", cbnhacungcap, "sMaNCC", "sTenNCC");
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            string sql = $"INSERT INTO btlLoaiHang VALUES ('{txbmaloaihang.Text}', N'{txbtenloaihang.Text}')";
            if (hamdungchung.thuchiendoanmasql(ham.constr, sql))
                MessageBox.Show("Thêm loại hàng thành công!");
            else
                MessageBox.Show("Thêm thất bại!");
            LoadData();
        }

        private void btnthemmh_Click(object sender, EventArgs e)
        {
            string sql = $"INSERT INTO btlMatHang (sMaMH, sMaLoaiHang, sTenMH, sMaNCC, iSoluong, fGiaHang, sChatLieu) " +
                         $"VALUES ('{txbmamathang.Text}', '{cbtenloaihang.SelectedValue}', N'{txbtenmathang.Text}', '{cbnhacungcap.SelectedValue}', {txbsoluong.Text}, {txbgianhap.Text}, N'{txbchatlieu.Text}')";
            if (hamdungchung.thuchiendoanmasql(ham.constr, sql))
                MessageBox.Show("Thêm mặt hàng thành công!");
            else
                MessageBox.Show("Thêm thất bại!");
            LoadData();
        }

        private void btnthemmh_chitiet_Click(object sender, EventArgs e)
        {
            string sql = $"INSERT INTO btlChiTietMatHang (sMaMH, sMauSac, sSize, iSoLuong) " +
                         $"VALUES ('{txbmamathang.Text}', N'{txbmausac.Text}', N'{txbsize.Text}', {txbsoluong.Text})";
            if (hamdungchung.thuchiendoanmasql(ham.constr, sql))
                MessageBox.Show("Thêm chi tiết mặt hàng thành công!");
            else
                MessageBox.Show("Thêm thất bại!");
            LoadData();
        }

        private void btnsuamh_Click(object sender, EventArgs e)
        {
            string sql = $"UPDATE btlMatHang SET sMaLoaiHang='{cbtenloaihang.SelectedValue}', sTenMH=N'{txbtenmathang.Text}', sMaNCC='{cbnhacungcap.SelectedValue}', " +
                         $"iSoluong={txbsoluong.Text}, fGiaHang={txbgianhap.Text}, sChatLieu=N'{txbchatlieu.Text}' WHERE sMaMH='{txbmamathang.Text}'";
            if (hamdungchung.thuchiendoanmasql(ham.constr, sql))
                MessageBox.Show("Sửa mặt hàng thành công!");
            else
                MessageBox.Show("Sửa thất bại!");
            LoadData();
        }

        private void btnsuamh_chitiet_Click(object sender, EventArgs e)
        {
            string sql = $"UPDATE btlChiTietMatHang SET sMauSac=N'{txbmausac.Text}', sSize=N'{txbsize.Text}', iSoLuong={txbsoluong.Text} " +
                         $"WHERE sMaMH='{txbmamathang.Text}' AND sMauSac=N'{txbmausac.Text}' AND sSize=N'{txbsize.Text}'";
            if (hamdungchung.thuchiendoanmasql(ham.constr, sql))
                MessageBox.Show("Sửa chi tiết mặt hàng thành công!");
            else
                MessageBox.Show("Sửa thất bại!");
            LoadData();
        }

        private void btnxoamh_Click(object sender, EventArgs e)
        {
            string sql = $"DELETE FROM btlMatHang WHERE sMaMH='{txbmamathang.Text}'";
            if (hamdungchung.thuchiendoanmasql(ham.constr, sql))
                MessageBox.Show("Xóa mặt hàng thành công!");
            else
                MessageBox.Show("Xóa thất bại!");
            LoadData();
        }

        private void btnxoamh_chitiet_Click(object sender, EventArgs e)
        {
            string sql = $"DELETE FROM btlChiTietMatHang WHERE sMaMH='{txbmamathang.Text}' AND sMauSac=N'{txbmausac.Text}' AND sSize=N'{txbsize.Text}'";
            if (hamdungchung.thuchiendoanmasql(ham.constr, sql))
                MessageBox.Show("Xóa chi tiết mặt hàng thành công!");
            else
                MessageBox.Show("Xóa thất bại!");
            LoadData();
        }

        // Hàm lấy số lượng theo mã mặt hàng, kích thước và màu sắc
        private int GetSoLuong(string maMH, string size, string mauSac)
        {
            int soLuong = 0;
            string query = "SELECT iSoluong FROM btlChiTietMatHang WHERE sMaMH = @maMH AND sSize = @size AND sMauSac = @mauSac";

            using (SqlConnection conn = new SqlConnection( constr))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@maMH", maMH);
                cmd.Parameters.AddWithValue("@size", size);
                cmd.Parameters.AddWithValue("@mauSac", mauSac);

                conn.Open();
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    soLuong = Convert.ToInt32(result);
                }
            }
            return soLuong;
        }
        private void dgvmathang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) // Đảm bảo không phải tiêu đề cột
            {
                DataGridViewRow row = dgvmathang.Rows[e.RowIndex];

                // Lấy mã mặt hàng
                string maMH = row.Cells["Mã mặt hàng"].Value?.ToString();
                if (string.IsNullOrEmpty(maMH)) return;

                // Cập nhật danh sách kích thước vào ComboBoxCell
                var sizeCell = (DataGridViewComboBoxCell)row.Cells["sSize"];
                sizeCell.DataSource = GetSizeList(maMH);

                // Cập nhật danh sách màu sắc vào ComboBoxCell
                var mauSacCell = (DataGridViewComboBoxCell)row.Cells["sMauSac"];
                mauSacCell.DataSource = GetMauSacList(maMH);

                // Nếu có giá trị chọn sẵn, lấy số lượng tương ứng
                string selectedSize = sizeCell.Value?.ToString();
                string selectedMauSac = mauSacCell.Value?.ToString();

                if (!string.IsNullOrEmpty(selectedSize) && !string.IsNullOrEmpty(selectedMauSac))
                {
                    row.Cells["Tổng số lượng"].Value = GetSoLuong(maMH, selectedSize, selectedMauSac);
                }

                txbmamathang.Text = row.Cells["Mã mặt hàng"].Value.ToString();
                txbtenmathang.Text = row.Cells["Tên sản phẩm"].Value.ToString();
                txbsoluong.Text = row.Cells["Tổng số lượng"].Value.ToString();
                txbgianhap.Text = row.Cells["Giá hàng"].Value.ToString();
                txbchatlieu.Text = row.Cells["Chất liệu"].Value.ToString();
                txbsize.Text = sizeCell.Value?.ToString();
                txbmausac.Text = mauSacCell.Value?.ToString();
                cbtenloaihang.Text = row.Cells["Loại hàng"].Value.ToString();
            }
        }

        private void cbtenloaihang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbtenloaihang.SelectedValue != null)
            {
                string tenLoaiHang = cbtenloaihang.SelectedValue.ToString();
                LoadMatHangTheoLoai(tenLoaiHang);
            }
        }

        private void LoadMatHangTheoLoai(string maLoaiHang)
        {
            string query = "SELECT * FROM v_MatHang_ChiTiet WHERE [Loại hàng] = @tenLoaiHang";

            using (SqlConnection conn = new SqlConnection(constr))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@tenLoaiHang", GetTenLoaiHang(maLoaiHang));
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvmathang.DataSource = dt;
            }
        }

        private string GetTenLoaiHang(string maLoaiHang)
        {
            string query = "SELECT sTenLoaiHang FROM btlLoaiHang WHERE sMaLoaiHang = @maLoaiHang";
            using (SqlConnection conn = new SqlConnection(constr))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@maLoaiHang", maLoaiHang);
                conn.Open();
                object result = cmd.ExecuteScalar();
                return result != null ? result.ToString() : "";
            }
        }

        private void cbnhacungcap_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbnhacungcap.SelectedValue != null)
            {
                string tenNCC = cbnhacungcap.SelectedValue.ToString();
                LoadMatHangTheoNCC(tenNCC);
            }
        }
        private void LoadMatHangTheoNCC(string maNCC)
        {
            string query = "SELECT * FROM v_MatHang_ChiTiet WHERE [Tên nhà cung cấp] = @tenNCC";

            using (SqlConnection conn = new SqlConnection(constr))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@tenNCC", GetTenNCC(maNCC));
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvmathang.DataSource = dt;
            }
        }

        private string GetTenNCC(string maNCC)
        {
            string query = "SELECT sTenNCC FROM btlNhaCungCap WHERE sMaNCC = @maNCC";
            using (SqlConnection conn = new SqlConnection(constr))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@maNCC", maNCC);
                conn.Open();
                object result = cmd.ExecuteScalar();
                return result != null ? result.ToString() : "";
            }
        }

        private void dgvloaihang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvloaihang.Rows[e.RowIndex];
                txbmaloaihang.Text = row.Cells["sMaLoaiHang"].Value.ToString();
                txbtenloaihang.Text = row.Cells["sTenLoaiHang"].Value.ToString();
            }
        }

        private void dgvmathang_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //dgvmathang.Refresh();
            // Kiểm tra nếu chưa có cột "Kích thước" và "Màu sắc" thì thêm vào DataGridView
            if (!dgvmathang.Columns.Contains("sSize"))
            {
                DataGridViewComboBoxColumn sizeColumn = new DataGridViewComboBoxColumn
                {
                    Name = "sSize",
                    HeaderText = "Kích thước",
                    DataPropertyName = "sSize"
                };
                dgvmathang.Columns.Add(sizeColumn);
            }

            if (!dgvmathang.Columns.Contains("sMauSac"))
            {
                DataGridViewComboBoxColumn mauSacColumn = new DataGridViewComboBoxColumn
                {
                    Name = "sMauSac",
                    HeaderText = "Màu sắc",
                    DataPropertyName = "sMauSac"
                };
                dgvmathang.Columns.Add(mauSacColumn);
            }

            // Duyệt qua từng dòng để cập nhật danh sách kích thước & màu sắc
            foreach (DataGridViewRow row in dgvmathang.Rows)
            {
                if (row.IsNewRow) continue;
                object value = row.Cells["Mã mặt hàng"].Value;
                if (value == null) continue;

                string maMH = value.ToString();

                // Gán danh sách kích thước vào cột "cSize"
                DataGridViewComboBoxCell sizeCell = new DataGridViewComboBoxCell();
                sizeCell.DataSource = GetSizeList(maMH);
                row.Cells["sSize"] = sizeCell;

                // Gán danh sách màu sắc vào cột "cMauSac"
                DataGridViewComboBoxCell mauSacCell = new DataGridViewComboBoxCell();
                mauSacCell.DataSource = GetMauSacList(maMH);
                row.Cells["sMauSac"] = mauSacCell;
            }
        }

        private List<string> GetMauSacList(string maMH)
        {
            List<string> list = new List<string>();
            string query = "SELECT DISTINCT sMauSac FROM btlChiTietMatHang WHERE sMaMH = @maMH";

            using (SqlConnection conn = new SqlConnection(constr))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@maMH", maMH);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(reader["sMauSac"].ToString());
                    }
                }
            }
            return list;
        }

        private List<string> GetSizeList(string maMH)
        {
            List<string> list = new List<string>();
            string query = "SELECT DISTINCT sSize FROM btlChiTietMatHang WHERE sMaMH = @maMH";

            using (SqlConnection conn = new SqlConnection(constr))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@maMH", maMH);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(reader["sSize"].ToString());
                    }
                }
            }
            return list;
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dgvmathang.CurrentCell == null) return;

            int rowIndex = dgvmathang.CurrentCell.RowIndex;
            int columnIndex = dgvmathang.CurrentCell.ColumnIndex;

            if (rowIndex >= 0 && columnIndex >= 0)
            {
                DataGridViewRow row = dgvmathang.Rows[rowIndex];

                // Nếu cột hiện tại là fSize, cập nhật txbsize
                if (dgvmathang.Columns[columnIndex].Name == "sSize")
                {
                    txbsize.Text = row.Cells["sSize"].Value?.ToString();
                }
                // Nếu cột hiện tại là sMauSac, cập nhật txbmausac
                else if (dgvmathang.Columns[columnIndex].Name == "sMauSac")
                {
                    txbmausac.Text = row.Cells["sMauSac"].Value?.ToString();
                }
            }
        }
        private void dgvmathang_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is ComboBox comboBox)
            {
                comboBox.SelectedIndexChanged -= ComboBox_SelectedIndexChanged; // Tránh đăng ký nhiều lần
                comboBox.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            }
        }

        private void btntailaids_Click(object sender, EventArgs e)
        {
            ham.loadgridview("v_MatHang_ChiTiet", dgvmathang);
        }
    }
}
