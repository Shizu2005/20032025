namespace baitaplonquanlycuahangbanquanao
{
    partial class f_doanhthu_thu
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
            this.dataGridView_chitiethoadon = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_chitiethoadon)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_chitiethoadon
            // 
            this.dataGridView_chitiethoadon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_chitiethoadon.Location = new System.Drawing.Point(12, 11);
            this.dataGridView_chitiethoadon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView_chitiethoadon.Name = "dataGridView_chitiethoadon";
            this.dataGridView_chitiethoadon.RowHeadersWidth = 51;
            this.dataGridView_chitiethoadon.RowTemplate.Height = 24;
            this.dataGridView_chitiethoadon.Size = new System.Drawing.Size(1123, 428);
            this.dataGridView_chitiethoadon.TabIndex = 2;
            // 
            // f_doanhthu_thu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1147, 450);
            this.Controls.Add(this.dataGridView_chitiethoadon);
            this.Name = "f_doanhthu_thu";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.f_doanhthu_thu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_chitiethoadon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_chitiethoadon;
    }
}