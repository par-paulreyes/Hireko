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
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(942, 493);
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
    }
}