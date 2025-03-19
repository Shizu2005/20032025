namespace baitaplonquanlycuahangbanquanao
{
    partial class f_hanghoa
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
            this.dgv_HangHoaTonKho = new System.Windows.Forms.DataGridView();
            this.txtDanhSachTonKho = new System.Windows.Forms.Label();
            this.btn_TimKiemTonKho = new System.Windows.Forms.Button();
            this.txtTimKiemID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTimKiemMH = new System.Windows.Forms.TextBox();
            this.txtTimKiemGiaBan = new System.Windows.Forms.TextBox();
            this.txtTimKiemSoLuongTon = new System.Windows.Forms.TextBox();
            this.btn_ResetKhoHang = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.txtTimKiemLoaiHang = new System.Windows.Forms.TextBox();
            this.txtSize = new System.Windows.Forms.TextBox();
            this.txtMauSac = new System.Windows.Forms.TextBox();
            this.txtTimKiemGiaNhap = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btn_Xoa = new System.Windows.Forms.Button();
            this.txtChatLieu = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_HangHoaTonKho)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_HangHoaTonKho
            // 
            this.dgv_HangHoaTonKho.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_HangHoaTonKho.Location = new System.Drawing.Point(11, 40);
            this.dgv_HangHoaTonKho.Name = "dgv_HangHoaTonKho";
            this.dgv_HangHoaTonKho.RowHeadersWidth = 51;
            this.dgv_HangHoaTonKho.RowTemplate.Height = 24;
            this.dgv_HangHoaTonKho.Size = new System.Drawing.Size(957, 282);
            this.dgv_HangHoaTonKho.TabIndex = 10;
            this.dgv_HangHoaTonKho.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_HangHoaTonKho_CellContentClick);
            // 
            // txtDanhSachTonKho
            // 
            this.txtDanhSachTonKho.AutoSize = true;
            this.txtDanhSachTonKho.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtDanhSachTonKho.Location = new System.Drawing.Point(3, 8);
            this.txtDanhSachTonKho.Name = "txtDanhSachTonKho";
            this.txtDanhSachTonKho.Size = new System.Drawing.Size(341, 29);
            this.txtDanhSachTonKho.TabIndex = 2;
            this.txtDanhSachTonKho.Text = "Danh sách sản phẩm trong kho";
            // 
            // btn_TimKiemTonKho
            // 
            this.btn_TimKiemTonKho.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btn_TimKiemTonKho.Location = new System.Drawing.Point(974, 257);
            this.btn_TimKiemTonKho.Name = "btn_TimKiemTonKho";
            this.btn_TimKiemTonKho.Size = new System.Drawing.Size(86, 32);
            this.btn_TimKiemTonKho.TabIndex = 3;
            this.btn_TimKiemTonKho.Text = "Tìm Kiếm";
            this.btn_TimKiemTonKho.UseVisualStyleBackColor = true;
            this.btn_TimKiemTonKho.Click += new System.EventHandler(this.btn_TimKiemTonKho_Click);
            // 
            // txtTimKiemID
            // 
            this.txtTimKiemID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtTimKiemID.Location = new System.Drawing.Point(112, 328);
            this.txtTimKiemID.Name = "txtTimKiemID";
            this.txtTimKiemID.Size = new System.Drawing.Size(213, 24);
            this.txtTimKiemID.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(38, 331);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "Mã Hàng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(5, 362);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "Tên Mặt Hàng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(359, 364);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 18);
            this.label3.TabIndex = 7;
            this.label3.Text = "Giá Bán";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.Location = new System.Drawing.Point(345, 331);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 18);
            this.label4.TabIndex = 8;
            this.label4.Text = "Loại Hàng";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.Location = new System.Drawing.Point(4, 391);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 18);
            this.label5.TabIndex = 9;
            this.label5.Text = "Số Lượng Tồn";
            // 
            // txtTimKiemMH
            // 
            this.txtTimKiemMH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtTimKiemMH.Location = new System.Drawing.Point(112, 358);
            this.txtTimKiemMH.Name = "txtTimKiemMH";
            this.txtTimKiemMH.Size = new System.Drawing.Size(213, 24);
            this.txtTimKiemMH.TabIndex = 10;
            // 
            // txtTimKiemGiaBan
            // 
            this.txtTimKiemGiaBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtTimKiemGiaBan.Location = new System.Drawing.Point(426, 356);
            this.txtTimKiemGiaBan.Name = "txtTimKiemGiaBan";
            this.txtTimKiemGiaBan.Size = new System.Drawing.Size(203, 24);
            this.txtTimKiemGiaBan.TabIndex = 11;
            // 
            // txtTimKiemSoLuongTon
            // 
            this.txtTimKiemSoLuongTon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtTimKiemSoLuongTon.Location = new System.Drawing.Point(112, 388);
            this.txtTimKiemSoLuongTon.Name = "txtTimKiemSoLuongTon";
            this.txtTimKiemSoLuongTon.Size = new System.Drawing.Size(213, 24);
            this.txtTimKiemSoLuongTon.TabIndex = 13;
            // 
            // btn_ResetKhoHang
            // 
            this.btn_ResetKhoHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btn_ResetKhoHang.Location = new System.Drawing.Point(974, 186);
            this.btn_ResetKhoHang.Name = "btn_ResetKhoHang";
            this.btn_ResetKhoHang.Size = new System.Drawing.Size(86, 30);
            this.btn_ResetKhoHang.TabIndex = 14;
            this.btn_ResetKhoHang.Text = "Reset";
            this.btn_ResetKhoHang.UseVisualStyleBackColor = true;
            this.btn_ResetKhoHang.Click += new System.EventHandler(this.btn_ResetKhoHang_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgv_HangHoaTonKho);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.txtTimKiemLoaiHang);
            this.panel1.Controls.Add(this.txtSize);
            this.panel1.Controls.Add(this.txtMauSac);
            this.panel1.Controls.Add(this.txtTimKiemGiaNhap);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.btn_Xoa);
            this.panel1.Controls.Add(this.txtChatLieu);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.btn_ResetKhoHang);
            this.panel1.Controls.Add(this.txtTimKiemSoLuongTon);
            this.panel1.Controls.Add(this.txtTimKiemGiaBan);
            this.panel1.Controls.Add(this.txtTimKiemMH);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btn_TimKiemTonKho);
            this.panel1.Controls.Add(this.txtDanhSachTonKho);
            this.panel1.Controls.Add(this.txtTimKiemID);
            this.panel1.Location = new System.Drawing.Point(-1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1068, 491);
            this.panel1.TabIndex = 11;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.button2.Location = new System.Drawing.Point(974, 40);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(86, 50);
            this.button2.TabIndex = 29;
            this.button2.Text = "In Kho Hàng";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtTimKiemLoaiHang
            // 
            this.txtTimKiemLoaiHang.Location = new System.Drawing.Point(426, 328);
            this.txtTimKiemLoaiHang.Name = "txtTimKiemLoaiHang";
            this.txtTimKiemLoaiHang.Size = new System.Drawing.Size(203, 22);
            this.txtTimKiemLoaiHang.TabIndex = 27;
            // 
            // txtSize
            // 
            this.txtSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtSize.Location = new System.Drawing.Point(767, 328);
            this.txtSize.Name = "txtSize";
            this.txtSize.Size = new System.Drawing.Size(198, 24);
            this.txtSize.TabIndex = 26;
            // 
            // txtMauSac
            // 
            this.txtMauSac.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtMauSac.Location = new System.Drawing.Point(767, 358);
            this.txtMauSac.Name = "txtMauSac";
            this.txtMauSac.Size = new System.Drawing.Size(198, 24);
            this.txtMauSac.TabIndex = 25;
            // 
            // txtTimKiemGiaNhap
            // 
            this.txtTimKiemGiaNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtTimKiemGiaNhap.Location = new System.Drawing.Point(426, 388);
            this.txtTimKiemGiaNhap.Name = "txtTimKiemGiaNhap";
            this.txtTimKiemGiaNhap.Size = new System.Drawing.Size(203, 24);
            this.txtTimKiemGiaNhap.TabIndex = 24;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label9.Location = new System.Drawing.Point(350, 391);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 18);
            this.label9.TabIndex = 23;
            this.label9.Text = "Giá Nhập";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label8.Location = new System.Drawing.Point(696, 361);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 18);
            this.label8.TabIndex = 21;
            this.label8.Text = "Màu sắc";
            // 
            // btn_Xoa
            // 
            this.btn_Xoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btn_Xoa.Location = new System.Drawing.Point(974, 120);
            this.btn_Xoa.Name = "btn_Xoa";
            this.btn_Xoa.Size = new System.Drawing.Size(86, 30);
            this.btn_Xoa.TabIndex = 19;
            this.btn_Xoa.Text = "Xóa ";
            this.btn_Xoa.UseVisualStyleBackColor = true;
            this.btn_Xoa.Click += new System.EventHandler(this.btn_Xoa_Click);
            // 
            // txtChatLieu
            // 
            this.txtChatLieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtChatLieu.Location = new System.Drawing.Point(767, 388);
            this.txtChatLieu.Name = "txtChatLieu";
            this.txtChatLieu.Size = new System.Drawing.Size(198, 24);
            this.txtChatLieu.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label7.Location = new System.Drawing.Point(696, 391);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 18);
            this.label7.TabIndex = 16;
            this.label7.Text = "Chất liệu";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label6.Location = new System.Drawing.Point(724, 331);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 18);
            this.label6.TabIndex = 15;
            this.label6.Text = "Size";
            // 
            // f_hanghoa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 490);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "f_hanghoa";
            this.Text = "Hàng hoá";
            this.Load += new System.EventHandler(this.f_hanghoa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_HangHoaTonKho)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_HangHoaTonKho;
        private System.Windows.Forms.Label txtDanhSachTonKho;
        private System.Windows.Forms.Button btn_TimKiemTonKho;
        private System.Windows.Forms.TextBox txtTimKiemID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTimKiemMH;
        private System.Windows.Forms.TextBox txtTimKiemGiaBan;
        private System.Windows.Forms.TextBox txtTimKiemSoLuongTon;
        private System.Windows.Forms.Button btn_ResetKhoHang;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtChatLieu;
        private System.Windows.Forms.Button btn_Xoa;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTimKiemGiaNhap;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtSize;
        private System.Windows.Forms.TextBox txtMauSac;
        private System.Windows.Forms.TextBox txtTimKiemLoaiHang;
        private System.Windows.Forms.Button button2;
    }
}