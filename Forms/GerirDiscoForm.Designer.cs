namespace discos.Forms
{
    partial class GerirDiscoForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.nomeTextBox = new System.Windows.Forms.TextBox();
            this.tituloLabel = new System.Windows.Forms.Label();
            this.apagarFotoButton = new System.Windows.Forms.Button();
            this.inserirFotoButton = new System.Windows.Forms.Button();
            this.fotoPictureBox = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.generoComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.anoNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.artistasCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cancelarButton = new System.Windows.Forms.Button();
            this.guardarButton = new System.Windows.Forms.Button();
            this.faixasDataGridView = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.fotoPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.anoNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.faixasDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(225, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Nome";
            // 
            // nomeTextBox
            // 
            this.nomeTextBox.Location = new System.Drawing.Point(228, 65);
            this.nomeTextBox.Name = "nomeTextBox";
            this.nomeTextBox.Size = new System.Drawing.Size(236, 20);
            this.nomeTextBox.TabIndex = 7;
            // 
            // tituloLabel
            // 
            this.tituloLabel.AutoSize = true;
            this.tituloLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tituloLabel.Location = new System.Drawing.Point(12, 9);
            this.tituloLabel.Name = "tituloLabel";
            this.tituloLabel.Size = new System.Drawing.Size(163, 37);
            this.tituloLabel.TabIndex = 6;
            this.tituloLabel.Text = "tituloLabel";
            // 
            // apagarFotoButton
            // 
            this.apagarFotoButton.Location = new System.Drawing.Point(12, 255);
            this.apagarFotoButton.Name = "apagarFotoButton";
            this.apagarFotoButton.Size = new System.Drawing.Size(75, 23);
            this.apagarFotoButton.TabIndex = 18;
            this.apagarFotoButton.Text = "Apagar Foto";
            this.apagarFotoButton.UseVisualStyleBackColor = true;
            this.apagarFotoButton.Click += new System.EventHandler(this.ApagarFotoButton_Click);
            // 
            // inserirFotoButton
            // 
            this.inserirFotoButton.Location = new System.Drawing.Point(140, 255);
            this.inserirFotoButton.Name = "inserirFotoButton";
            this.inserirFotoButton.Size = new System.Drawing.Size(75, 23);
            this.inserirFotoButton.TabIndex = 17;
            this.inserirFotoButton.Text = "Inserir Foto";
            this.inserirFotoButton.UseVisualStyleBackColor = true;
            this.inserirFotoButton.Click += new System.EventHandler(this.InserirFotoButton_Click);
            // 
            // fotoPictureBox
            // 
            this.fotoPictureBox.Location = new System.Drawing.Point(12, 49);
            this.fotoPictureBox.Name = "fotoPictureBox";
            this.fotoPictureBox.Size = new System.Drawing.Size(200, 200);
            this.fotoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.fotoPictureBox.TabIndex = 16;
            this.fotoPictureBox.TabStop = false;
            this.fotoPictureBox.WaitOnLoad = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(225, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Data de Lançamento";
            // 
            // generoComboBox
            // 
            this.generoComboBox.FormattingEnabled = true;
            this.generoComboBox.Location = new System.Drawing.Point(338, 105);
            this.generoComboBox.Name = "generoComboBox";
            this.generoComboBox.Size = new System.Drawing.Size(126, 21);
            this.generoComboBox.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(335, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Genero";
            // 
            // anoNumericUpDown
            // 
            this.anoNumericUpDown.Location = new System.Drawing.Point(228, 105);
            this.anoNumericUpDown.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.anoNumericUpDown.Name = "anoNumericUpDown";
            this.anoNumericUpDown.Size = new System.Drawing.Size(104, 20);
            this.anoNumericUpDown.TabIndex = 23;
            this.anoNumericUpDown.Value = new decimal(new int[] {
            1970,
            0,
            0,
            0});
            // 
            // artistasCheckedListBox
            // 
            this.artistasCheckedListBox.FormattingEnabled = true;
            this.artistasCheckedListBox.Location = new System.Drawing.Point(228, 144);
            this.artistasCheckedListBox.Name = "artistasCheckedListBox";
            this.artistasCheckedListBox.Size = new System.Drawing.Size(236, 139);
            this.artistasCheckedListBox.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(225, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Artistas";
            // 
            // cancelarButton
            // 
            this.cancelarButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelarButton.Location = new System.Drawing.Point(395, 644);
            this.cancelarButton.Name = "cancelarButton";
            this.cancelarButton.Size = new System.Drawing.Size(75, 23);
            this.cancelarButton.TabIndex = 27;
            this.cancelarButton.Text = "Cancelar";
            this.cancelarButton.UseVisualStyleBackColor = true;
            this.cancelarButton.Click += new System.EventHandler(this.CancelarButton_Click);
            // 
            // guardarButton
            // 
            this.guardarButton.Location = new System.Drawing.Point(314, 644);
            this.guardarButton.Name = "guardarButton";
            this.guardarButton.Size = new System.Drawing.Size(75, 23);
            this.guardarButton.TabIndex = 26;
            this.guardarButton.Text = "Guardar";
            this.guardarButton.UseVisualStyleBackColor = true;
            this.guardarButton.Click += new System.EventHandler(this.GuardarButton_Click);
            // 
            // faixasDataGridView
            // 
            this.faixasDataGridView.AllowUserToOrderColumns = true;
            this.faixasDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.faixasDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.faixasDataGridView.Location = new System.Drawing.Point(12, 346);
            this.faixasDataGridView.Name = "faixasDataGridView";
            this.faixasDataGridView.Size = new System.Drawing.Size(452, 292);
            this.faixasDataGridView.TabIndex = 28;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(14, 314);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 25);
            this.label5.TabIndex = 29;
            this.label5.Text = "Faixas";
            // 
            // GerirDiscoForm
            // 
            this.AcceptButton = this.guardarButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.cancelarButton;
            this.ClientSize = new System.Drawing.Size(482, 685);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.faixasDataGridView);
            this.Controls.Add(this.cancelarButton);
            this.Controls.Add(this.guardarButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.artistasCheckedListBox);
            this.Controls.Add(this.anoNumericUpDown);
            this.Controls.Add(this.generoComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.apagarFotoButton);
            this.Controls.Add(this.inserirFotoButton);
            this.Controls.Add(this.fotoPictureBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nomeTextBox);
            this.Controls.Add(this.tituloLabel);
            this.Name = "GerirDiscoForm";
            this.Text = "GerirDiscoForm";
            this.Load += new System.EventHandler(this.GerirDiscoForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fotoPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.anoNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.faixasDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nomeTextBox;
        private System.Windows.Forms.Label tituloLabel;
        private System.Windows.Forms.Button apagarFotoButton;
        private System.Windows.Forms.Button inserirFotoButton;
        private System.Windows.Forms.PictureBox fotoPictureBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox generoComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown anoNumericUpDown;
        private System.Windows.Forms.CheckedListBox artistasCheckedListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cancelarButton;
        private System.Windows.Forms.Button guardarButton;
        private System.Windows.Forms.DataGridView faixasDataGridView;
        private System.Windows.Forms.Label label5;
    }
}