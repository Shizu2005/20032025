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
using CrystalDecisions.Shared;


namespace baitaplonquanlycuahangbanquanao
{
    public partial class f_CRKhoHang : Form
    {
        public f_CRKhoHang()
        {
            InitializeComponent();
        }
        public void LoadReport()
        {
            try
            {
                // Tạo đối tượng báo cáo
                ReportDocument report = new ReportDocument();

                // Đường dẫn tới file báo cáo .rpt
                string reportPath = @"C:\Users\PC\Downloads\BTL_HSK\K1uuu-master\baitaplonquanlycuahangbanquanao\CRKhoHang.rpt";
                report.Load(reportPath);

                // Nếu dùng dataset, bạn có thể gán dữ liệu vào report
                // DataSet ds = GetKhoHangData();
                // report.SetDataSource(ds);

                // Gán báo cáo vào CrystalReportViewer
                crystalReportViewer1.ReportSource = report;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải báo cáo: " + ex.Message);
            }
        }

        private void f_CRKhoHang_Load(object sender, EventArgs e)
        {
            LoadReport();
        }
    }
}

