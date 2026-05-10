using discos.Data;
using discos.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace discos.Forms
{
    // <summary>
    // Form para gerir artistas, pode ser usado para criar ou editar um artista dependo se um artista é passado ou não no construtor
    // </summary>
    public partial class GerirArtistaForm : Form
    {
        private bool editar = false; // Indica se o form está em modo de edição (true) ou criação (false)

        public GerirArtistaForm(Artista artista = null)
        {
            InitializeComponent();

            if (artista != null)
            {
                editar = true;
                label1.Text = "Editar Artista";
            }
            else
            {
                editar = false;
                label1.Text = "Criar Artista";
            }
        }

        private void guardarButton_Click(object sender, EventArgs e)
        {
            Database.InserirArtista
                (
                nomeTextBox.Text,
                nacionalidadeTextBox.Text,
                dataNascimentoDateTimePicker.Value
            );

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
