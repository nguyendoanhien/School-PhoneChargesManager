namespace PhoneChargesManager
{
    partial class HoaDon
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
            this.BtnThoat = new System.Windows.Forms.Button();
            this.BtnTimmhd = new System.Windows.Forms.Button();
            this.TbxMahd = new System.Windows.Forms.TextBox();
            this.Data = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Data)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnThoat
            // 
            this.BtnThoat.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnThoat.Location = new System.Drawing.Point(459, 12);
            this.BtnThoat.Name = "BtnThoat";
            this.BtnThoat.Size = new System.Drawing.Size(113, 49);
            this.BtnThoat.TabIndex = 25;
            this.BtnThoat.Text = "Thoát";
            this.BtnThoat.UseVisualStyleBackColor = true;
            this.BtnThoat.Click += new System.EventHandler(this.BtnThoat_Click);
            // 
            // BtnTimmhd
            // 
            this.BtnTimmhd.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnTimmhd.Location = new System.Drawing.Point(218, 12);
            this.BtnTimmhd.Name = "BtnTimmhd";
            this.BtnTimmhd.Size = new System.Drawing.Size(140, 49);
            this.BtnTimmhd.TabIndex = 24;
            this.BtnTimmhd.Text = "Xem Chi Tiết";
            this.BtnTimmhd.UseVisualStyleBackColor = true;
            this.BtnTimmhd.Click += new System.EventHandler(this.BtnTimmhd_Click);
            // 
            // TbxMahd
            // 
            this.TbxMahd.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbxMahd.Location = new System.Drawing.Point(113, 24);
            this.TbxMahd.Name = "TbxMahd";
            this.TbxMahd.ReadOnly = true;
            this.TbxMahd.Size = new System.Drawing.Size(99, 27);
            this.TbxMahd.TabIndex = 23;
            // 
            // Data
            // 
            this.Data.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Data.Location = new System.Drawing.Point(12, 67);
            this.Data.Name = "Data";
            this.Data.Size = new System.Drawing.Size(560, 269);
            this.Data.TabIndex = 22;
            this.Data.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Data_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 19);
            this.label1.TabIndex = 21;
            this.label1.Text = "Mã hóa đơn";
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(364, 12);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(89, 49);
            this.btnBack.TabIndex = 26;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // HoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 347);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.BtnThoat);
            this.Controls.Add(this.BtnTimmhd);
            this.Controls.Add(this.TbxMahd);
            this.Controls.Add(this.Data);
            this.Controls.Add(this.label1);
            this.Name = "HoaDon";
            this.Text = "HoaDon";
            ((System.ComponentModel.ISupportInitialize)(this.Data)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button BtnThoat;
        private System.Windows.Forms.Button BtnTimmhd;
        private System.Windows.Forms.TextBox TbxMahd;
        private System.Windows.Forms.DataGridView Data;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBack;
    }
}