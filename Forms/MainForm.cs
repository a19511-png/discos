using discos.Data;
using discos.Models;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace discos.Forms
{
    public partial class MainForm : Form
    {
        // Lista de artistas para exibir na interface
        private readonly BindingList<Artista> artistas = new BindingList<Artista>();
        private ImageList imageListLarge;
        private ContextMenuStrip itemContextMenu;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            imageListLarge = new ImageList();
            imageListLarge.ImageSize = new Size(256, 256);
            imageListLarge.ColorDepth = ColorDepth.Depth32Bit;

            CarregarArtistas();

            listView1.LargeImageList = imageListLarge;
            listView1.DoubleClick += ListView1_DoubleClick;

            listView1.Columns.Add("Nome", 150);
            listView1.Columns.Add("Id", 120);

            itemContextMenu = new ContextMenuStrip();
            ToolStripMenuItem editarArtistaItem = new ToolStripMenuItem("Editar", null, editarArtistaButton_Click);
            ToolStripMenuItem removerArtistaItem = new ToolStripMenuItem("Remover", null, removerArtistaButton_Click);

            itemContextMenu.Items.Add(editarArtistaItem);
            itemContextMenu.Items.Add(new ToolStripSeparator());
            itemContextMenu.Items.Add(removerArtistaItem);

            listView1.ContextMenuStrip = itemContextMenu;

            AtualizarLista();
        }

        private void CarregarArtistas()
        {
            artistas.Clear();
            var novoArtistas = Database.ObterListaDeArtistas();

            foreach (var artista in novoArtistas)
            {
                artistas.Add(artista);
                if (artista.Imagem != null)
                {
                    imageListLarge.Images.Add(artista.Id.ToString(), artista.Imagem);
                }
            }
        }

        private void AtualizarLista()
        {
            listView1.BeginUpdate();
            foreach (var artista in artistas)
            {
                ListViewItem item1 = new ListViewItem(artista.Nome.ToString());
                item1.ImageKey = artista.Id.ToString();
                item1.SubItems.Add(artista.Id.ToString());
                listView1.Items.Add(item1);
            }
            listView1.EndUpdate();
        }

        private void AbrirGerirArtistaForm(Artista artista = null)
        {
            using (GerirArtistaForm novoArtistaForm = new GerirArtistaForm(artista))
            {
                DialogResult result = novoArtistaForm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    CarregarArtistas();
                    listView1.Items.Clear();
                    imageListLarge.Images.Clear();
                    CarregarArtistas();
                    AtualizarLista();
                }
            }
        }

        private void AbrirVerArtistaForm(Artista artista)
        {
            using (VerArtistaForm verArtistaForm = new VerArtistaForm(artista))
            {
                DialogResult result = verArtistaForm.ShowDialog();
            }
        }

        private void novoArtistaButton_Click(object sender, EventArgs e)
        {
            AbrirGerirArtistaForm();
        }

        private void editarArtistaButton_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem activeItem = listView1.SelectedItems[0];
                Artista artista = artistas.Where(a => a.Id.ToString() == activeItem.SubItems[1].Text).FirstOrDefault();
                AbrirGerirArtistaForm(artista);
            }
        }

        private void ListView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem activeItem = listView1.SelectedItems[0];
                Artista artista = artistas.Where(a => a.Id.ToString() == activeItem.SubItems[1].Text).FirstOrDefault();
                AbrirVerArtistaForm(artista);
            }
        }

        private void removerArtistaButton_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem activeItem = listView1.SelectedItems[0];
                Artista artista = artistas.Where(a => a.Id.ToString() == activeItem.SubItems[1].Text).FirstOrDefault();

                DialogResult result = MessageBox.Show(
                    "Tem a certeza que queres apagar " + artista.Nome + "?",
                    "Apagar Artista",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    Database.ApagarArtista(artista.Id);
                    listView1.Items.Clear();
                    imageListLarge.Images.Clear();
                    CarregarArtistas();
                    AtualizarLista();
                }
            }
        }
    }
}
