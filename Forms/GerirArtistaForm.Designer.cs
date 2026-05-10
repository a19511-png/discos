namespace discos.Forms
{
    partial class GerirArtistaForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.guardarButton = new System.Windows.Forms.Button();
            this.nomeTextBox = new System.Windows.Forms.TextBox();
            this.nacionalidadeTextBox = new System.Windows.Forms.TextBox();
            this.dataNascimentoDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // guardarButton
            // 
            this.guardarButton.Location = new System.Drawing.Point(208, 316);
            this.guardarButton.Name = "guardarButton";
            this.guardarButton.Size = new System.Drawing.Size(75, 23);
            this.guardarButton.TabIndex = 1;
            this.guardarButton.Text = "OK";
            this.guardarButton.UseVisualStyleBackColor = true;
            this.guardarButton.Click += new System.EventHandler(this.guardarButton_Click);
            // 
            // nomeTextBox
            // 
            this.nomeTextBox.Location = new System.Drawing.Point(86, 114);
            this.nomeTextBox.Name = "nomeTextBox";
            this.nomeTextBox.Size = new System.Drawing.Size(100, 20);
            this.nomeTextBox.TabIndex = 2;
            // 
            // nacionalidadeTextBox
            // 
            this.nacionalidadeTextBox.Location = new System.Drawing.Point(86, 158);
            this.nacionalidadeTextBox.Name = "nacionalidadeTextBox";
            this.nacionalidadeTextBox.Size = new System.Drawing.Size(100, 20);
            this.nacionalidadeTextBox.TabIndex = 3;
            // 
            // dataNascimentoDateTimePicker
            // 
            this.dataNascimentoDateTimePicker.Location = new System.Drawing.Point(128, 216);
            this.dataNascimentoDateTimePicker.Name = "dataNascimentoDateTimePicker";
            this.dataNascimentoDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.dataNascimentoDateTimePicker.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "nome";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "nacionalidade";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 216);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "data de nascimento";
            // 
            // GerirArtistaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataNascimentoDateTimePicker);
            this.Controls.Add(this.nacionalidadeTextBox);
            this.Controls.Add(this.nomeTextBox);
            this.Controls.Add(this.guardarButton);
            this.Controls.Add(this.label1);
            this.Name = "GerirArtistaForm";
            this.Text = "GerirArtista";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button guardarButton;
        private System.Windows.Forms.TextBox nomeTextBox;
        private System.Windows.Forms.TextBox nacionalidadeTextBox;
        private System.Windows.Forms.DateTimePicker dataNascimentoDateTimePicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}