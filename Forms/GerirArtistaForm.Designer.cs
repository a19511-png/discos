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
            this.tituloLabel = new System.Windows.Forms.Label();
            this.guardarButton = new System.Windows.Forms.Button();
            this.nomeTextBox = new System.Windows.Forms.TextBox();
            this.dataNascimentoDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nacionalidadeComboBox = new System.Windows.Forms.ComboBox();
            this.biografiaRichTextBox = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.fotoPictureBox = new System.Windows.Forms.PictureBox();
            this.inserirFotoArtistaButton = new System.Windows.Forms.Button();
            this.cancelarButton = new System.Windows.Forms.Button();
            this.apagarFotoArtistaButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.fotoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // tituloLabel
            // 
            this.tituloLabel.AutoSize = true;
            this.tituloLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tituloLabel.Location = new System.Drawing.Point(13, 13);
            this.tituloLabel.Name = "tituloLabel";
            this.tituloLabel.Size = new System.Drawing.Size(163, 37);
            this.tituloLabel.TabIndex = 0;
            this.tituloLabel.Text = "tituloLabel";
            // 
            // guardarButton
            // 
            this.guardarButton.Location = new System.Drawing.Point(428, 413);
            this.guardarButton.Name = "guardarButton";
            this.guardarButton.Size = new System.Drawing.Size(75, 23);
            this.guardarButton.TabIndex = 1;
            this.guardarButton.Text = "Guardar";
            this.guardarButton.UseVisualStyleBackColor = true;
            this.guardarButton.Click += new System.EventHandler(this.GuardarButton_Click);
            // 
            // nomeTextBox
            // 
            this.nomeTextBox.Location = new System.Drawing.Point(229, 69);
            this.nomeTextBox.Name = "nomeTextBox";
            this.nomeTextBox.Size = new System.Drawing.Size(200, 20);
            this.nomeTextBox.TabIndex = 2;
            // 
            // dataNascimentoDateTimePicker
            // 
            this.dataNascimentoDateTimePicker.Location = new System.Drawing.Point(229, 148);
            this.dataNascimentoDateTimePicker.Name = "dataNascimentoDateTimePicker";
            this.dataNascimentoDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.dataNascimentoDateTimePicker.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(226, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Nome";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(226, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Nacionalidade";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(226, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Data de Nascimento";
            // 
            // nacionalidadeComboBox
            // 
            this.nacionalidadeComboBox.FormattingEnabled = true;
            this.nacionalidadeComboBox.Location = new System.Drawing.Point(229, 108);
            this.nacionalidadeComboBox.Name = "nacionalidadeComboBox";
            this.nacionalidadeComboBox.Size = new System.Drawing.Size(200, 21);
            this.nacionalidadeComboBox.TabIndex = 8;
            // 
            // biografiaRichTextBox
            // 
            this.biografiaRichTextBox.Location = new System.Drawing.Point(229, 187);
            this.biografiaRichTextBox.Name = "biografiaRichTextBox";
            this.biografiaRichTextBox.Size = new System.Drawing.Size(355, 207);
            this.biografiaRichTextBox.TabIndex = 9;
            this.biografiaRichTextBox.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(226, 171);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Biografia";
            // 
            // fotoPictureBox
            // 
            this.fotoPictureBox.Location = new System.Drawing.Point(20, 53);
            this.fotoPictureBox.Name = "fotoPictureBox";
            this.fotoPictureBox.Size = new System.Drawing.Size(200, 200);
            this.fotoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.fotoPictureBox.TabIndex = 11;
            this.fotoPictureBox.TabStop = false;
            this.fotoPictureBox.WaitOnLoad = true;
            // 
            // inserirFotoArtistaButton
            // 
            this.inserirFotoArtistaButton.Location = new System.Drawing.Point(148, 259);
            this.inserirFotoArtistaButton.Name = "inserirFotoArtistaButton";
            this.inserirFotoArtistaButton.Size = new System.Drawing.Size(75, 23);
            this.inserirFotoArtistaButton.TabIndex = 13;
            this.inserirFotoArtistaButton.Text = "Inserir Foto";
            this.inserirFotoArtistaButton.UseVisualStyleBackColor = true;
            this.inserirFotoArtistaButton.Click += new System.EventHandler(this.InsertPhotoButton_Click);
            // 
            // cancelarButton
            // 
            this.cancelarButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelarButton.Location = new System.Drawing.Point(509, 413);
            this.cancelarButton.Name = "cancelarButton";
            this.cancelarButton.Size = new System.Drawing.Size(75, 23);
            this.cancelarButton.TabIndex = 14;
            this.cancelarButton.Text = "Cancelar";
            this.cancelarButton.UseVisualStyleBackColor = true;
            this.cancelarButton.Click += new System.EventHandler(this.CancelarButton_Click);
            // 
            // apagarFotoArtistaButton
            // 
            this.apagarFotoArtistaButton.Location = new System.Drawing.Point(20, 259);
            this.apagarFotoArtistaButton.Name = "apagarFotoArtistaButton";
            this.apagarFotoArtistaButton.Size = new System.Drawing.Size(75, 23);
            this.apagarFotoArtistaButton.TabIndex = 15;
            this.apagarFotoArtistaButton.Text = "Apagar Foto";
            this.apagarFotoArtistaButton.UseVisualStyleBackColor = true;
            this.apagarFotoArtistaButton.Click += new System.EventHandler(this.ApagarFotoArtistaButton_Click);
            // 
            // GerirArtistaForm
            // 
            this.AcceptButton = this.guardarButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.CancelButton = this.cancelarButton;
            this.ClientSize = new System.Drawing.Size(601, 448);
            this.Controls.Add(this.apagarFotoArtistaButton);
            this.Controls.Add(this.cancelarButton);
            this.Controls.Add(this.inserirFotoArtistaButton);
            this.Controls.Add(this.fotoPictureBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.biografiaRichTextBox);
            this.Controls.Add(this.nacionalidadeComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataNascimentoDateTimePicker);
            this.Controls.Add(this.nomeTextBox);
            this.Controls.Add(this.guardarButton);
            this.Controls.Add(this.tituloLabel);
            this.Name = "GerirArtistaForm";
            this.Text = "GerirArtista";
            ((System.ComponentModel.ISupportInitialize)(this.fotoPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label tituloLabel;
        private System.Windows.Forms.Button guardarButton;
        private System.Windows.Forms.TextBox nomeTextBox;
        private System.Windows.Forms.DateTimePicker dataNascimentoDateTimePicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox nacionalidadeComboBox;
        private System.Windows.Forms.RichTextBox biografiaRichTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox fotoPictureBox;
        private System.Windows.Forms.Button inserirFotoArtistaButton;
        private System.Windows.Forms.Button cancelarButton;
        private System.Windows.Forms.Button apagarFotoArtistaButton;
    }
}