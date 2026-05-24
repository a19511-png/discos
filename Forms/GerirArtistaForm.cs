using discos.Data;
using discos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace discos.Forms
{
    public partial class GerirArtistaForm : Form
    {
        private bool editar = false;
        private List<Nacionalidade> nacionalidades = new List<Nacionalidade>();
        private Artista _artista;

        public GerirArtistaForm(Artista artista = null)
        {
            InitializeComponent();

            _artista = artista;

            nacionalidades.Clear();
            nacionalidades = Database.ObterNacionalidades();

            foreach (var nacionalidade in nacionalidades)
            {
                nacionalidadeComboBox.Items.Add(nacionalidade.Nome);
            }


            if (artista != null)
            {
                editar = true;
                tituloLabel.Text = "Editar Artista";
                nomeTextBox.Text = _artista.Nome;
                dataNascimentoDateTimePicker.Value = _artista.DataNascimento ?? DateTime.Now;
                biografiaRichTextBox.Text = _artista.Biografia;
                nacionalidadeComboBox.SelectedItem = nacionalidades.FirstOrDefault(n => n.Id == _artista.Nacionalidade.Id).Nome;
                fotoPictureBox.Image = _artista.Imagem;
            }
            else
            {
                editar = false;
                tituloLabel.Text = "Criar Artista";
            }
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            if (editar)
            {
                _artista.Nome = nomeTextBox.Text;
                _artista.DataNascimento = dataNascimentoDateTimePicker.Value;
                _artista.Nacionalidade = nacionalidades.FirstOrDefault(n => n.Nome == nacionalidadeComboBox.SelectedItem.ToString());
                _artista.Biografia = biografiaRichTextBox.Text;
                _artista.Imagem = fotoPictureBox.Image;
                Database.AtualizarArtista(_artista);
            }
            else
            {
                Database.InserirArtista
                (
                    new Artista
                    {
                        Nome = nomeTextBox.Text,
                        DataNascimento = dataNascimentoDateTimePicker.Value,
                        Nacionalidade = nacionalidades.FirstOrDefault(n => n.Nome == nacionalidadeComboBox.SelectedItem.ToString()),
                        Biografia = biografiaRichTextBox.Text,
                        Imagem = fotoPictureBox.Image
                    }
                );
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void InsertPhotoButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
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

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void ApagarFotoArtistaButton_Click(object sender, EventArgs e)
        {
            fotoPictureBox.Image = null;
        }
    }
}
