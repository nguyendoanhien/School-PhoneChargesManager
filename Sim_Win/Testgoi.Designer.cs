namespace PhoneChargesManager
{
    partial class Testgoi
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxStart = new System.Windows.Forms.TextBox();
            this.txbEnd = new System.Windows.Forms.TextBox();
            this.btnCall = new System.Windows.Forms.Button();
            this.btnEnd = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tbxName = new System.Windows.Forms.TextBox();
            this.btnghi = new System.Windows.Forms.Button();
            this.cbxNumbers = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Số điện thoại";
            // 
            // tbxStart
            // 
            this.tbxStart.Enabled = false;
            this.tbxStart.Location = new System.Drawing.Point(15, 53);
            this.tbxStart.Name = "tbxStart";
            this.tbxStart.Size = new System.Drawing.Size(185, 20);
            this.tbxStart.TabIndex = 3;
            // 
            // txbEnd
            // 
            this.txbEnd.Enabled = false;
            this.txbEnd.Location = new System.Drawing.Point(15, 85);
            this.txbEnd.Name = "txbEnd";
            this.txbEnd.Size = new System.Drawing.Size(185, 20);
            this.txbEnd.TabIndex = 4;
            // 
            // btnCall
            // 
            this.btnCall.Location = new System.Drawing.Point(226, 53);
            this.btnCall.Name = "btnCall";
            this.btnCall.Size = new System.Drawing.Size(75, 23);
            this.btnCall.TabIndex = 6;
            this.btnCall.Text = "Gọi";
            this.btnCall.UseVisualStyleBackColor = true;
            this.btnCall.Click += new System.EventHandler(this.btnCall_Click);
            // 
            // btnEnd
            // 
            this.btnEnd.Location = new System.Drawing.Point(226, 82);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(75, 23);
            this.btnEnd.TabIndex = 7;
            this.btnEnd.Text = "Kết thúc";
            this.btnEnd.UseVisualStyleBackColor = true;
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tbxName
            // 
            this.tbxName.Enabled = false;
            this.tbxName.Location = new System.Drawing.Point(12, 114);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(188, 20);
            this.tbxName.TabIndex = 8;
            // 
            // btnghi
            // 
            this.btnghi.Location = new System.Drawing.Point(226, 111);
            this.btnghi.Name = "btnghi";
            this.btnghi.Size = new System.Drawing.Size(75, 23);
            this.btnghi.TabIndex = 9;
            this.btnghi.Text = "Ghi file";
            this.btnghi.UseVisualStyleBackColor = true;
            this.btnghi.Click += new System.EventHandler(this.btnghi_Click);
            // 
            // cbxNumbers
            // 
            this.cbxNumbers.FormattingEnabled = true;
            this.cbxNumbers.Location = new System.Drawing.Point(88, 24);
            this.cbxNumbers.Name = "cbxNumbers";
            this.cbxNumbers.Size = new System.Drawing.Size(213, 21);
            this.cbxNumbers.TabIndex = 10;
            // 
            // Testgoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 173);
            this.Controls.Add(this.cbxNumbers);
            this.Controls.Add(this.btnghi);
            this.Controls.Add(this.tbxName);
            this.Controls.Add(this.btnEnd);
            this.Controls.Add(this.btnCall);
            this.Controls.Add(this.txbEnd);
            this.Controls.Add(this.tbxStart);
            this.Controls.Add(this.label1);
            this.Name = "Testgoi";
            this.Text = "Testgoi";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxStart;
        private System.Windows.Forms.TextBox txbEnd;
        private System.Windows.Forms.Button btnCall;
        private System.Windows.Forms.Button btnEnd;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox tbxName;
        private System.Windows.Forms.Button btnghi;
        private System.Windows.Forms.ComboBox cbxNumbers;
    }
}