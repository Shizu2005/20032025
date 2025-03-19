 using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace baitaplonquanlycuahangbanquanao
{
    public partial class f_donhang : Form
    {
        public string constr = "Data Source=LAPTOP-5D4306EF\\SQLEXPRES;Initial Catalog=BTL_HSK;Integrated Security=True";
        hamdungchung hamdungchung = new hamdungchung();
        public f_donhang()
        {
            InitializeComponent();
            //hamdungchung.loadcombobox("btlLoaiHang", combobox_loaihang, "sMaLoaiHang", "sTenLoaiHang");
            //hamdungchung.loadcombobox("btlNhaCungCap", comboBox_tenNCC, "sMaNCC", "sTenNCC");
        }

        //private List<GioHang> listgiohang = new List<GioHang>();
        // chat gpt
        private BindingList<GioHang> listgiohang = new BindingList<GioHang>();

        private void DoiTenCot()
        {
            datagridview_giohang.Columns["MaHang"].HeaderText = "Mã hàng";
            datagridview_giohang.Columns["LoaiHang"].HeaderText = "Loại hàng";
            datagridview_giohang.Columns["TenSanPham"].HeaderText = "Tên sản phẩm";
            datagridview_giohang.Columns["TenNCC"].HeaderText = "Tên nhà cung cấp";
            datagridview_giohang.Columns["SoLuong"].HeaderText = "Số lượng";
            datagridview_giohang.Columns["GiaHang"].HeaderText = "Giá hàng";
            datagridview_giohang.Columns["Size"].HeaderText = "Size";
            datagridview_giohang.Columns["MauSac"].HeaderText = "Màu sắc";
            datagridview_giohang.Columns["ChatLieu"].HeaderText = "Chất liệu";
        }

        private void lammoinut()
        {
            datagridview_giohang.ClearSelection();
            datagridview_giohang.CurrentCell = null;
            dataGridView_mathang.ClearSelection();
            dataGridView_mathang.CurrentCell = null;
        }

        private void f_donhang_Load(object sender, EventArgs e)
        {
            hamdungchung dungchung = new hamdungchung();
            dungchung.ketnoi();
            dungchung.loadgridview("v_MatHang_ChiTiet", dataGridView_mathang);
            //datagridview_giohang.DataSource = new BindingList<GioHang>(listgiohang);
            // chat gpt
            datagridview_giohang.DataSource = listgiohang;
            datagridview_giohang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private DataGridViewRow GetSelectedRow(DataGridView gridView)
        {
            if (gridView.CurrentRow != null)
            {
                return gridView.CurrentRow;
            }
            else
            {
                MessageBox.Show("Không có dòng nào được chọn!");
                return null;
            }
        }

        private void CapNhatTongTien()
        {
            int tongTien = listgiohang.Sum(sp => sp.GiaHang * sp.SoLuong);
            textbox_tongtien.Text = tongTien.ToString("N0"); // Hiển thị số có dấu phân cách
        }

        private void button_them_Click(object sender, EventArgs e)
        {

            //if (textbox_soluong.Text == "" || textbox_gia.Text == "")
            //{
            //    MessageBox.Show("Vui lòng nhập thông tin số lượng và giá!");
            //}
            //else
            //{
            //    DataGridViewRow row = GetSelectedRow(dataGridView_mathang);
            //    if (row == null)
            //    {
            //        MessageBox.Show("Vui lòng chọn một sản phẩm trước khi thêm!");
            //        return;
            //    }

            //    string mahang = row.Cells["Mặt hàng"].Value?.ToString();
            //    string loaihang = row.Cells["Loại hàng"].Value?.ToString();
            //    string tensanpham = row.Cells["Tên sản phẩm"].Value?.ToString();
            //    int soluong = int.Parse(textbox_soluong.Text.ToString());
            //    string size = row.Cells["Size"].Value?.ToString();
            //    string mausac = row.Cells["Màu sắc"].Value?.ToString();
            //    string chatlieu = row.Cells["Chất liệu"].Value?.ToString();
            //    int giahang = int.Parse(textbox_gia.Text.Trim());

            //    listgiohang.Add(new GioHang(mahang, loaihang, tensanpham, soluong, giahang, size, mausac, chatlieu));
            //    datagridview_giohang.DataSource = null;
            //    datagridview_giohang.DataSource = listgiohang;
            //    CapNhatTongTien();
            //    DoiTenCot();


            //}
            //lammoinut();

                
                if (textbox_soluong.Text == "" || textbox_gia.Text == "")
            {
                MessageBox.Show("Vui lòng nhập thông tin số lượng và giá!");
                return;
            }

            DataGridViewRow row = GetSelectedRow(dataGridView_mathang);
            if (row == null)
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm trước khi thêm!");
                return;
            }

            // Lấy mã mặt hàng
            string maMH = row.Cells["Mã mặt hàng"].Value?.ToString();
            if (string.IsNullOrEmpty(maMH)) return;

            // Cập nhật danh sách kích thước vào ComboBoxCell
            var sizeCell = (DataGridViewComboBoxCell)row.Cells["sSize"];
            sizeCell.DataSource = GetSizeList(maMH);

            // Cập nhật danh sách màu sắc vào ComboBoxCell
            var mauSacCell = (DataGridViewComboBoxCell)row.Cells["sMauSac"];
            mauSacCell.DataSource = GetMauSacList(maMH);

            string mahang = row.Cells["Mã mặt hàng"].Value?.ToString();
            string loaihang = row.Cells["Loại hàng"].Value?.ToString();
            string tensanpham = row.Cells["Tên sản phẩm"].Value?.ToString();
            string tenNCC = row.Cells["Tên nhà cung cấp"].Value?.ToString();
            int soluong = int.Parse(textbox_soluong.Text);
            string size = sizeCell.Value?.ToString();
            string mausac = mauSacCell.Value?.ToString();
            string chatlieu = row.Cells["Chất liệu"].Value?.ToString();
            int giahang = int.Parse(textbox_gia.Text.Trim());

            // Thêm sản phẩm vào BindingList
            listgiohang.Add(new GioHang(mahang, loaihang, tensanpham, tenNCC, soluong, giahang, size, mausac, chatlieu));

            datagridview_giohang.DataSource = null;
            datagridview_giohang.DataSource = listgiohang;

            // Gọi hàm cập nhật số lượng trong database
            hamdungchung ham = new hamdungchung();
            ham.ketnoi();
            ham.CapNhatSoLuongMatHang(mahang, -soluong);
            dataGridView_mathang.Refresh();
            ham.loadgridview("v_MatHang_ChiTiet", dataGridView_mathang);
            // Không cần gán lại DataSource
            CapNhatTongTien();
            DoiTenCot();
            lammoinut();
        }

        private void label_dongia_Click(object sender, EventArgs e)
        {

        }

        private void button_xoasanpham_Click(object sender, EventArgs e)
        {
            //if (datagridview_giohang.CurrentCell != null) // Kiểm tra nếu có ô đang được chọn
            //{
            //    int rowIndex = datagridview_giohang.CurrentCell.RowIndex; // Lấy chỉ mục dòng hiện tại

            //    if (rowIndex >= 0 && rowIndex < listgiohang.Count)
            //    {
            //        // Xóa phần tử tại vị trí tương ứng trong danh sách
            //        listgiohang.RemoveAt(rowIndex);

            //        // Cập nhật lại DataGridView
            //        datagridview_giohang.DataSource = null;
            //        datagridview_giohang.DataSource = new BindingList<GioHang>(listgiohang);
            //        DoiTenCot();
            //        // Cập nhật tổng tiền
            //        CapNhatTongTien();


            //        // Bỏ chọn dòng
            //        datagridview_giohang.ClearSelection();
            //        datagridview_giohang.CurrentCell = null;
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Vui lòng chọn một sản phẩm để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}


            //if (datagridview_giohang.CurrentCell != null) // Kiểm tra nếu có ô đang được chọn
            //{
            //    int rowIndex = datagridview_giohang.CurrentCell.RowIndex; // Lấy chỉ mục dòng hiện tại

            //    if (rowIndex >= 0 && rowIndex < listgiohang.Count)
            //    {
            //        // Xóa sản phẩm khỏi danh sách
            //        listgiohang.RemoveAt(rowIndex);

            //        // Không cần gán lại DataSource
            //        CapNhatTongTien();
            //        DoiTenCot();
            //        datagridview_giohang.ClearSelection();
            //        datagridview_giohang.CurrentCell = null;
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Vui lòng chọn một sản phẩm để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}

            if (datagridview_giohang.CurrentCell != null)
            {
                int rowIndex = datagridview_giohang.CurrentCell.RowIndex;

                if (rowIndex >= 0 && rowIndex < listgiohang.Count)
                {
                    GioHang sanpham = listgiohang[rowIndex]; // Lấy sản phẩm cần xóa
                    string mahang = sanpham.MaHang;
                    int soluong = sanpham.SoLuong;

                    // Xóa sản phẩm khỏi danh sách giỏ hàng
                    listgiohang.RemoveAt(rowIndex);
                    datagridview_giohang.DataSource = null;
                    datagridview_giohang.DataSource = new BindingList<GioHang>(listgiohang);

                    // Cập nhật lại số lượng trong bảng hàng hóa
                    hamdungchung ham = new hamdungchung();
                    ham.ketnoi();
                    ham.CapNhatSoLuongMatHang(mahang, soluong); // Tăng lại số lượng hàng trong kho
                    ham.loadgridview("v_MatHang_ChiTiet", dataGridView_mathang);
                    // Cập nhật tổng tiền
                    CapNhatTongTien();
                    DoiTenCot();

                    // Bỏ chọn dòng
                    datagridview_giohang.ClearSelection();
                    datagridview_giohang.CurrentCell = null;
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void dataGridView_mathang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            hamdungchung hamdungchung = new hamdungchung();
            hamdungchung.ketnoi();
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) // Đảm bảo không phải tiêu đề cột
            {
                DataGridViewRow row = dataGridView_mathang.Rows[e.RowIndex];

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
                textbox_mamathang.Text = row.Cells["Mã mặt hàng"].Value.ToString();
                combobox_loaihang.Text = row.Cells["Loại hàng"].Value.ToString();
                textbox_tensanpham.Text = row.Cells["Tên sản phẩm"].Value.ToString();
                comboBox_tenNCC.Text = row.Cells["Tên nhà cung cấp"].Value.ToString();
                textbox_soluong.Text = row.Cells["Tổng số lượng"].Value.ToString();
                textbox_gia.Text = row.Cells["Giá hàng"].Value.ToString();
                textbox_chatlieu.Text = row.Cells["Chất liệu"].Value.ToString();
                combobox_size.Text = sizeCell.Value?.ToString();
                combobox_mausac.Text = mauSacCell.Value?.ToString();
            }
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

        private void dgvmathang_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //dgvmathang.Refresh();
            // Kiểm tra nếu chưa có cột "Kích thước" và "Màu sắc" thì thêm vào DataGridView
            if (!dataGridView_mathang.Columns.Contains("sSize"))
            {
                DataGridViewComboBoxColumn sizeColumn = new DataGridViewComboBoxColumn
                {
                    Name = "sSize",
                    HeaderText = "Kích thước",
                    DataPropertyName = "sSize"
                };
                dataGridView_mathang.Columns.Add(sizeColumn);
            }

            if (!dataGridView_mathang.Columns.Contains("sMauSac"))
            {
                DataGridViewComboBoxColumn mauSacColumn = new DataGridViewComboBoxColumn
                {
                    Name = "sMauSac",
                    HeaderText = "Màu sắc",
                    DataPropertyName = "sMauSac"
                };
                dataGridView_mathang.Columns.Add(mauSacColumn);
            }

            // Duyệt qua từng dòng để cập nhật danh sách kích thước & màu sắc
            foreach (DataGridViewRow row in dataGridView_mathang.Rows)
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

        private void dataGridView_mathang_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (textbox_soluong.Text == "" || textbox_gia.Text == "")
            {
                MessageBox.Show("Vui lòng nhập số lượng và giá!");
                return;

            }
            else
            {
                if (e.RowIndex >= 0) // Đảm bảo không bấm vào tiêu đề cột
                {
                    // Lấy dữ liệu của hàng được chọn

                    DataGridViewRow row = dataGridView_mathang.Rows[e.RowIndex];

                    // Lấy mã mặt hàng
                    string maMH = row.Cells["Mã mặt hàng"].Value?.ToString();
                    if (string.IsNullOrEmpty(maMH)) return;

                    // Cập nhật danh sách kích thước vào ComboBoxCell
                    var sizeCell = (DataGridViewComboBoxCell)row.Cells["sSize"];
                    sizeCell.DataSource = GetSizeList(maMH);

                    // Cập nhật danh sách màu sắc vào ComboBoxCell
                    var mauSacCell = (DataGridViewComboBoxCell)row.Cells["sMauSac"];
                    mauSacCell.DataSource = GetMauSacList(maMH);

                    string mahang = row.Cells["Mã mặt hàng"].Value?.ToString();
                    string loaihang = row.Cells["Loại hàng"].Value?.ToString();
                    string tensanpham = row.Cells["Tên sản phẩm"].Value?.ToString();
                    string tenNCC = row.Cells["Tên nhà cung cấp"].Value?.ToString();
                    int soluong = 1;
                    string size = sizeCell.Value?.ToString();
                    string mausac = mauSacCell.Value?.ToString();
                    string chatlieu = row.Cells["Chất liệu"].Value?.ToString();
                    int giahang = int.Parse(textbox_gia.Text.Trim());

                    listgiohang.Add(new GioHang(mahang, loaihang, tensanpham, tenNCC, soluong, giahang, size, mausac, chatlieu));
                    datagridview_giohang.DataSource = null;
                    datagridview_giohang.DataSource = listgiohang;
                    CapNhatTongTien();
                    DoiTenCot();
                    dataGridView_mathang.ClearSelection();

                    // 🔽 Đặt lại con trỏ chuột không chọn dòng nào
                    dataGridView_mathang.CurrentCell = null;
                    lammoinut();
                }
            }
            
        }

        private void button_lammoi_Click(object sender, EventArgs e)
        {
            listgiohang.Clear();
            datagridview_giohang.DataSource = new BindingList<GioHang>(listgiohang);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button_thanhtoan_Click(object sender, EventArgs e)
        {

        }
    }
}
