namespace LoginSignup
{
    partial class SignupForm
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
            this.have_account = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.signup_btn = new System.Windows.Forms.Button();
            this.set_password = new System.Windows.Forms.TextBox();
            this.set_username = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.con_password = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.set_email = new System.Windows.Forms.TextBox();
            this.set_name = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.error1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.error2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.error3 = new System.Windows.Forms.ErrorProvider(this.components);
            this.error4 = new System.Windows.Forms.ErrorProvider(this.components);
            this.error5 = new System.Windows.Forms.ErrorProvider(this.components);
            this.error6 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.Gender = new System.Windows.Forms.ComboBox();
            this.error7 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.back_btn = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.error1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.error2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.error3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.error4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.error5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.error6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.error7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.back_btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // have_account
            // 
            this.have_account.AutoSize = true;
            this.have_account.BackColor = System.Drawing.SystemColors.Control;
            this.have_account.Location = new System.Drawing.Point(205, 567);
            this.have_account.Name = "have_account";
            this.have_account.Size = new System.Drawing.Size(166, 16);
            this.have_account.TabIndex = 8;
            this.have_account.Text = "Already Have an Account?";
            this.have_account.Click += new System.EventHandler(this.have_account_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = System.Drawing.SystemColors.Control;
            this.checkBox1.Location = new System.Drawing.Point(316, 435);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(122, 20);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "show password";
            this.checkBox1.UseVisualStyleBackColor = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // signup_btn
            // 
            this.signup_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(113)))), ((int)(((byte)(255)))));
            this.signup_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.signup_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signup_btn.ForeColor = System.Drawing.Color.White;
            this.signup_btn.Location = new System.Drawing.Point(228, 509);
            this.signup_btn.Name = "signup_btn";
            this.signup_btn.Size = new System.Drawing.Size(116, 42);
            this.signup_btn.TabIndex = 7;
            this.signup_btn.Text = "SIGNUP";
            this.signup_btn.UseVisualStyleBackColor = false;
            this.signup_btn.Click += new System.EventHandler(this.signup_btn_Click);
            // 
            // set_password
            // 
            this.set_password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.set_password.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.set_password.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.set_password.Location = new System.Drawing.Point(316, 313);
            this.set_password.Name = "set_password";
            this.set_password.PasswordChar = '*';
            this.set_password.Size = new System.Drawing.Size(223, 30);
            this.set_password.TabIndex = 3;
            this.set_password.Text = "Password";
            this.set_password.Enter += new System.EventHandler(this.set_password_Enter);
            this.set_password.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.set_password_KeyPress);
            this.set_password.Leave += new System.EventHandler(this.set_password_Leave);
            // 
            // set_username
            // 
            this.set_username.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.set_username.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.set_username.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.set_username.Location = new System.Drawing.Point(49, 314);
            this.set_username.Name = "set_username";
            this.set_username.Size = new System.Drawing.Size(226, 30);
            this.set_username.TabIndex = 1;
            this.set_username.Text = "username";
            this.set_username.Enter += new System.EventHandler(this.set_username_Enter);
            this.set_username.Leave += new System.EventHandler(this.set_username_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(312, 283);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(47, 284);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Username";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(312, 360);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Re-Password";
            // 
            // con_password
            // 
            this.con_password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.con_password.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.con_password.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.con_password.Location = new System.Drawing.Point(316, 391);
            this.con_password.Name = "con_password";
            this.con_password.PasswordChar = '*';
            this.con_password.Size = new System.Drawing.Size(222, 30);
            this.con_password.TabIndex = 4;
            this.con_password.Text = "Password";
            this.con_password.Enter += new System.EventHandler(this.con_password_Enter);
            this.con_password.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.con_password_KeyPress);
            this.con_password.Leave += new System.EventHandler(this.con_password_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Stencil", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(168, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(259, 33);
            this.label4.TabIndex = 9;
            this.label4.Text = "CITY TRANSPORT";
            // 
            // set_email
            // 
            this.set_email.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.set_email.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.set_email.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.set_email.Location = new System.Drawing.Point(316, 232);
            this.set_email.Name = "set_email";
            this.set_email.Size = new System.Drawing.Size(226, 30);
            this.set_email.TabIndex = 2;
            this.set_email.Text = "abc@gmail.com";
            this.set_email.Enter += new System.EventHandler(this.set_email_Enter);
            this.set_email.Leave += new System.EventHandler(this.set_email_Leave);
            // 
            // set_name
            // 
            this.set_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.set_name.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.set_name.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.set_name.Location = new System.Drawing.Point(49, 233);
            this.set_name.Name = "set_name";
            this.set_name.Size = new System.Drawing.Size(226, 30);
            this.set_name.TabIndex = 0;
            this.set_name.Text = "Full Name";
            this.set_name.Enter += new System.EventHandler(this.set_name_Enter);
            this.set_name.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.set_name_KeyPress);
            this.set_name.Leave += new System.EventHandler(this.set_name_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(312, 197);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "Email";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.Control;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(47, 197);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 20);
            this.label6.TabIndex = 14;
            this.label6.Text = "Name";
            // 
            // error1
            // 
            this.error1.ContainerControl = this;
            // 
            // error2
            // 
            this.error2.ContainerControl = this;
            // 
            // error3
            // 
            this.error3.ContainerControl = this;
            // 
            // error4
            // 
            this.error4.ContainerControl = this;
            // 
            // error5
            // 
            this.error5.ContainerControl = this;
            // 
            // error6
            // 
            this.error6.ContainerControl = this;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.Control;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(47, 361);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 20);
            this.label7.TabIndex = 13;
            this.label7.Text = "Gender";
            // 
            // Gender
            // 
            this.Gender.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.Gender.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.Gender.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Gender.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.Gender.FormattingEnabled = true;
            this.Gender.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.Gender.Location = new System.Drawing.Point(49, 392);
            this.Gender.Name = "Gender";
            this.Gender.Size = new System.Drawing.Size(226, 31);
            this.Gender.TabIndex = 5;
            this.Gender.Text = "Gender";
            this.Gender.SelectedIndexChanged += new System.EventHandler(this.Gender_SelectedIndexChanged);
            this.Gender.Enter += new System.EventHandler(this.Gender_Enter);
            this.Gender.Leave += new System.EventHandler(this.Gender_Leave);
            // 
            // error7
            // 
            this.error7.ContainerControl = this;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Location = new System.Drawing.Point(31, 182);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(525, 424);
            this.panel1.TabIndex = 15;
            // 
            // back_btn
            // 
            this.back_btn.Image = global::LoginSignup.Properties.Resources.ei_1644677685267_removebg_preview;
            this.back_btn.Location = new System.Drawing.Point(12, 12);
            this.back_btn.Name = "back_btn";
            this.back_btn.Size = new System.Drawing.Size(30, 25);
            this.back_btn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.back_btn.TabIndex = 10;
            this.back_btn.TabStop = false;
            this.back_btn.Click += new System.EventHandler(this.back_btn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::LoginSignup.Properties.Resources.BUS_2;
            this.pictureBox1.Location = new System.Drawing.Point(185, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(223, 111);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // SignupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(588, 618);
            this.Controls.Add(this.Gender);
            this.Controls.Add(this.set_email);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.set_name);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.back_btn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.have_account);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.signup_btn);
            this.Controls.Add(this.con_password);
            this.Controls.Add(this.set_password);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.set_username);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "SignupForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SignupForm";
            ((System.ComponentModel.ISupportInitialize)(this.error1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.error2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.error3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.error4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.error5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.error6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.error7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.back_btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label have_account;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button signup_btn;
        private System.Windows.Forms.TextBox set_password;
        private System.Windows.Forms.TextBox set_username;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox con_password;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox back_btn;
        private System.Windows.Forms.TextBox set_email;
        private System.Windows.Forms.TextBox set_name;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ErrorProvider error1;
        private System.Windows.Forms.ErrorProvider error2;
        private System.Windows.Forms.ErrorProvider error3;
        private System.Windows.Forms.ErrorProvider error4;
        private System.Windows.Forms.ErrorProvider error5;
        private System.Windows.Forms.ErrorProvider error6;
        private System.Windows.Forms.ComboBox Gender;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ErrorProvider error7;
        private System.Windows.Forms.Panel panel1;
    }
}