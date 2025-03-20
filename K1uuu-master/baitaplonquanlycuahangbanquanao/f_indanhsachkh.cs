using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
using System.Configuration;

namespace baitaplonquanlycuahangbanquanao
{
    public partial class f_indanhsachkh : Form
    {
        public f_indanhsachkh()
        {
            InitializeComponent();
        }
        string constr = ConfigurationManager.ConnectionStrings["baitaplonquanlycuahangbanquanao"].ToString();
        private void f_indanhsachkh_Load(object sender, EventArgs e)
        {
            LoadReport();
        }
        public void LoadReport()
        {
            try
            {
                // Tạo đối tượng báo cáo
                ReportDocument report = new ReportDocument();

                // Đường dẫn tới file báo cáo .rpt
                string reportPath = @"C:\Users\PC\Downloads\BTL_HSK\K1uuu-master\baitaplonquanlycuahangbanquanao\CR_dsKh.rpt";
                report.Load(reportPath);

                // Nếu dùng dataset, bạn có thể gán dữ liệu vào report
                // DataSet ds = GetKhoHangData();
                // report.SetDataSource(ds);

                // Gán báo cáo vào CrystalReportViewer
                crystalReportViewer_dsKhachHang.ReportSource = report;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải báo cáo: " + ex.Message);
            }
        }

        private void button_indskh_Click(object sender, EventArgs e)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cnn;
                    cmd.CommandText = "proc_LayKhachHangTheoNgayDatHang";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Thang", textBox_thangdathang.Text);
                    cmd.Parameters.AddWithValue("@Nam", textBox_NamDatHang.Text);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        CR_dsKh rpt = new CR_dsKh();
                        rpt.SetDataSource(dt);
                        crystalReportViewer_dsKhachHang.ReportSource = rpt;
                        crystalReportViewer_dsKhachHang.Refresh();
                    }
                }

            }
        }
    }
}
