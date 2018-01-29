namespace QLTHI_TTTINHOC
{
    partial class fcauhinh
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
            this.bHuy = new System.Windows.Forms.Button();
            this.bLuu = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.cboDataBase = new System.Windows.Forms.ComboBox();
            this.cboServer = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bHuy
            // 
            this.bHuy.Location = new System.Drawing.Point(292, 199);
            this.bHuy.Name = "bHuy";
            this.bHuy.Size = new System.Drawing.Size(75, 23);
            this.bHuy.TabIndex = 22;
            this.bHuy.Text = "Hủy bỏ";
            this.bHuy.UseVisualStyleBackColor = true;
            // 
            // bLuu
            // 
            this.bLuu.Location = new System.Drawing.Point(171, 199);
            this.bLuu.Name = "bLuu";
            this.bLuu.Size = new System.Drawing.Size(75, 23);
            this.bLuu.TabIndex = 23;
            this.bLuu.Text = "Lưu lại";
            this.bLuu.UseVisualStyleBackColor = true;
            this.bLuu.Click += new System.EventHandler(this.bLuu_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(214, 93);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(153, 20);
            this.textBox2.TabIndex = 20;
            this.textBox2.UseSystemPasswordChar = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(214, 67);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(153, 20);
            this.textBox1.TabIndex = 21;
            // 
            // cboDataBase
            // 
            this.cboDataBase.FormattingEnabled = true;
            this.cboDataBase.Location = new System.Drawing.Point(214, 122);
            this.cboDataBase.Name = "cboDataBase";
            this.cboDataBase.Size = new System.Drawing.Size(153, 21);
            this.cboDataBase.TabIndex = 18;
            this.cboDataBase.DropDown += new System.EventHandler(this.cboDataBase_DropDown);
            // 
            // cboServer
            // 
            this.cboServer.FormattingEnabled = true;
            this.cboServer.Location = new System.Drawing.Point(214, 39);
            this.cboServer.Name = "cboServer";
            this.cboServer.Size = new System.Drawing.Size(153, 21);
            this.cboServer.TabIndex = 19;
            this.cboServer.DropDown += new System.EventHandler(this.cboServer_DropDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(110, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Database:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(110, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Password:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(110, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "User Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(110, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Sever Name";
            // 
            // fcauhinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 261);
            this.Controls.Add(this.bHuy);
            this.Controls.Add(this.bLuu);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.cboDataBase);
            this.Controls.Add(this.cboServer);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "fcauhinh";
            this.Text = "fcauhinh";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bHuy;
        private System.Windows.Forms.Button bLuu;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox cboDataBase;
        private System.Windows.Forms.ComboBox cboServer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;


    }
}