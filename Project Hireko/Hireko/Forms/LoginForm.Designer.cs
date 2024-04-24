namespace Hireko.Forms
{
    partial class LoginForm
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
            bntLogin = new Button();
            register = new LinkLabel();
            SuspendLayout();
            // 
            // username
            // 
            username.Location = new Point(369, 142);
            username.Name = "username";
            username.Size = new Size(125, 27);
            username.TabIndex = 0;
            username.Text = "User";
            username.TextChanged += username_TextChanged;
            // 
            // password
            // 
            password.Location = new Point(395, 214);
            password.Name = "password";
            password.Size = new Size(125, 27);
            password.TabIndex = 1;
            password.Text = "Pass";
            password.TextChanged += password_TextChanged;
            // 
            // bntLogin
            // 
            bntLogin.Location = new Point(386, 290);
            bntLogin.Name = "bntLogin";
            bntLogin.Size = new Size(94, 29);
            bntLogin.TabIndex = 2;
            bntLogin.Text = "Login";
            bntLogin.UseVisualStyleBackColor = true;
            bntLogin.Click += bntLogin_Click;
            // 
            // register
            // 
            register.AutoSize = true;
            register.Location = new Point(395, 353);
            register.Name = "register";
            register.Size = new Size(63, 20);
            register.TabIndex = 3;
            register.TabStop = true;
            register.Text = "Register";
            register.LinkClicked += register_LinkClicked;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(942, 493);
            Controls.Add(register);
            Controls.Add(bntLogin);
            Controls.Add(password);
            Controls.Add(username);
            Name = "LoginForm";
            Text = "LoginForm";
            Load += LoginForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox username;
        private TextBox password;
        private Button bntLogin;
        private LinkLabel register;
    }
}