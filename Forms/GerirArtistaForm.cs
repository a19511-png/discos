using discos.Data;
using discos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace discos.Forms
{
    // <summary>
    // Form para gerir artistas, pode ser usado para criar ou editar um artista dependo se um artista é passado ou não no construtor
    // </summary>
    public partial class GerirArtistaForm : Form
    {
        private bool editar = false; // Indica se o form está em modo de edição (true) ou criação (false)
        private List<Nacionalidade> nacionalidades = new List<Nacionalidade>(); // Lista de nacionalidades para preencher o combo box
        private Artista _artista; // Artista a ser editado, se estiver em modo de edição

        public GerirArtistaForm(Artista artista = null)
        {
            InitializeComponent();

            _artista = artista;

            nacionalidades.Clear();
            nacionalidades = Database.ListarNacionalidades(); // Carrega as nacionalidades do banco de dados

            foreach (var nacionalidade in nacionalidades)
            {
                nacionalidadeComboBox.Items.Add(nacionalidade.Nome); // Preenche o combo box com os nomes das nacionalidades
            }


            if (artista != null)
            {

                editar = true;
                label1.Text = "Editar Artista";
                nomeTextBox.Text = _artista.Nome;
                dataNascimentoDateTimePicker.Value = _artista.DataNascimento ?? DateTime.Now; // Define a data de nascimento, se for nula usa a data atual
                richTextBox1.Text = _artista.Biografia;
                nacionalidadeComboBox.SelectedItem = _artista.Nacionalidade?.Nome; // Seleciona a nacionalidade no combo box, se existir
            }
            else
            {
                editar = false;
                label1.Text = "Criar Artista";
            }
        }

        private void guardarButton_Click(object sender, EventArgs e)
        {
            if (editar)
            {
                _artista.Nome = nomeTextBox.Text;
                _artista.DataNascimento = dataNascimentoDateTimePicker.Value;
                _artista.Nacionalidade = nacionalidades.FirstOrDefault(n => n.Nome == nacionalidadeComboBox.SelectedItem.ToString());
                _artista.Biografia = richTextBox1.Text;
                Database.AtualizarArtista(_artista); // Atualiza o artista no banco de dados


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
                    Biografia = richTextBox1.Text
                }

                );
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
