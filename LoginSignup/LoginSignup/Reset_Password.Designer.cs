namespace LoginSignup
{
    partial class Reset_Password
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
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.email = new System.Windows.Forms.TextBox();
            this.otp = new System.Windows.Forms.TextBox();
            this.Send_Otp = new System.Windows.Forms.Button();
            this.verify_btn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.back_btn = new System.Windows.Forms.PictureBox();
            this.error1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.resend_otp = new System.Windows.Forms.Label();
            this.sec_txt = new System.Windows.Forms.Label();
            this.countdown = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.back_btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.error1)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Stencil", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(148, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(259, 33);
            this.label3.TabIndex = 18;
            this.label3.Text = "CITY TRANSPORT";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(133, 214);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 22);
            this.label1.TabIndex = 19;
            this.label1.Text = "Email";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(155, 340);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 22);
            this.label2.TabIndex = 19;
            this.label2.Text = "OTP";
            // 
            // email
            // 
            this.email.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.email.Location = new System.Drawing.Point(214, 213);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(211, 28);
            this.email.TabIndex = 0;
            this.email.Leave += new System.EventHandler(this.email_Leave);
            // 
            // otp
            // 
            this.otp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.otp.Location = new System.Drawing.Point(226, 339);
            this.otp.Name = "otp";
            this.otp.Size = new System.Drawing.Size(154, 28);
            this.otp.TabIndex = 2;
            this.otp.Leave += new System.EventHandler(this.otp_Leave);
            // 
            // Send_Otp
            // 
            this.Send_Otp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Send_Otp.Location = new System.Drawing.Point(225, 263);
            this.Send_Otp.Name = "Send_Otp";
            this.Send_Otp.Size = new System.Drawing.Size(104, 38);
            this.Send_Otp.TabIndex = 1;
            this.Send_Otp.Text = "SEND";
            this.Send_Otp.UseVisualStyleBackColor = true;
            this.Send_Otp.Click += new System.EventHandler(this.Send_Otp_Click);
            // 
            // verify_btn
            // 
            this.verify_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.verify_btn.Location = new System.Drawing.Point(225, 404);
            this.verify_btn.Name = "verify_btn";
            this.verify_btn.Size = new System.Drawing.Size(104, 36);
            this.verify_btn.TabIndex = 3;
            this.verify_btn.Text = "VERIFY";
            this.verify_btn.UseVisualStyleBackColor = true;
            this.verify_btn.Click += new System.EventHandler(this.verify_btn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::LoginSignup.Properties.Resources.BUS_2;
            this.pictureBox1.Location = new System.Drawing.Point(169, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(223, 111);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // back_btn
            // 
            this.back_btn.Image = global::LoginSignup.Properties.Resources.ei_1644677685267_removebg_preview;
            this.back_btn.Location = new System.Drawing.Point(12, 12);
            this.back_btn.Name = "back_btn";
            this.back_btn.Size = new System.Drawing.Size(30, 25);
            this.back_btn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.back_btn.TabIndex = 20;
            this.back_btn.TabStop = false;
            this.back_btn.Click += new System.EventHandler(this.back_btn_Click);
            // 
            // error1
            // 
            this.error1.ContainerControl = this;
            // 
            // resend_otp
            // 
            this.resend_otp.AutoSize = true;
            this.resend_otp.Font = new System.Drawing.Font("Microsoft YaHei", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resend_otp.Location = new System.Drawing.Point(234, 375);
            this.resend_otp.Name = "resend_otp";
            this.resend_otp.Size = new System.Drawing.Size(93, 17);
            this.resend_otp.TabIndex = 21;
            this.resend_otp.Text = "Resend OTP in";
            this.resend_otp.Click += new System.EventHandler(this.resend_otp_Click);
            // 
            // sec_txt
            // 
            this.sec_txt.AutoSize = true;
            this.sec_txt.Font = new System.Drawing.Font("Microsoft YaHei", 7.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sec_txt.Location = new System.Drawing.Point(332, 376);
            this.sec_txt.Name = "sec_txt";
            this.sec_txt.Size = new System.Drawing.Size(32, 17);
            this.sec_txt.TabIndex = 22;
            this.sec_txt.Text = " 30s";
            // 
            // countdown
            // 
            this.countdown.Interval = 1000;
            this.countdown.Tick += new System.EventHandler(this.countdown_Tick);
            // 
            // Reset_Password
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(555, 547);
            this.Controls.Add(this.sec_txt);
            this.Controls.Add(this.resend_otp);
            this.Controls.Add(this.back_btn);
            this.Controls.Add(this.verify_btn);
            this.Controls.Add(this.Send_Otp);
            this.Controls.Add(this.otp);
            this.Controls.Add(this.email);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Reset_Password";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Reset_Password_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.back_btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.error1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox email;
        private System.Windows.Forms.TextBox otp;
        private System.Windows.Forms.Button Send_Otp;
        private System.Windows.Forms.Button verify_btn;
        private System.Windows.Forms.PictureBox back_btn;
        private System.Windows.Forms.ErrorProvider error1;
        private System.Windows.Forms.Label sec_txt;
        private System.Windows.Forms.Label resend_otp;
        private System.Windows.Forms.Timer countdown;
    }
}