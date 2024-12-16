namespace doan_ver1._0
{
    partial class form_login
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
            this.txt_Pass_admin = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_user_admin = new System.Windows.Forms.TextBox();
            this.btn_login_admin = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_Pass_admin
            // 
            this.txt_Pass_admin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Pass_admin.Location = new System.Drawing.Point(228, 396);
            this.txt_Pass_admin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_Pass_admin.Multiline = true;
            this.txt_Pass_admin.Name = "txt_Pass_admin";
            this.txt_Pass_admin.PasswordChar = '*';
            this.txt_Pass_admin.Size = new System.Drawing.Size(312, 37);
            this.txt_Pass_admin.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkBlue;
            this.label4.Location = new System.Drawing.Point(225, 376);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 18);
            this.label4.TabIndex = 9;
            this.label4.Text = "Mật khẩu";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // txt_user_admin
            // 
            this.txt_user_admin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_user_admin.Location = new System.Drawing.Point(228, 308);
            this.txt_user_admin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_user_admin.Multiline = true;
            this.txt_user_admin.Name = "txt_user_admin";
            this.txt_user_admin.Size = new System.Drawing.Size(312, 37);
            this.txt_user_admin.TabIndex = 8;
            // 
            // btn_login_admin
            // 
            this.btn_login_admin.BackColor = System.Drawing.Color.DarkBlue;
            this.btn_login_admin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_login_admin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_login_admin.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.btn_login_admin.Location = new System.Drawing.Point(299, 485);
            this.btn_login_admin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_login_admin.Name = "btn_login_admin";
            this.btn_login_admin.Size = new System.Drawing.Size(159, 62);
            this.btn_login_admin.TabIndex = 11;
            this.btn_login_admin.Text = "ĐĂNG NHẬP";
            this.btn_login_admin.UseVisualStyleBackColor = false;
            this.btn_login_admin.Click += new System.EventHandler(this.btn_login_admin_Click);
            this.btn_login_admin.MouseEnter += new System.EventHandler(this.btn_login_admin_MouseEnter);
            this.btn_login_admin.MouseLeave += new System.EventHandler(this.btn_login_admin_MouseLeave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(225, 288);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 18);
            this.label1.TabIndex = 13;
            this.label1.Text = "Tên đăng nhập";
            // 
            // pictureBox2
            // 

            this.pictureBox2.Location = new System.Drawing.Point(-7, -10);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(152, 84);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 14;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            
            this.pictureBox1.Location = new System.Drawing.Point(229, 91);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(311, 165);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkLabel1.Location = new System.Drawing.Point(229, 453);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(113, 16);
            this.linkLabel1.TabIndex = 15;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Đăng ký tài khoản";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkBlue;
            this.label2.Location = new System.Drawing.Point(292, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(193, 37);
            this.label2.TabIndex = 16;
            this.label2.Text = "ĐĂNG NHẬP";
            // 
            // form_login
            // 
            this.AcceptButton = this.btn_login_admin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(780, 590);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btn_login_admin);
            this.Controls.Add(this.txt_Pass_admin);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_user_admin);
            this.Name = "form_login";
            this.Text = "form_login";
            this.Load += new System.EventHandler(this.form_login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_Pass_admin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_user_admin;
        private System.Windows.Forms.Button btn_login_admin;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label2;
    }
}