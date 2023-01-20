namespace LoginSignup
{
    partial class AdminLogin
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
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.login_btn = new System.Windows.Forms.Button();
            this.admin_password = new System.Windows.Forms.TextBox();
            this.admin_code = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.admin_username = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.error2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.back_btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.error2)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // back_btn
            // 
            this.back_btn.Image = global::LoginSignup.Properties.Resources.ei_1644677685267_removebg_preview;
            this.back_btn.Location = new System.Drawing.Point(10, 12);
            this.back_btn.Name = "back_btn";
            this.back_btn.Size = new System.Drawing.Size(30, 25);
            this.back_btn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.back_btn.TabIndex = 22;
            this.back_btn.TabStop = false;
            this.back_btn.Click += new System.EventHandler(this.back_btn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Stencil", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(193, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(259, 33);
            this.label4.TabIndex = 21;
            this.label4.Text = "CITY TRANSPORT";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::LoginSignup.Properties.Resources.BUS_2;
            this.pictureBox1.Location = new System.Drawing.Point(238, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(168, 89);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(111, 293);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(122, 20);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "show password";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // login_btn
            // 
            this.login_btn.BackColor = System.Drawing.Color.LavenderBlush;
            this.login_btn.FlatAppearance.BorderSize = 0;
            this.login_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.login_btn.Location = new System.Drawing.Point(161, 368);
            this.login_btn.Name = "login_btn";
            this.login_btn.Size = new System.Drawing.Size(116, 42);
            this.login_btn.TabIndex = 4;
            this.login_btn.Text = "LOGIN";
            this.login_btn.UseVisualStyleBackColor = false;
            this.login_btn.Click += new System.EventHandler(this.login_btn_Click);
            // 
            // admin_password
            // 
            this.admin_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.admin_password.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.admin_password.Location = new System.Drawing.Point(109, 248);
            this.admin_password.Name = "admin_password";
            this.admin_password.PasswordChar = '*';
            this.admin_password.Size = new System.Drawing.Size(224, 28);
            this.admin_password.TabIndex = 2;
            this.admin_password.Text = "Password";
            this.admin_password.Enter += new System.EventHandler(this.admin_password_Enter);
            this.admin_password.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.admin_password_KeyPress);
            this.admin_password.Leave += new System.EventHandler(this.admin_password_Leave);
            // 
            // admin_code
            // 
            this.admin_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.admin_code.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.admin_code.Location = new System.Drawing.Point(109, 166);
            this.admin_code.Name = "admin_code";
            this.admin_code.PasswordChar = '*';
            this.admin_code.Size = new System.Drawing.Size(224, 28);
            this.admin_code.TabIndex = 1;
            this.admin_code.Text = "Code";
            this.admin_code.Enter += new System.EventHandler(this.admin_code_Enter);
            this.admin_code.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.admin_code_KeyPress);
            this.admin_code.Leave += new System.EventHandler(this.admin_code_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(105, 210);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 22);
            this.label3.TabIndex = 17;
            this.label3.Text = "Password";
            // 
            // admin_username
            // 
            this.admin_username.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.admin_username.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.admin_username.Location = new System.Drawing.Point(109, 84);
            this.admin_username.Name = "admin_username";
            this.admin_username.Size = new System.Drawing.Size(224, 28);
            this.admin_username.TabIndex = 0;
            this.admin_username.Text = "username";
            this.admin_username.Enter += new System.EventHandler(this.admin_username_Enter);
            this.admin_username.Leave += new System.EventHandler(this.admin_username_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(107, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 22);
            this.label2.TabIndex = 18;
            this.label2.Text = "Code";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(105, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 22);
            this.label1.TabIndex = 19;
            this.label1.Text = "Username";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Stencil", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label5.Location = new System.Drawing.Point(250, 158);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(145, 24);
            this.label5.TabIndex = 21;
            this.label5.Text = "ADMIN LOGIN";
            // 
            // error2
            // 
            this.error2.ContainerControl = this;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.panel1.Controls.Add(this.admin_username);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.admin_code);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.admin_password);
            this.panel1.Controls.Add(this.login_btn);
            this.panel1.Location = new System.Drawing.Point(103, 202);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(439, 461);
            this.panel1.TabIndex = 23;
            // 
            // AdminLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(644, 709);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.back_btn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "AdminLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.back_btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.error2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox back_btn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button login_btn;
        private System.Windows.Forms.TextBox admin_password;
        private System.Windows.Forms.TextBox admin_code;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox admin_username;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ErrorProvider error2;
        private System.Windows.Forms.Panel panel1;
    }
}