namespace LoginSignup
{
    partial class AdminVerification
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
            this.back_btn = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.verify_btn = new System.Windows.Forms.Button();
            this.admin_code = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.sec_txt = new System.Windows.Forms.Label();
            this.resend_otp = new System.Windows.Forms.Label();
            this.countdown = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.back_btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // back_btn
            // 
            this.back_btn.Image = global::LoginSignup.Properties.Resources.ei_1644677685267_removebg_preview;
            this.back_btn.Location = new System.Drawing.Point(13, 12);
            this.back_btn.Name = "back_btn";
            this.back_btn.Size = new System.Drawing.Size(30, 25);
            this.back_btn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.back_btn.TabIndex = 34;
            this.back_btn.TabStop = false;
            this.back_btn.Click += new System.EventHandler(this.back_btn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Stencil", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label5.Location = new System.Drawing.Point(167, 159);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(230, 24);
            this.label5.TabIndex = 32;
            this.label5.Text = "ADMIN VERIFICATION";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Stencil", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(155, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(259, 33);
            this.label4.TabIndex = 33;
            this.label4.Text = "CITY TRANSPORT";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::LoginSignup.Properties.Resources.BUS_2;
            this.pictureBox1.Location = new System.Drawing.Point(193, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(168, 89);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 31;
            this.pictureBox1.TabStop = false;
            // 
            // verify_btn
            // 
            this.verify_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.verify_btn.Location = new System.Drawing.Point(226, 310);
            this.verify_btn.Name = "verify_btn";
            this.verify_btn.Size = new System.Drawing.Size(116, 42);
            this.verify_btn.TabIndex = 27;
            this.verify_btn.Text = "VERIFY";
            this.verify_btn.UseVisualStyleBackColor = true;
            this.verify_btn.Click += new System.EventHandler(this.verify_btn_Click);
            // 
            // admin_code
            // 
            this.admin_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.admin_code.Location = new System.Drawing.Point(206, 240);
            this.admin_code.Name = "admin_code";
            this.admin_code.Size = new System.Drawing.Size(191, 28);
            this.admin_code.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(126, 240);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 22);
            this.label2.TabIndex = 29;
            this.label2.Text = "OTP";
            // 
            // sec_txt
            // 
            this.sec_txt.AutoSize = true;
            this.sec_txt.Font = new System.Drawing.Font("Microsoft YaHei", 7.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sec_txt.Location = new System.Drawing.Point(327, 277);
            this.sec_txt.Name = "sec_txt";
            this.sec_txt.Size = new System.Drawing.Size(35, 19);
            this.sec_txt.TabIndex = 36;
            this.sec_txt.Text = " 30s";
            // 
            // resend_otp
            // 
            this.resend_otp.AutoSize = true;
            this.resend_otp.Font = new System.Drawing.Font("Microsoft YaHei", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resend_otp.Location = new System.Drawing.Point(229, 277);
            this.resend_otp.Name = "resend_otp";
            this.resend_otp.Size = new System.Drawing.Size(98, 19);
            this.resend_otp.TabIndex = 35;
            this.resend_otp.Text = "Resend OTP in";
            this.resend_otp.Click += new System.EventHandler(this.resend_otp_Click);
            // 
            // countdown
            // 
            this.countdown.Interval = 1000;
            this.countdown.Tick += new System.EventHandler(this.countdown_Tick);
            // 
            // AdminVerification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(555, 547);
            this.Controls.Add(this.sec_txt);
            this.Controls.Add(this.resend_otp);
            this.Controls.Add(this.back_btn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.verify_btn);
            this.Controls.Add(this.admin_code);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AdminVerification";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminVerification";
            ((System.ComponentModel.ISupportInitialize)(this.back_btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox back_btn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button verify_btn;
        private System.Windows.Forms.TextBox admin_code;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label sec_txt;
        private System.Windows.Forms.Label resend_otp;
        private System.Windows.Forms.Timer countdown;
    }
}