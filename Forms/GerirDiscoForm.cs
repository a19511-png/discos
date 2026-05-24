using discos.Data;
using discos.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace discos.Forms
{
    public partial class GerirDiscoForm : Form
    {
        private bool editar = false;
        private List<Genero> generos = new List<Genero>();
        private List<Artista> artistas = new List<Artista>();
        private List<int> artistasDoDisco = new List<int>();
        private Disco _disco;
        private BindingList<Faixa> _faixas = new BindingList<Faixa>();
        private Artista _artistaOrigem;

        public GerirDiscoForm(Disco disco, Artista artista = null)
        {
            InitializeComponent();

            _disco = disco;
            _artistaOrigem = artista;
            anoNumericUpDown.Value = DateTime.Now.Year;
        }


        private void GerirDiscoForm_Load(object sender, EventArgs e)
        {
            generos.Clear();
            generos = Database.ObterGeneros();

            foreach (var genero in generos)
            {
                generoComboBox.Items.Add(genero.Nome);
            }

            artistas.Clear();
            artistas = Database.ObterListaDeArtistas();

            artistasCheckedListBox.DataSource = artistas;
            artistasCheckedListBox.DisplayMember = "Nome";
            artistasCheckedListBox.ValueMember = "Id";

            for (int i = 0; i < artistasCheckedListBox.Items.Count; i++)
            {
                Artista artistaNaLista = (Artista)artistasCheckedListBox.Items[i];

                if (artistasDoDisco.Contains(artistaNaLista.Id) || artistaNaLista.Id == _artistaOrigem.Id)
                {
                    artistasCheckedListBox.SetItemChecked(i, true);
                }
                else
                {
                    artistasCheckedListBox.SetItemChecked(i, false);
                }
            }

            if (_disco != null)
            {
                editar = true;
                tituloLabel.Text = "Editar Disco";
                nomeTextBox.Text = _disco.Nome;
                anoNumericUpDown.Value = _disco.Ano;
                generoComboBox.SelectedItem = generos.FirstOrDefault(n => n.Id == _disco.Genero.Id).Nome;
                fotoPictureBox.Image = _disco.Imagem;
                artistasDoDisco = Database.ObterIDDeArtistasDeUmDisco(_disco.Id);
                _faixas = new BindingList<Faixa>(Database.ObterFaixasDeUmDisco(_disco.Id));
            }
            else
            {
                editar = false;
                tituloLabel.Text = "Novo Disco";
            }

            faixasDataGridView.DataSource = _faixas;
        }

        private void InserirFotoButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                openFileDialog.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.gif;*.bmp)|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFilePath = openFileDialog.FileName;

                    fotoPictureBox.ImageLocation = selectedFilePath;
                }
            }
        }

        private void ApagarFotoButton_Click(object sender, EventArgs e)
        {
            fotoPictureBox.Image = null;
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            if (editar)
            {
                _disco.Nome = nomeTextBox.Text;
                _disco.Ano = (int)anoNumericUpDown.Value;
                _disco.Genero = generos.FirstOrDefault(n => n.Nome == generoComboBox.SelectedItem.ToString());
                _disco.Imagem = fotoPictureBox.Image;
                Database.AtualizarDisco(_disco);

            }
            else
            {
                int novoId = Database.InserirDisco
                (
                    new Disco
                    {
                        Nome = nomeTextBox.Text,
                        Ano = (int)anoNumericUpDown.Value,
                        Genero = generos.FirstOrDefault(n => n.Nome == generoComboBox.SelectedItem.ToString()),
                        Imagem = fotoPictureBox.Image
                    }
                );

                for (int i = 0; i < artistasCheckedListBox.CheckedItems.Count; i++)
                {
                    Artista artistaNaLista = (Artista)artistasCheckedListBox.Items[i];
                    Database.AssociarArtistaADisco(artistaNaLista.Id, novoId);
                }

                foreach (var faixa in _faixas)
                {
                    Database.InserirFaixa(faixa, novoId);
                }
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
