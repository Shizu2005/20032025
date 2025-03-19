using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;


namespace baitaplonquanlycuahangbanquanao
{
    public partial class f_doanhthu : Form
    {
        public string constr = "Data Source=LAPTOP-5D4306EF\\SQLEXPRES;Initial Catalog=BTL_HSK;Integrated Security=True";
        hamdungchung dc = new hamdungchung();
        public f_doanhthu()
        {
            InitializeComponent();
            dc.loadgridview("v_HoaDon", dataGridView_Thu);
            TinhTongTien();

            for (int i = 1; i <= 31; i++)
                comboBox_Ngay_Thu.Items.Add(i);
            for (int i = 1; i <= 12; i++)
                comboBox_Thang_Thu.Items.Add(i);
            for (int nam = 2000; nam <= DateTime.Now.Year; nam++)
                comboBox_Nam_Thu.Items.Add(nam);
        }

        private void comboBox_Ngay_Thu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_Ngay_Thu.SelectedItem != null)
            {
                int ngay = Convert.ToInt32(comboBox_Ngay_Thu.SelectedItem);

                // Nếu chọn 31, chỉ hiển thị các tháng có 31 ngày
                if (ngay == 31)
                {
                    comboBox_Thang_Thu.Items.Clear();
                    int[] thang31 = { 1, 3, 5, 7, 8, 10, 12 };
                    foreach (int thang in thang31)
                        comboBox_Thang_Thu.Items.Add(thang);
                }
                else
                {
                    comboBox_Thang_Thu.Items.Clear();
                    for (int i = 1; i <= 12; i++)
                        comboBox_Thang_Thu.Items.Add(i);
                }

                comboBox_Thang_Thu.Enabled = true;
                comboBox_Thang_Thu.SelectedIndex = -1;
                comboBox_Nam_Thu.Enabled = false;
            }
        }

        private void comboBox_Thang_Thu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_Thang_Thu.SelectedItem != null)
            {
                int ngay = comboBox_Ngay_Thu.SelectedItem != null ? Convert.ToInt32(comboBox_Ngay_Thu.SelectedItem) : 0;
                int thang = Convert.ToInt32(comboBox_Thang_Thu.SelectedItem);

                // Nếu chọn ngày 29 và tháng 2, chỉ cho phép chọn năm nhuận
                if (ngay == 29 && thang == 2)
                {
                    comboBox_Nam_Thu.Items.Clear();
                    for (int nam = 2000; nam <= DateTime.Now.Year; nam += 4) // Chỉ thêm năm nhuận
                        comboBox_Nam_Thu.Items.Add(nam);
                }
                else
                {
                    comboBox_Nam_Thu.Items.Clear();
                    for (int nam = 2000; nam <= DateTime.Now.Year; nam++)
                        comboBox_Nam_Thu.Items.Add(nam);
                }

                comboBox_Nam_Thu.Enabled = true;
                comboBox_Nam_Thu.SelectedIndex = -1;
            }
        }


        private void comboBox_Nam_Thu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_Nam_Thu.SelectedItem != null)
            {
                LoadDataGridView_Thu();
            }
        }

        private DataTable LayHoaDonTheoNgayThangNam(string ngay, string thang, string nam)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(constr))
            using (SqlCommand cmd = new SqlCommand("sp_LayHoaDonTheoNgayThangNam", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm tham số với kiểu dữ liệu phù hợp
                cmd.Parameters.Add("@ngay", SqlDbType.Int).Value = string.IsNullOrEmpty(ngay) ? (object)DBNull.Value : int.Parse(ngay);
                cmd.Parameters.Add("@thang", SqlDbType.Int).Value = string.IsNullOrEmpty(thang) ? (object)DBNull.Value : int.Parse(thang);
                cmd.Parameters.Add("@nam", SqlDbType.Int).Value = string.IsNullOrEmpty(nam) ? (object)DBNull.Value : int.Parse(nam);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
            }
            return dt;
        }

        public DataTable LayHoaDonTheoThangNam(int thang, int nam)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_LayHoaDonTheoThangNam", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@thang", thang);
                    cmd.Parameters.AddWithValue("@nam", nam);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        conn.Open();
                        adapter.Fill(dt);
                    }
                }
            }
            return dt;
        }

        public DataTable LayHoaDonTheoNam(int nam)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_LayHoaDonTheoNam", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nam", nam);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        conn.Open();
                        adapter.Fill(dt);
                    }
                }
            }
            return dt;
        }


        private void LoadDataGridView_Thu()
        {
            DataTable dt = new DataTable();

            int ngay = -1, thang = -1, nam = -1;

            // Kiểm tra giá trị được chọn trong các ComboBox
            if (comboBox_Ngay_Thu.SelectedItem != null)
                ngay = Convert.ToInt32(comboBox_Ngay_Thu.SelectedItem);

            if (comboBox_Thang_Thu.SelectedItem != null)
                thang = Convert.ToInt32(comboBox_Thang_Thu.SelectedItem);

            if (comboBox_Nam_Thu.SelectedItem != null)
                nam = Convert.ToInt32(comboBox_Nam_Thu.SelectedItem);

            using (SqlConnection conn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (ngay != -1 && thang != -1 && nam != -1)
                    {
                        // Truy vấn theo ngày, tháng, năm
                        cmd.CommandText = "sp_LayHoaDonTheoNgayThangNam";
                        cmd.Parameters.AddWithValue("@ngay", ngay);
                        cmd.Parameters.AddWithValue("@thang", thang);
                        cmd.Parameters.AddWithValue("@nam", nam);
                        TinhTongTien();
                    }
                    else if (thang != -1 && nam != -1)
                    {
                        // Truy vấn theo tháng, năm
                        cmd.CommandText = "sp_LayHoaDonTheoThangNam";
                        cmd.Parameters.AddWithValue("@thang", thang);
                        cmd.Parameters.AddWithValue("@nam", nam);
                        TinhTongTien();
                    }
                    else if (nam != -1)
                    {
                        // Truy vấn theo năm
                        cmd.CommandText = "sp_LayHoaDonTheoNam";
                        cmd.Parameters.AddWithValue("@nam", nam);
                        TinhTongTien();
                    }
                    else
                    {
                        // Không có lựa chọn hợp lệ
                        MessageBox.Show("Vui lòng chọn ít nhất một tiêu chí thời gian!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        conn.Open();
                        adapter.Fill(dt);
                    }
                }
            }

            // Kiểm tra nếu không có dữ liệu
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không có hóa đơn nào trong thời gian này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            dataGridView_Thu.DataSource = dt;
            TinhTongTien();
        }

        private void TinhTongTien()
        {
            decimal tongTien = 0;

            // Kiểm tra nếu dataGridView_Thu có dữ liệu
            if (dataGridView_Thu.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridView_Thu.Rows)
                {
                    if (row.Cells["Tổng tiền"].Value != null && row.Cells["Tổng tiền"].Value != DBNull.Value)
                    {
                        tongTien += Convert.ToDecimal(row.Cells["Tổng tiền"].Value);
                    }
                }
            }

            // Hiển thị tổng tiền lên label_TongTien
            label_TongThu.Text = $"TỔNG THU: {tongTien:N0} VND";
        }

        private void button_XoaLuaChon_Click(object sender, EventArgs e)
        {
            // Xóa lựa chọn của tất cả các comboBox
            comboBox_Ngay_Thu.SelectedIndex = -1;
            comboBox_Thang_Thu.SelectedIndex = -1;
            comboBox_Nam_Thu.SelectedIndex = -1;

            dc.loadgridview("v_HoaDon", dataGridView_Thu);
            comboBox_Ngay_Thu.Items.Clear();
            comboBox_Thang_Thu.Items.Clear();
            comboBox_Nam_Thu.Items.Clear();
            for (int i = 1; i <= 31; i++)
                comboBox_Ngay_Thu.Items.Add(i);
            for (int i = 1; i <= 12; i++)
                comboBox_Thang_Thu.Items.Add(i);
            for (int nam = 2000; nam <= DateTime.Now.Year; nam++)
                comboBox_Nam_Thu.Items.Add(nam);
        }
    }
}
