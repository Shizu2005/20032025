namespace baitaplonquanlycuahangbanquanao
{
    partial class f_doanhthu
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
            this.dataGridView_Thu = new System.Windows.Forms.DataGridView();
            this.label_KhoanThu = new System.Windows.Forms.Label();
            this.label_BoLoc_Thu = new System.Windows.Forms.Label();
            this.comboBox_Ngay_Thu = new System.Windows.Forms.ComboBox();
            this.label_Ngay_Thu = new System.Windows.Forms.Label();
            this.label_Thang_Thu = new System.Windows.Forms.Label();
            this.label_Nam_Thu = new System.Windows.Forms.Label();
            this.comboBox_Thang_Thu = new System.Windows.Forms.ComboBox();
            this.comboBox_Nam_Thu = new System.Windows.Forms.ComboBox();
            this.label_TongThu = new System.Windows.Forms.Label();
            this.dataGridView_Chi = new System.Windows.Forms.DataGridView();
            this.comboBox_Nam_Chi = new System.Windows.Forms.ComboBox();
            this.comboBox_Thang_Chi = new System.Windows.Forms.ComboBox();
            this.label_Nam_Chi = new System.Windows.Forms.Label();
            this.label_Thang_Chi = new System.Windows.Forms.Label();
            this.label_Ngay_Chi = new System.Windows.Forms.Label();
            this.comboBox_Ngay_Chi = new System.Windows.Forms.ComboBox();
            this.label_BoLoc_Chi = new System.Windows.Forms.Label();
            this.label_KhoanChi = new System.Windows.Forms.Label();
            this.label_NhapMaHD_Thu = new System.Windows.Forms.Label();
            this.maskedTextBox_NhapMaHD_Thu = new System.Windows.Forms.MaskedTextBox();
            this.button_XemChiTiet_Thu = new System.Windows.Forms.Button();
            this.button_XemChiTiet_Chi = new System.Windows.Forms.Button();
            this.maskedTextBox_NhapMaHD_Chi = new System.Windows.Forms.MaskedTextBox();
            this.label_NhapMaHD_Chi = new System.Windows.Forms.Label();
            this.label_TongChi = new System.Windows.Forms.Label();
            this.label_DoanhThu = new System.Windows.Forms.Label();
            this.button_XoaLuaChon = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Thu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Chi)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_Thu
            // 
            this.dataGridView_Thu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Thu.Location = new System.Drawing.Point(17, 52);
            this.dataGridView_Thu.Name = "dataGridView_Thu";
            this.dataGridView_Thu.RowHeadersWidth = 51;
            this.dataGridView_Thu.RowTemplate.Height = 24;
            this.dataGridView_Thu.Size = new System.Drawing.Size(1038, 332);
            this.dataGridView_Thu.TabIndex = 0;
            // 
            // label_KhoanThu
            // 
            this.label_KhoanThu.AutoSize = true;
            this.label_KhoanThu.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label_KhoanThu.Location = new System.Drawing.Point(12, 20);
            this.label_KhoanThu.Name = "label_KhoanThu";
            this.label_KhoanThu.Size = new System.Drawing.Size(154, 29);
            this.label_KhoanThu.TabIndex = 1;
            this.label_KhoanThu.Text = "KHOẢN THU";
            // 
            // label_BoLoc_Thu
            // 
            this.label_BoLoc_Thu.AutoSize = true;
            this.label_BoLoc_Thu.Location = new System.Drawing.Point(294, 20);
            this.label_BoLoc_Thu.Name = "label_BoLoc_Thu";
            this.label_BoLoc_Thu.Size = new System.Drawing.Size(51, 17);
            this.label_BoLoc_Thu.TabIndex = 2;
            this.label_BoLoc_Thu.Text = "Bộ lọc:";
            // 
            // comboBox_Ngay_Thu
            // 
            this.comboBox_Ngay_Thu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Ngay_Thu.FormattingEnabled = true;
            this.comboBox_Ngay_Thu.Location = new System.Drawing.Point(415, 17);
            this.comboBox_Ngay_Thu.Name = "comboBox_Ngay_Thu";
            this.comboBox_Ngay_Thu.Size = new System.Drawing.Size(81, 24);
            this.comboBox_Ngay_Thu.TabIndex = 3;
            this.comboBox_Ngay_Thu.SelectedIndexChanged += new System.EventHandler(this.comboBox_Ngay_Thu_SelectedIndexChanged);
            // 
            // label_Ngay_Thu
            // 
            this.label_Ngay_Thu.AutoSize = true;
            this.label_Ngay_Thu.Location = new System.Drawing.Point(368, 20);
            this.label_Ngay_Thu.Name = "label_Ngay_Thu";
            this.label_Ngay_Thu.Size = new System.Drawing.Size(41, 17);
            this.label_Ngay_Thu.TabIndex = 4;
            this.label_Ngay_Thu.Text = "Ngày";
            // 
            // label_Thang_Thu
            // 
            this.label_Thang_Thu.AutoSize = true;
            this.label_Thang_Thu.Location = new System.Drawing.Point(514, 20);
            this.label_Thang_Thu.Name = "label_Thang_Thu";
            this.label_Thang_Thu.Size = new System.Drawing.Size(49, 17);
            this.label_Thang_Thu.TabIndex = 5;
            this.label_Thang_Thu.Text = "Tháng";
            // 
            // label_Nam_Thu
            // 
            this.label_Nam_Thu.AutoSize = true;
            this.label_Nam_Thu.Location = new System.Drawing.Point(672, 20);
            this.label_Nam_Thu.Name = "label_Nam_Thu";
            this.label_Nam_Thu.Size = new System.Drawing.Size(37, 17);
            this.label_Nam_Thu.TabIndex = 6;
            this.label_Nam_Thu.Text = "Năm";
            // 
            // comboBox_Thang_Thu
            // 
            this.comboBox_Thang_Thu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Thang_Thu.FormattingEnabled = true;
            this.comboBox_Thang_Thu.Location = new System.Drawing.Point(569, 16);
            this.comboBox_Thang_Thu.Name = "comboBox_Thang_Thu";
            this.comboBox_Thang_Thu.Size = new System.Drawing.Size(81, 24);
            this.comboBox_Thang_Thu.TabIndex = 7;
            this.comboBox_Thang_Thu.SelectedIndexChanged += new System.EventHandler(this.comboBox_Thang_Thu_SelectedIndexChanged);
            // 
            // comboBox_Nam_Thu
            // 
            this.comboBox_Nam_Thu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Nam_Thu.FormattingEnabled = true;
            this.comboBox_Nam_Thu.Location = new System.Drawing.Point(715, 16);
            this.comboBox_Nam_Thu.Name = "comboBox_Nam_Thu";
            this.comboBox_Nam_Thu.Size = new System.Drawing.Size(81, 24);
            this.comboBox_Nam_Thu.TabIndex = 8;
            this.comboBox_Nam_Thu.SelectedIndexChanged += new System.EventHandler(this.comboBox_Nam_Thu_SelectedIndexChanged);
            // 
            // label_TongThu
            // 
            this.label_TongThu.AutoSize = true;
            this.label_TongThu.Location = new System.Drawing.Point(880, 403);
            this.label_TongThu.Name = "label_TongThu";
            this.label_TongThu.Size = new System.Drawing.Size(86, 17);
            this.label_TongThu.TabIndex = 12;
            this.label_TongThu.Text = "TỔNG THU:";
            // 
            // dataGridView_Chi
            // 
            this.dataGridView_Chi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Chi.Location = new System.Drawing.Point(17, 503);
            this.dataGridView_Chi.Name = "dataGridView_Chi";
            this.dataGridView_Chi.RowHeadersWidth = 51;
            this.dataGridView_Chi.RowTemplate.Height = 24;
            this.dataGridView_Chi.Size = new System.Drawing.Size(1038, 332);
            this.dataGridView_Chi.TabIndex = 13;
            // 
            // comboBox_Nam_Chi
            // 
            this.comboBox_Nam_Chi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Nam_Chi.FormattingEnabled = true;
            this.comboBox_Nam_Chi.Items.AddRange(new object[] {
            "2015",
            "2016",
            "2017",
            "2018",
            "2019",
            "2020",
            "2021",
            "2022",
            "2023",
            "2024",
            "2025"});
            this.comboBox_Nam_Chi.Location = new System.Drawing.Point(715, 467);
            this.comboBox_Nam_Chi.Name = "comboBox_Nam_Chi";
            this.comboBox_Nam_Chi.Size = new System.Drawing.Size(81, 24);
            this.comboBox_Nam_Chi.TabIndex = 21;
            // 
            // comboBox_Thang_Chi
            // 
            this.comboBox_Thang_Chi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Thang_Chi.FormattingEnabled = true;
            this.comboBox_Thang_Chi.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.comboBox_Thang_Chi.Location = new System.Drawing.Point(569, 467);
            this.comboBox_Thang_Chi.Name = "comboBox_Thang_Chi";
            this.comboBox_Thang_Chi.Size = new System.Drawing.Size(81, 24);
            this.comboBox_Thang_Chi.TabIndex = 20;
            // 
            // label_Nam_Chi
            // 
            this.label_Nam_Chi.AutoSize = true;
            this.label_Nam_Chi.Location = new System.Drawing.Point(672, 471);
            this.label_Nam_Chi.Name = "label_Nam_Chi";
            this.label_Nam_Chi.Size = new System.Drawing.Size(37, 17);
            this.label_Nam_Chi.TabIndex = 19;
            this.label_Nam_Chi.Text = "Năm";
            // 
            // label_Thang_Chi
            // 
            this.label_Thang_Chi.AutoSize = true;
            this.label_Thang_Chi.Location = new System.Drawing.Point(514, 471);
            this.label_Thang_Chi.Name = "label_Thang_Chi";
            this.label_Thang_Chi.Size = new System.Drawing.Size(49, 17);
            this.label_Thang_Chi.TabIndex = 18;
            this.label_Thang_Chi.Text = "Tháng";
            // 
            // label_Ngay_Chi
            // 
            this.label_Ngay_Chi.AutoSize = true;
            this.label_Ngay_Chi.Location = new System.Drawing.Point(368, 471);
            this.label_Ngay_Chi.Name = "label_Ngay_Chi";
            this.label_Ngay_Chi.Size = new System.Drawing.Size(41, 17);
            this.label_Ngay_Chi.TabIndex = 17;
            this.label_Ngay_Chi.Text = "Ngày";
            // 
            // comboBox_Ngay_Chi
            // 
            this.comboBox_Ngay_Chi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Ngay_Chi.FormattingEnabled = true;
            this.comboBox_Ngay_Chi.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31"});
            this.comboBox_Ngay_Chi.Location = new System.Drawing.Point(415, 468);
            this.comboBox_Ngay_Chi.Name = "comboBox_Ngay_Chi";
            this.comboBox_Ngay_Chi.Size = new System.Drawing.Size(81, 24);
            this.comboBox_Ngay_Chi.TabIndex = 16;
            // 
            // label_BoLoc_Chi
            // 
            this.label_BoLoc_Chi.AutoSize = true;
            this.label_BoLoc_Chi.Location = new System.Drawing.Point(294, 471);
            this.label_BoLoc_Chi.Name = "label_BoLoc_Chi";
            this.label_BoLoc_Chi.Size = new System.Drawing.Size(51, 17);
            this.label_BoLoc_Chi.TabIndex = 15;
            this.label_BoLoc_Chi.Text = "Bộ lọc:";
            // 
            // label_KhoanChi
            // 
            this.label_KhoanChi.AutoSize = true;
            this.label_KhoanChi.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label_KhoanChi.Location = new System.Drawing.Point(12, 471);
            this.label_KhoanChi.Name = "label_KhoanChi";
            this.label_KhoanChi.Size = new System.Drawing.Size(144, 29);
            this.label_KhoanChi.TabIndex = 14;
            this.label_KhoanChi.Text = "KHOẢN CHI";
            // 
            // label_NhapMaHD_Thu
            // 
            this.label_NhapMaHD_Thu.AutoSize = true;
            this.label_NhapMaHD_Thu.Location = new System.Drawing.Point(17, 403);
            this.label_NhapMaHD_Thu.Name = "label_NhapMaHD_Thu";
            this.label_NhapMaHD_Thu.Size = new System.Drawing.Size(125, 17);
            this.label_NhapMaHD_Thu.TabIndex = 23;
            this.label_NhapMaHD_Thu.Text = "Nhập mã hóa đơn:";
            // 
            // maskedTextBox_NhapMaHD_Thu
            // 
            this.maskedTextBox_NhapMaHD_Thu.Location = new System.Drawing.Point(149, 403);
            this.maskedTextBox_NhapMaHD_Thu.Mask = "HD00";
            this.maskedTextBox_NhapMaHD_Thu.Name = "maskedTextBox_NhapMaHD_Thu";
            this.maskedTextBox_NhapMaHD_Thu.Size = new System.Drawing.Size(72, 22);
            this.maskedTextBox_NhapMaHD_Thu.TabIndex = 24;
            // 
            // button_XemChiTiet_Thu
            // 
            this.button_XemChiTiet_Thu.Location = new System.Drawing.Point(256, 396);
            this.button_XemChiTiet_Thu.Name = "button_XemChiTiet_Thu";
            this.button_XemChiTiet_Thu.Size = new System.Drawing.Size(99, 36);
            this.button_XemChiTiet_Thu.TabIndex = 25;
            this.button_XemChiTiet_Thu.Text = "Xem chi tiết";
            this.button_XemChiTiet_Thu.UseVisualStyleBackColor = true;
            // 
            // button_XemChiTiet_Chi
            // 
            this.button_XemChiTiet_Chi.Location = new System.Drawing.Point(256, 850);
            this.button_XemChiTiet_Chi.Name = "button_XemChiTiet_Chi";
            this.button_XemChiTiet_Chi.Size = new System.Drawing.Size(99, 36);
            this.button_XemChiTiet_Chi.TabIndex = 29;
            this.button_XemChiTiet_Chi.Text = "Xem chi tiết";
            this.button_XemChiTiet_Chi.UseVisualStyleBackColor = true;
            // 
            // maskedTextBox_NhapMaHD_Chi
            // 
            this.maskedTextBox_NhapMaHD_Chi.Location = new System.Drawing.Point(149, 857);
            this.maskedTextBox_NhapMaHD_Chi.Mask = "NH00";
            this.maskedTextBox_NhapMaHD_Chi.Name = "maskedTextBox_NhapMaHD_Chi";
            this.maskedTextBox_NhapMaHD_Chi.Size = new System.Drawing.Size(72, 22);
            this.maskedTextBox_NhapMaHD_Chi.TabIndex = 28;
            // 
            // label_NhapMaHD_Chi
            // 
            this.label_NhapMaHD_Chi.AutoSize = true;
            this.label_NhapMaHD_Chi.Location = new System.Drawing.Point(17, 857);
            this.label_NhapMaHD_Chi.Name = "label_NhapMaHD_Chi";
            this.label_NhapMaHD_Chi.Size = new System.Drawing.Size(125, 17);
            this.label_NhapMaHD_Chi.TabIndex = 27;
            this.label_NhapMaHD_Chi.Text = "Nhập mã hóa đơn:";
            // 
            // label_TongChi
            // 
            this.label_TongChi.AutoSize = true;
            this.label_TongChi.Location = new System.Drawing.Point(880, 857);
            this.label_TongChi.Name = "label_TongChi";
            this.label_TongChi.Size = new System.Drawing.Size(79, 17);
            this.label_TongChi.TabIndex = 26;
            this.label_TongChi.Text = "TỔNG CHI:";
            // 
            // label_DoanhThu
            // 
            this.label_DoanhThu.AutoSize = true;
            this.label_DoanhThu.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label_DoanhThu.Location = new System.Drawing.Point(798, 900);
            this.label_DoanhThu.Name = "label_DoanhThu";
            this.label_DoanhThu.Size = new System.Drawing.Size(161, 29);
            this.label_DoanhThu.TabIndex = 30;
            this.label_DoanhThu.Text = "DOANH THU:";
            // 
            // button_XoaLuaChon
            // 
            this.button_XoaLuaChon.Location = new System.Drawing.Point(850, 12);
            this.button_XoaLuaChon.Name = "button_XoaLuaChon";
            this.button_XoaLuaChon.Size = new System.Drawing.Size(109, 32);
            this.button_XoaLuaChon.TabIndex = 31;
            this.button_XoaLuaChon.Text = "Xóa lựa chọn";
            this.button_XoaLuaChon.UseVisualStyleBackColor = true;
            this.button_XoaLuaChon.Click += new System.EventHandler(this.button_XoaLuaChon_Click);
            // 
            // f_doanhthu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1067, 942);
            this.Controls.Add(this.button_XoaLuaChon);
            this.Controls.Add(this.label_DoanhThu);
            this.Controls.Add(this.button_XemChiTiet_Chi);
            this.Controls.Add(this.maskedTextBox_NhapMaHD_Chi);
            this.Controls.Add(this.label_NhapMaHD_Chi);
            this.Controls.Add(this.label_TongChi);
            this.Controls.Add(this.button_XemChiTiet_Thu);
            this.Controls.Add(this.maskedTextBox_NhapMaHD_Thu);
            this.Controls.Add(this.label_NhapMaHD_Thu);
            this.Controls.Add(this.comboBox_Nam_Chi);
            this.Controls.Add(this.comboBox_Thang_Chi);
            this.Controls.Add(this.label_Nam_Chi);
            this.Controls.Add(this.label_Thang_Chi);
            this.Controls.Add(this.label_Ngay_Chi);
            this.Controls.Add(this.comboBox_Ngay_Chi);
            this.Controls.Add(this.label_BoLoc_Chi);
            this.Controls.Add(this.label_KhoanChi);
            this.Controls.Add(this.dataGridView_Chi);
            this.Controls.Add(this.label_TongThu);
            this.Controls.Add(this.comboBox_Nam_Thu);
            this.Controls.Add(this.comboBox_Thang_Thu);
            this.Controls.Add(this.label_Nam_Thu);
            this.Controls.Add(this.label_Thang_Thu);
            this.Controls.Add(this.label_Ngay_Thu);
            this.Controls.Add(this.comboBox_Ngay_Thu);
            this.Controls.Add(this.label_BoLoc_Thu);
            this.Controls.Add(this.label_KhoanThu);
            this.Controls.Add(this.dataGridView_Thu);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "f_doanhthu";
            this.Text = "Doanh thu";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Thu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Chi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_Thu;
        private System.Windows.Forms.Label label_KhoanThu;
        private System.Windows.Forms.Label label_BoLoc_Thu;
        private System.Windows.Forms.ComboBox comboBox_Ngay_Thu;
        private System.Windows.Forms.Label label_Ngay_Thu;
        private System.Windows.Forms.Label label_Thang_Thu;
        private System.Windows.Forms.Label label_Nam_Thu;
        private System.Windows.Forms.ComboBox comboBox_Thang_Thu;
        private System.Windows.Forms.ComboBox comboBox_Nam_Thu;
        private System.Windows.Forms.Label label_TongThu;
        private System.Windows.Forms.DataGridView dataGridView_Chi;
        private System.Windows.Forms.ComboBox comboBox_Nam_Chi;
        private System.Windows.Forms.ComboBox comboBox_Thang_Chi;
        private System.Windows.Forms.Label label_Nam_Chi;
        private System.Windows.Forms.Label label_Thang_Chi;
        private System.Windows.Forms.Label label_Ngay_Chi;
        private System.Windows.Forms.ComboBox comboBox_Ngay_Chi;
        private System.Windows.Forms.Label label_BoLoc_Chi;
        private System.Windows.Forms.Label label_KhoanChi;
        private System.Windows.Forms.Label label_NhapMaHD_Thu;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_NhapMaHD_Thu;
        private System.Windows.Forms.Button button_XemChiTiet_Thu;
        private System.Windows.Forms.Button button_XemChiTiet_Chi;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_NhapMaHD_Chi;
        private System.Windows.Forms.Label label_NhapMaHD_Chi;
        private System.Windows.Forms.Label label_TongChi;
        private System.Windows.Forms.Label label_DoanhThu;
        private System.Windows.Forms.Button button_XoaLuaChon;
    }
}