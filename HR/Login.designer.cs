namespace HR
{
    partial class Login
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
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.panClose = new System.Windows.Forms.Panel();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.panContent = new System.Windows.Forms.Panel();
            this.txtName = new HR.Custom1TextBox();
            this.btnLogin = new System.Windows.Forms.Panel();
            this.panContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(228)))), ((int)(((byte)(238)))));
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPassword.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtPassword.Location = new System.Drawing.Point(194, 281);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPassword.Size = new System.Drawing.Size(178, 20);
            this.txtPassword.TabIndex = 14;
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            // 
            // panClose
            // 
            this.panClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(26)))), ((int)(((byte)(59)))));
            this.panClose.BackgroundImage = global::HR.Properties.Resources.Delete_52px;
            this.panClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panClose.Location = new System.Drawing.Point(484, 12);
            this.panClose.Name = "panClose";
            this.panClose.Size = new System.Drawing.Size(46, 36);
            this.panClose.TabIndex = 20;
            this.panClose.Click += new System.EventHandler(this.panClose_Click);
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.panContent;
            this.bunifuDragControl1.Vertical = true;
            // 
            // panContent
            // 
            this.panContent.BackgroundImage = global::HR.Properties.Resources.loginscreen;
            this.panContent.Controls.Add(this.txtName);
            this.panContent.Controls.Add(this.btnLogin);
            this.panContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panContent.Location = new System.Drawing.Point(0, 0);
            this.panContent.Name = "panContent";
            this.panContent.Size = new System.Drawing.Size(542, 484);
            this.panContent.TabIndex = 21;
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.Transparent;
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtName.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(228)))), ((int)(((byte)(238)))));
            this.txtName.Location = new System.Drawing.Point(194, 240);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(178, 20);
            this.txtName.TabIndex = 21;
            this.txtName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtName_KeyDown);
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.Transparent;
            this.btnLogin.Location = new System.Drawing.Point(225, 318);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(92, 30);
            this.btnLogin.TabIndex = 20;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(245)))), ((int)(((byte)(252)))));
            this.BackgroundImage = global::HR.Properties.Resources.loginscreen;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(542, 484);
            this.Controls.Add(this.panClose);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.panContent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "Login";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تسجيل";
            this.panContent.ResumeLayout(false);
            this.panContent.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Panel panClose;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private System.Windows.Forms.Panel panContent;
        private System.Windows.Forms.Panel btnLogin;
        private Custom1TextBox txtName;
    }
}