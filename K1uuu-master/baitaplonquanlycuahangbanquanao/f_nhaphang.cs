using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace baitaplonquanlycuahangbanquanao
{
    public partial class f_nhaphang : Form
    {
        public string constr = "Data Source=LAPTOP-5D4306EF\\SQLEXPRES;Initial Catalog=BTL_HSK;Integrated Security=True";
        hamdungchung ham = new hamdungchung();
        //public string currentUserID = "NV002";
        private string maNhanVien;
        // Lưu mã nhân viên
        //public f_nhaphang(string tenNGuoiDung)
        //{
        //    InitializeComponent();
        //    this.Load += new EventHandler(f_nhaphang_Load);
        //    txbtennguoinhap.Text = tenNGuoiDung; // Hiển thị tên đăng nhập đã lưu
        //    //InitializeComponent();
        //    //this.maNhanVien = maNhanVien; // Gán mã nhân viên
        //    //this.Load += new EventHandler(f_nhaphang_Load);
        //    //txbtennguoinhap.Text = maNhanVien;
        //}

        private string maNV;
        private string tenNV;
        // code sửa chat gpt
        public f_nhaphang(string maNV, string tenNV)
        {
            InitializeComponent();
            this.Load += new EventHandler(f_nhaphang_Load);

            this.maNV = maNV;
            this.tenNV = tenNV;
            txbtennguoinhap.Text = maNV;
            //MessageBox.Show(maNV);
            // Hiển thị thông tin nhân viên trong form nhập hàng
            //lblMaNhanVien.Text = "Mã NV: " + maNV;
            //lblTenNhanVien.Text = "Tên: " + tenNV;
        }

        private void f_nhaphang_Load(object sender, EventArgs e)
        {
            ham.loadgridview("v_MatHang_fNhapHang", dgvdssp);
            LoadComboBoxData(); // Load dữ liệu vào combobox
            //InitializeDataGridView();
        }
        /*private void InitializeDataGridView()
        {
            dgvhangnhap.Columns.Clear(); // Xóa cột cũ nếu có
            dgvhangnhap.Columns.Add("MaDonHangNhap", "Mã Đơn Hàng Nhập");
            dgvhangnhap.Columns.Add("NguoiNhap", "Người Nhập");
            dgvhangnhap.Columns.Add("NhaCungCap", "Nhà Cung Cấp");
            dgvhangnhap.Columns.Add("NgayNhap", "Ngày Nhập");
            dgvhangnhap.Columns.Add("LoaiHang", "Loại Hàng");
            dgvhangnhap.Columns.Add("MaMatHang", "Mã Mặt Hàng");
            dgvhangnhap.Columns.Add("TenMatHang", "Tên Mặt Hàng");
            dgvhangnhap.Columns.Add("SoLuongNhap", "Số Lượng Nhập");
            dgvhangnhap.Columns.Add("GiaNhap", "Giá Nhập");
            dgvhangnhap.Columns.Add("MauSac", "Màu Sắc");
            dgvhangnhap.Columns.Add("ChatLieu", "Chất Liệu");
            dgvhangnhap.Columns.Add("ThanhTien", "Thành Tiền");
        }*/
        private void LoadComboBoxData()
        {
            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                LoadComboBox("SELECT sMaNCC FROM btlNhaCungCap", cbnhacungcap, "sMaNCC");
            }
        }
        private void LoadComboBox(string query, ComboBox cb, string valueField)
        {
            SqlDataAdapter da = new SqlDataAdapter(query, new SqlConnection(constr));
            DataTable dt = new DataTable();
            da.Fill(dt);
            cb.DataSource = dt;
            cb.DisplayMember = valueField;
            cb.ValueMember = valueField;
            cb.SelectedIndex = -1;
        }
        private void UpdateTongTien()
        {
            int tongTien = 0;
            foreach (DataGridViewRow row in dgvhangnhap.Rows)
            {
                if (row.Cells["ThanhTien"].Value != null)
                    tongTien += Convert.ToInt32(row.Cells["ThanhTien"].Value);
            }
            txbtongtien.Text = tongTien.ToString();
        }
        private int GetSoLuongTon(string maMatHang)
        {
            foreach (DataGridViewRow row in dgvdssp.Rows)
            {
                if (row.Cells["sMaMH"].Value != null && row.Cells["sMaMH"].Value.ToString() == maMatHang)
                {
                    return Convert.ToInt32(row.Cells["iSoLuong"].Value);
                }
            }
            return 0;
        }
        private void CapNhatSoLuongTon(string maMatHang, int soLuongGiam)
        {
            foreach (DataGridViewRow row in dgvdssp.Rows)
            {
                if (row.Cells["sMaMH"].Value != null && row.Cells["sMaMH"].Value.ToString() == maMatHang)
                {
                    int soLuongMoi = Convert.ToInt32(row.Cells["iSoLuong"].Value) - soLuongGiam;
                    row.Cells["iSoLuong"].Value = soLuongMoi;
                    break;
                }
            }
        }
        private void HoanLaiSoLuongTon(string maMatHang, int soLuongHoanLai)
        {
            foreach (DataGridViewRow row in dgvdssp.Rows)
            {
                if (row.Cells["sMaMH"].Value != null && row.Cells["sMaMH"].Value.ToString() == maMatHang)
                {
                    int soLuongMoi = Convert.ToInt32(row.Cells["iSoLuong"].Value) + soLuongHoanLai;
                    row.Cells["iSoLuong"].Value = soLuongMoi;
                    break;
                }
            }
        }
        private void btnthem_Click(object sender, EventArgs e)
        {

        }




        private void txbsoluong_TextChanged(object sender, EventArgs e)
        {

        }

        private void txbsize_TextChanged(object sender, EventArgs e)
        {

        }

        /*private void dgvdssp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvdssp.Rows[e.RowIndex];

                cbmamathang.SelectedValue = row.Cells["sMaMH"].Value.ToString();
                txbtenmathang.Text = row.Cells["sTenMH"].Value.ToString();
                cbmaloaihang.SelectedValue = row.Cells["sMaLoaiHang"].Value.ToString();
                cbnhacungcap.SelectedValue = row.Cells["sMaNCC"].Value.ToString();
                txbsoluong.Text = row.Cells["iSoluong"].Value.ToString();
                txbgianhap.Text = row.Cells["fGiaHang"].Value.ToString();
                txbsize.Text = row.Cells["fSize"].Value.ToString();
                txbchatlieu.Text = row.Cells["sChatLieu"].Value.ToString();
                txbmausac.Text = row.Cells["sMauSac"].Value.ToString() ;
            }
        }*/

        private void btnreset_Click(object sender, EventArgs e)
        {
            ham.loadgridview("v_MatHang_fNhapHang", dgvdssp);
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {

        }


        private void dgvhangnhap_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) //btnxacnhan nha bro
        {
            if (dgvhangnhap.Rows.Count == 0)
            {
                MessageBox.Show("Không có sản phẩm nào để lưu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    string maNCC = cbnhacungcap.SelectedValue?.ToString();
                    if (string.IsNullOrEmpty(maNCC))
                    {
                        MessageBox.Show("Vui lòng chọn nhà cung cấp hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string maNhapHang = "NH" + DateTime.Now.ToString("yyyyMMddHHmmss");
                    DateTime ngayNhap = dtngaynhap.Value; // Sử dụng kiểu datetime

                    string insertDonNhap = "INSERT INTO btlDonNhapHang (sMaNhapHang, sMaNV, dNgayNhapHang, sMaNCC, iTongTien) VALUES (@MaNH, @MaNV, @NgayNhap, @MaNCC, @TongTien)";
                    SqlCommand cmdDonNhap = new SqlCommand(insertDonNhap, conn, transaction);
                    cmdDonNhap.Parameters.AddWithValue("@MaNH", maNhapHang);
                    cmdDonNhap.Parameters.AddWithValue("@MaNV", txbtennguoinhap.Text);
                    cmdDonNhap.Parameters.AddWithValue("@NgayNhap", ngayNhap);
                    cmdDonNhap.Parameters.AddWithValue("@MaNCC", maNCC);
                    cmdDonNhap.Parameters.AddWithValue("@TongTien", Convert.ToInt32(txbtongtien.Text));
                    cmdDonNhap.ExecuteNonQuery();

                    int tongTien = 0;

                    foreach (DataGridViewRow row in dgvhangnhap.Rows)
                    {
                        if (row.Cells["MaMatHang"].Value != null)
                        {
                            string maMH = row.Cells["MaMatHang"].Value.ToString();
                            int soLuongNhap = Convert.ToInt32(row.Cells["SoLuongNhap"].Value);
                            int giaNhap = Convert.ToInt32(row.Cells["GiaNhap"].Value);
                            tongTien += soLuongNhap * giaNhap;

                            string insertChiTiet = "INSERT INTO btlChiTietDonNhapHang (sMaNhapHang, sMaHang, iGiaNhap, fSoLuongNhap) VALUES (@MaNH, @MaMH, @GiaNhap, @SoLuong)";
                            SqlCommand cmdChiTiet = new SqlCommand(insertChiTiet, conn, transaction);
                            cmdChiTiet.Parameters.AddWithValue("@MaNH", maNhapHang);
                            cmdChiTiet.Parameters.AddWithValue("@MaMH", maMH);
                            cmdChiTiet.Parameters.AddWithValue("@GiaNhap", giaNhap);
                            cmdChiTiet.Parameters.AddWithValue("@SoLuong", soLuongNhap);
                            cmdChiTiet.ExecuteNonQuery();

                            string updateSanPham = "UPDATE btlMatHang SET iSoLuong = iSoLuong + @SoLuong WHERE sMaMH = @MaMH";
                            SqlCommand cmdUpdateSanPham = new SqlCommand(updateSanPham, conn, transaction);
                            cmdUpdateSanPham.Parameters.AddWithValue("@SoLuong", soLuongNhap);
                            cmdUpdateSanPham.Parameters.AddWithValue("@MaMH", maMH);
                            cmdUpdateSanPham.ExecuteNonQuery();
                        }
                    }

                    string updateDonNhap = "UPDATE btlDonNhapHang SET iTongTien = @TongTien WHERE sMaNhapHang = @MaNH";
                    SqlCommand cmdUpdateDonNhap = new SqlCommand(updateDonNhap, conn, transaction);
                    cmdUpdateDonNhap.Parameters.AddWithValue("@TongTien", tongTien);
                    cmdUpdateDonNhap.Parameters.AddWithValue("@MaNH", maNhapHang);
                    cmdUpdateDonNhap.ExecuteNonQuery();

                    transaction.Commit();
                    MessageBox.Show("Nhập hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvhangnhap.Rows.Clear();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Lỗi nhập hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txbsoluongnhap_TextChanged(object sender, EventArgs e)
        {

        }

        // Hàm lấy số lượng theo mã mặt hàng, kích thước và màu sắc
        private int GetSoLuong(string maMH, string size, string mauSac)
        {
            int soLuong = 0;
            string query = "SELECT iSoluong FROM btlChiTietMatHang WHERE sMaMH = @maMH AND sSize = @size AND sMauSac = @mauSac";

            using (SqlConnection conn = new SqlConnection(constr))
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
        private void dgvdssp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) // Đảm bảo không phải tiêu đề cột
            {
                DataGridViewRow row = dgvdssp.Rows[e.RowIndex];

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

                textBox_Mamathang.Text = row.Cells["Mã mặt hàng"].Value.ToString();
                textBox_Maloaihang.Text = row.Cells["Mã loại hàng"].Value.ToString();
                comboBox_Tenloaihang.Text = row.Cells["Loại hàng"].Value.ToString();
                txbtenmathang.Text = row.Cells["Tên sản phẩm"].Value.ToString();
                txbsoluong.Text = row.Cells["Tổng số lượng"].Value.ToString();
                txbgianhap.Text = row.Cells["Giá hàng"].Value.ToString();
                txbchatlieu.Text = row.Cells["Chất liệu"].Value.ToString();
                txbsize.Text = sizeCell.Value?.ToString();
                txbmausac.Text = mauSacCell.Value?.ToString();
            }
        }

        private void cbtenloaihang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_Tenloaihang.SelectedValue != null)
            {
                string tenLoaiHang = comboBox_Tenloaihang.SelectedValue.ToString();
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

                dgvdssp.DataSource = dt;
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

                dgvdssp.DataSource = dt;
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

        private void dgvdssp_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

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
            if (dgvdssp.CurrentCell == null) return;

            int rowIndex = dgvdssp.CurrentCell.RowIndex;
            int columnIndex = dgvdssp.CurrentCell.ColumnIndex;

            if (rowIndex >= 0 && columnIndex >= 0)
            {
                DataGridViewRow row = dgvdssp.Rows[rowIndex];

                // Nếu cột hiện tại là fSize, cập nhật txbsize
                if (dgvdssp.Columns[columnIndex].Name == "sSize")
                {
                    txbsize.Text = row.Cells["sSize"].Value?.ToString();
                }
                // Nếu cột hiện tại là sMauSac, cập nhật txbmausac
                else if (dgvdssp.Columns[columnIndex].Name == "sMauSac")
                {
                    txbmausac.Text = row.Cells["sMauSac"].Value?.ToString();
                }
            }
        }
        private void dgvdssp_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {

        }
    }
}
