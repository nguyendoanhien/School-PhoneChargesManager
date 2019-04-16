namespace PhoneChargesManager
{
    partial class Mainform
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
            this.btn_KH = new System.Windows.Forms.Button();
            this.btn_HD = new System.Windows.Forms.Button();
            this.btn_Sim = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_KH
            // 
            this.btn_KH.BackColor = System.Drawing.Color.Tomato;
            this.btn_KH.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_KH.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btn_KH.Location = new System.Drawing.Point(28, 86);
            this.btn_KH.Name = "btn_KH";
            this.btn_KH.Size = new System.Drawing.Size(461, 102);
            this.btn_KH.TabIndex = 0;
            this.btn_KH.Text = "KHÁCH HÀNG";
            this.btn_KH.UseVisualStyleBackColor = false;
            this.btn_KH.Click += new System.EventHandler(this.btn_KH_Click);
            // 
            // btn_HD
            // 
            this.btn_HD.BackColor = System.Drawing.Color.RosyBrown;
            this.btn_HD.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_HD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btn_HD.Location = new System.Drawing.Point(28, 230);
            this.btn_HD.Name = "btn_HD";
            this.btn_HD.Size = new System.Drawing.Size(461, 93);
            this.btn_HD.TabIndex = 1;
            this.btn_HD.Text = "HÓA ĐƠN";
            this.btn_HD.UseVisualStyleBackColor = false;
            this.btn_HD.Click += new System.EventHandler(this.btn_HD_Click);
            // 
            // btn_Sim
            // 
            this.btn_Sim.BackColor = System.Drawing.Color.IndianRed;
            this.btn_Sim.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Sim.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_Sim.Location = new System.Drawing.Point(538, 86);
            this.btn_Sim.Name = "btn_Sim";
            this.btn_Sim.Size = new System.Drawing.Size(486, 102);
            this.btn_Sim.TabIndex = 2;
            this.btn_Sim.Text = "SIM";
            this.btn_Sim.UseVisualStyleBackColor = false;
            this.btn_Sim.Click += new System.EventHandler(this.btn_Sim_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.RosyBrown;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.button2.Location = new System.Drawing.Point(538, 230);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(486, 93);
            this.button2.TabIndex = 4;
            this.button2.Text = "THOÁT";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Mainform
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Grip;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btn_Sim);
            this.Controls.Add(this.btn_HD);
            this.Controls.Add(this.btn_KH);
            this.Name = "Mainform";
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_KH;
        private System.Windows.Forms.Button btn_HD;
        private System.Windows.Forms.Button btn_Sim;
        private System.Windows.Forms.Button button2;
    }
}

