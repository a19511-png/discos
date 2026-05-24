namespace discos.Forms
{
    partial class VerDiscoForm
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
            this.dataLancamentoLabel = new System.Windows.Forms.Label();
            this.generoLabel = new System.Windows.Forms.Label();
            this.artistasLabel = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.tituloLabel = new System.Windows.Forms.Label();
            this.faixasDataGridView = new System.Windows.Forms.DataGridView();
            this.estatisticasLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.faixasDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataLancamentoLabel
            // 
            this.dataLancamentoLabel.AutoSize = true;
            this.dataLancamentoLabel.Location = new System.Drawing.Point(218, 74);
            this.dataLancamentoLabel.Name = "dataLancamentoLabel";
            this.dataLancamentoLabel.Size = new System.Drawing.Size(113, 13);
            this.dataLancamentoLabel.TabIndex = 20;
            this.dataLancamentoLabel.Text = "dataLancamentoLabel";
            // 
            // generoLabel
            // 
            this.generoLabel.AutoSize = true;
            this.generoLabel.Location = new System.Drawing.Point(349, 74);
            this.generoLabel.Name = "generoLabel";
            this.generoLabel.Size = new System.Drawing.Size(66, 13);
            this.generoLabel.TabIndex = 19;
            this.generoLabel.Text = "generoLabel";
            // 
            // artistasLabel
            // 
            this.artistasLabel.AutoSize = true;
            this.artistasLabel.Location = new System.Drawing.Point(218, 49);
            this.artistasLabel.Name = "artistasLabel";
            this.artistasLabel.Size = new System.Drawing.Size(66, 13);
            this.artistasLabel.TabIndex = 18;
            this.artistasLabel.Text = "artistasLabel";
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(12, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(200, 200);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 17;
            this.pictureBox.TabStop = false;
            this.pictureBox.WaitOnLoad = true;
            // 
            // tituloLabel
            // 
            this.tituloLabel.AutoSize = true;
            this.tituloLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tituloLabel.Location = new System.Drawing.Point(214, 12);
            this.tituloLabel.Name = "tituloLabel";
            this.tituloLabel.Size = new System.Drawing.Size(163, 37);
            this.tituloLabel.TabIndex = 16;
            this.tituloLabel.Text = "tituloLabel";
            // 
            // faixasDataGridView
            // 
            this.faixasDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.faixasDataGridView.Location = new System.Drawing.Point(12, 218);
            this.faixasDataGridView.Name = "faixasDataGridView";
            this.faixasDataGridView.ReadOnly = true;
            this.faixasDataGridView.Size = new System.Drawing.Size(776, 220);
            this.faixasDataGridView.TabIndex = 21;
            // 
            // estatisticasLabel
            // 
            this.estatisticasLabel.AutoSize = true;
            this.estatisticasLabel.Location = new System.Drawing.Point(218, 102);
            this.estatisticasLabel.Name = "estatisticasLabel";
            this.estatisticasLabel.Size = new System.Drawing.Size(85, 13);
            this.estatisticasLabel.TabIndex = 22;
            this.estatisticasLabel.Text = "estatisticasLabel";
            // 
            // VerDiscoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.estatisticasLabel);
            this.Controls.Add(this.faixasDataGridView);
            this.Controls.Add(this.dataLancamentoLabel);
            this.Controls.Add(this.generoLabel);
            this.Controls.Add(this.artistasLabel);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.tituloLabel);
            this.Name = "VerDiscoForm";
            this.Text = "VerDiscoForm";
            this.Load += new System.EventHandler(this.VerDiscoForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.faixasDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label dataLancamentoLabel;
        private System.Windows.Forms.Label generoLabel;
        private System.Windows.Forms.Label artistasLabel;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label tituloLabel;
        private System.Windows.Forms.DataGridView faixasDataGridView;
        private System.Windows.Forms.Label estatisticasLabel;
    }
}