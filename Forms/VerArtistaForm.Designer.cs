namespace discos.Forms
{
    partial class VerArtistaForm
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.novoDiscoButton = new System.Windows.Forms.Button();
            this.dataNascimentoArtistaLabel = new System.Windows.Forms.Label();
            this.nacionalidadeArtistaLabel = new System.Windows.Forms.Label();
            this.tituloLabel = new System.Windows.Forms.Label();
            this.artistaFotoPictureBox = new System.Windows.Forms.PictureBox();
            this.biografiaTextBox = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.artistaFotoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 288);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(461, 303);
            this.listView1.TabIndex = 17;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 256);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 29);
            this.label1.TabIndex = 18;
            this.label1.Text = "Discografia";
            // 
            // novoDiscoButton
            // 
            this.novoDiscoButton.Location = new System.Drawing.Point(398, 259);
            this.novoDiscoButton.Name = "novoDiscoButton";
            this.novoDiscoButton.Size = new System.Drawing.Size(75, 23);
            this.novoDiscoButton.TabIndex = 19;
            this.novoDiscoButton.Text = "Novo Disco";
            this.novoDiscoButton.UseVisualStyleBackColor = true;
            this.novoDiscoButton.Click += new System.EventHandler(this.NovoDiscoButton_Click);
            // 
            // dataNascimentoArtistaLabel
            // 
            this.dataNascimentoArtistaLabel.AutoSize = true;
            this.dataNascimentoArtistaLabel.Location = new System.Drawing.Point(218, 77);
            this.dataNascimentoArtistaLabel.Name = "dataNascimentoArtistaLabel";
            this.dataNascimentoArtistaLabel.Size = new System.Drawing.Size(139, 13);
            this.dataNascimentoArtistaLabel.TabIndex = 15;
            this.dataNascimentoArtistaLabel.Text = "dataNascimentoArtistaLabel";
            // 
            // nacionalidadeArtistaLabel
            // 
            this.nacionalidadeArtistaLabel.AutoSize = true;
            this.nacionalidadeArtistaLabel.Location = new System.Drawing.Point(218, 49);
            this.nacionalidadeArtistaLabel.Name = "nacionalidadeArtistaLabel";
            this.nacionalidadeArtistaLabel.Size = new System.Drawing.Size(128, 13);
            this.nacionalidadeArtistaLabel.TabIndex = 14;
            this.nacionalidadeArtistaLabel.Text = "nacionalidadeArtistaLabel";
            // 
            // tituloLabel
            // 
            this.tituloLabel.AutoSize = true;
            this.tituloLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tituloLabel.Location = new System.Drawing.Point(12, 9);
            this.tituloLabel.Name = "tituloLabel";
            this.tituloLabel.Size = new System.Drawing.Size(163, 37);
            this.tituloLabel.TabIndex = 4;
            this.tituloLabel.Text = "tituloLabel";
            // 
            // artistaFotoPictureBox
            // 
            this.artistaFotoPictureBox.Location = new System.Drawing.Point(12, 49);
            this.artistaFotoPictureBox.Name = "artistaFotoPictureBox";
            this.artistaFotoPictureBox.Size = new System.Drawing.Size(200, 200);
            this.artistaFotoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.artistaFotoPictureBox.TabIndex = 12;
            this.artistaFotoPictureBox.TabStop = false;
            this.artistaFotoPictureBox.WaitOnLoad = true;
            // 
            // biografiaTextBox
            // 
            this.biografiaTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.biografiaTextBox.Location = new System.Drawing.Point(221, 108);
            this.biografiaTextBox.Name = "biografiaTextBox";
            this.biografiaTextBox.ReadOnly = true;
            this.biografiaTextBox.Size = new System.Drawing.Size(252, 145);
            this.biografiaTextBox.TabIndex = 20;
            this.biografiaTextBox.Text = "biografiaTextBox";
            // 
            // VerArtistaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 603);
            this.Controls.Add(this.biografiaTextBox);
            this.Controls.Add(this.novoDiscoButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.dataNascimentoArtistaLabel);
            this.Controls.Add(this.nacionalidadeArtistaLabel);
            this.Controls.Add(this.artistaFotoPictureBox);
            this.Controls.Add(this.tituloLabel);
            this.Name = "VerArtistaForm";
            this.Text = "ArtistaForm";
            this.Load += new System.EventHandler(this.ArtistaForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.artistaFotoPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button novoDiscoButton;
        private System.Windows.Forms.Label dataNascimentoArtistaLabel;
        private System.Windows.Forms.Label nacionalidadeArtistaLabel;
        private System.Windows.Forms.Label tituloLabel;
        private System.Windows.Forms.PictureBox artistaFotoPictureBox;
        private System.Windows.Forms.RichTextBox biografiaTextBox;
    }
}