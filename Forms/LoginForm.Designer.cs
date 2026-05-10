namespace discos2
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.textLogin = new System.Windows.Forms.TextBox();
            this.textPass = new System.Windows.Forms.TextBox();
            this.BtnLogin = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(289, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Centro de guardação de CDS";
            // 
            // textLogin
            // 
            this.textLogin.Location = new System.Drawing.Point(302, 102);
            this.textLogin.Name = "textLogin";
            this.textLogin.Size = new System.Drawing.Size(120, 20);
            this.textLogin.TabIndex = 1;
            // 
            // textPass
            // 
            this.textPass.Location = new System.Drawing.Point(302, 172);
            this.textPass.Name = "textPass";
            this.textPass.Size = new System.Drawing.Size(120, 20);
            this.textPass.TabIndex = 2;
            this.textPass.UseSystemPasswordChar = true;
            // 
            // BtnLogin
            // 
            this.BtnLogin.Location = new System.Drawing.Point(313, 212);
            this.BtnLogin.Name = "BtnLogin";
            this.BtnLogin.Size = new System.Drawing.Size(100, 30);
            this.BtnLogin.TabIndex = 3;
            this.BtnLogin.Text = "Login";
            this.BtnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(342, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "User";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(332, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Password";
            // 
            // FormLogin
            // 
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textLogin);
            this.Controls.Add(this.textPass);
            this.Controls.Add(this.BtnLogin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Name = "FormLogin";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textLogin;
        private System.Windows.Forms.TextBox textPass;
        private System.Windows.Forms.Button BtnLogin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
    }
}