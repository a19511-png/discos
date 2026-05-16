using discos.Models;
using System;
using System.Windows.Forms;

namespace discos.Forms
{
    // <summary>
    // Form para exibir os detalhes de um artista, incluindo os seus discos e faixas
    // </summary>
    public partial class VerArtistaForm : Form
    {
        private readonly Artista artista; // Artista para exibir os detalhes

        // Recebe um artista para exibir os detalhes
        public VerArtistaForm(Artista artista)
        {
            InitializeComponent();
            this.artista = artista;
            this.label1.Text = artista.Nome; // Exibe o nome do artista no label
        }

        // Quando o form é aberto vai carregar os discos do artista
        private void ArtistaForm_Load(object sender, EventArgs e)
        {

        }
    }
}
