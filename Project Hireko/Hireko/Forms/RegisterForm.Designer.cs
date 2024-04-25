namespace Hireko.Forms
{
    partial class RegisterForm
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
            username = new TextBox();
            password = new TextBox();
            confirm_password = new TextBox();
            register = new Button();
            login = new LinkLabel();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            first_Name = new TextBox();
            last_Name = new TextBox();
            email = new TextBox();
            phone = new TextBox();
            address = new TextBox();
            SuspendLayout();
            // 
            // username
            // 
            username.Location = new Point(340, 108);
            username.Name = "username";
            username.Size = new Size(125, 27);
            username.TabIndex = 0;
            username.TextChanged += username_TextChanged;
            // 
            // password
            // 
            password.Location = new Point(340, 171);
            password.Name = "password";
            password.Size = new Size(125, 27);
            password.TabIndex = 1;
            password.TextChanged += password_TextChanged;
            // 
            // confirm_password
            // 
            confirm_password.Location = new Point(340, 236);
            confirm_password.Name = "confirm_password";
            confirm_password.Size = new Size(125, 27);
            confirm_password.TabIndex = 2;
            confirm_password.TextChanged += confirm_password_TextChanged;
            // 
            // register
            // 
            register.Location = new Point(356, 287);
            register.Name = "register";
            register.Size = new Size(94, 29);
            register.TabIndex = 3;
            register.Text = "Register";
            register.UseVisualStyleBackColor = true;
            register.Click += register_Click;
            // 
            // login
            // 
            login.AutoSize = true;
            login.Location = new Point(324, 355);
            login.Name = "login";
            login.Size = new Size(183, 20);
            login.TabIndex = 4;
            login.TabStop = true;
            login.Text = "Already Have an Account?";
            login.LinkClicked += login_LinkClicked;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(219, 119);
            label1.Name = "label1";
            label1.Size = new Size(75, 20);
            label1.TabIndex = 5;
            label1.Text = "Username";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(237, 183);
            label2.Name = "label2";
            label2.Size = new Size(70, 20);
            label2.TabIndex = 6;
            label2.Text = "Password";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(195, 239);
            label3.Name = "label3";
            label3.Size = new Size(127, 20);
            label3.TabIndex = 7;
            label3.Text = "Confirm Password";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(519, 111);
            label4.Name = "label4";
            label4.Size = new Size(46, 20);
            label4.TabIndex = 8;
            label4.Text = "Email";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(515, 171);
            label5.Name = "label5";
            label5.Size = new Size(50, 20);
            label5.TabIndex = 9;
            label5.Text = "Phone";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(519, 239);
            label6.Name = "label6";
            label6.Size = new Size(62, 20);
            label6.TabIndex = 10;
            label6.Text = "Address";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(501, 55);
            label7.Name = "label7";
            label7.Size = new Size(80, 20);
            label7.TabIndex = 11;
            label7.Text = "First Name";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(718, 55);
            label8.Name = "label8";
            label8.Size = new Size(79, 20);
            label8.TabIndex = 12;
            label8.Text = "Last Name";
            // 
            // first_Name
            // 
            first_Name.Location = new Point(587, 52);
            first_Name.Name = "first_Name";
            first_Name.Size = new Size(125, 27);
            first_Name.TabIndex = 13;
            first_Name.TextChanged += first_Name_TextChanged;
            // 
            // last_Name
            // 
            last_Name.Location = new Point(803, 55);
            last_Name.Name = "last_Name";
            last_Name.Size = new Size(125, 27);
            last_Name.TabIndex = 14;
            last_Name.TextChanged += last_Name_TextChanged;
            // 
            // email
            // 
            email.Location = new Point(606, 122);
            email.Name = "email";
            email.Size = new Size(125, 27);
            email.TabIndex = 15;
            email.TextChanged += email_TextChanged;
            // 
            // phone
            // 
            phone.Location = new Point(607, 181);
            phone.Name = "phone";
            phone.Size = new Size(125, 27);
            phone.TabIndex = 16;
            phone.TextChanged += phone_TextChanged;
            // 
            // address
            // 
            address.Location = new Point(613, 245);
            address.Name = "address";
            address.Size = new Size(125, 27);
            address.TabIndex = 17;
            address.TextChanged += address_TextChanged;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(942, 493);
            Controls.Add(address);
            Controls.Add(phone);
            Controls.Add(email);
            Controls.Add(last_Name);
            Controls.Add(first_Name);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(login);
            Controls.Add(register);
            Controls.Add(confirm_password);
            Controls.Add(password);
            Controls.Add(username);
            Name = "RegisterForm";
            Text = "RegisterForm";
            Load += RegisterForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox username;
        private TextBox password;
        private TextBox confirm_password;
        private Button register;
        private LinkLabel login;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private TextBox first_Name;
        private TextBox last_Name;
        private TextBox email;
        private TextBox phone;
        private TextBox address;
    }
}
