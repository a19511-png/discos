using discos.Data;
using discos.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace discos.Forms
{
    public partial class VerArtistaForm : Form
    {
        private readonly Artista artista;
        private List<Disco> discos = new List<Disco>();
        private ImageList imageListLarge;
        private ContextMenuStrip itemContextMenu;

        public VerArtistaForm(Artista artista)
        {
            InitializeComponent();
            this.artista = artista;
        }

        private void ArtistaForm_Load(object sender, EventArgs e)
        {
            this.tituloLabel.Text = artista.Nome;

            if (artista.Nacionalidade != null)
            {
                this.nacionalidadeArtistaLabel.Text = Database.ObterNacionalidadePorId(artista.Nacionalidade.Id).Nome;
            }
            else
            {
                this.nacionalidadeArtistaLabel.Visible = false;
            }

            if (artista.DataNascimento != null)
            {
                this.dataNascimentoArtistaLabel.Text = artista.DataNascimento?.ToString("dd/MM/yyyy") + " (" + artista.Idade()?.ToString() + " anos)";
            }
            else
            {
                this.dataNascimentoArtistaLabel.Visible = false;
            }

            if (artista.Biografia != null)
            {
                this.biografiaTextBox.Text = artista.Biografia;
            }
            else
            {
                this.biografiaTextBox.Visible = false;
            }

            this.artistaFotoPictureBox.Image = artista.Imagem;

            imageListLarge = new ImageList();
            imageListLarge.ImageSize = new Size(128, 128);
            imageListLarge.ColorDepth = ColorDepth.Depth32Bit;

            CarregarDiscos();

            listView1.LargeImageList = imageListLarge;
            listView1.DoubleClick += ListView1_DoubleClick;
            listView1.Columns.Add("Nome", 150);
            listView1.Columns.Add("Id", 120);

            itemContextMenu = new ContextMenuStrip();
            ToolStripMenuItem editarDiscoItem = new ToolStripMenuItem("Editar", null, EditarDiscoButton_Click);
            ToolStripMenuItem removerDiscoItem = new ToolStripMenuItem("Remover", null, RemoverDiscoButton_Click);
            itemContextMenu.Items.Add(editarDiscoItem);
            itemContextMenu.Items.Add(new ToolStripSeparator());
            itemContextMenu.Items.Add(removerDiscoItem);

            listView1.ContextMenuStrip = itemContextMenu;

            AtualizarLista();
        }

        private void CarregarDiscos()
        {
            discos.Clear();
            var novoDiscos = Database.ObterDiscosDeUmArtista(artista.Id);

            foreach (var disco in novoDiscos)
            {
                discos.Add(disco);
                if (disco.Imagem != null)
                {
                    imageListLarge.Images.Add(disco.Id.ToString(), disco.Imagem);
                }
            }
        }

        private void AtualizarLista()
        {
            listView1.BeginUpdate();
            foreach (var disco in discos)
            {
                ListViewItem item1 = new ListViewItem(disco.Nome.ToString());
                item1.ImageKey = disco.Id.ToString();
                item1.SubItems.Add(disco.Id.ToString());
                listView1.Items.Add(item1);
            }
            listView1.EndUpdate();
        }

        private void AbrirGerirDiscoForm(Disco disco = null)
        {
            using (GerirDiscoForm gerirDiscoForm = new GerirDiscoForm(disco, artista))
            {
                DialogResult result = gerirDiscoForm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    CarregarDiscos();
                    listView1.Items.Clear();
                    imageListLarge.Images.Clear();
                    CarregarDiscos();
                    AtualizarLista();
                }
            }
        }

        private void AbrirVerDiscoForm(Disco disco)
        {
            using (VerDiscoForm verDiscoForm = new VerDiscoForm(disco))
            {
                DialogResult result = verDiscoForm.ShowDialog();
            }
        }

        private void EditarDiscoButton_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem activeItem = listView1.SelectedItems[0];
                Disco disco = discos.Where(a => a.Id.ToString() == activeItem.SubItems[1].Text).FirstOrDefault();
                AbrirGerirDiscoForm(disco);
            }
        }

        private void ListView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem activeItem = listView1.SelectedItems[0];
                Disco disco = discos.Where(a => a.Id.ToString() == activeItem.SubItems[1].Text).FirstOrDefault();
                AbrirVerDiscoForm(disco);
            }
        }

        private void RemoverDiscoButton_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem activeItem = listView1.SelectedItems[0];
                Disco disco = discos.Where(a => a.Id.ToString() == activeItem.SubItems[1].Text).FirstOrDefault();

                DialogResult result = MessageBox.Show(
                    "Tem a certeza que queres apagar " + disco.Nome + "?",
                    "Apagar Disco",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    Database.ApagarDisco(disco.Id);
                    listView1.Items.Clear();
                    imageListLarge.Images.Clear();
                    CarregarDiscos();
                    AtualizarLista();
                }
            }
        }

        private void NovoDiscoButton_Click(object sender, EventArgs e)
        {
            AbrirGerirDiscoForm();
        }
    }
}
