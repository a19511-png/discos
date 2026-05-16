using discos.Data;
using discos.Models;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace discos.Forms
{
    // <summary>
    // Form principal da aplicação, exibe a lista de artistas e permite navegar para os detalhes de cada artista
    // </summary>
    public partial class MainForm : Form
    {
        // Lista de artistas para exibir na interface
        private readonly BindingList<Artista> artistas = new BindingList<Artista>();

        public MainForm()
        {
            InitializeComponent();
        }

        // Quando o form é aberto vai carregar a lista de artistas
        private void MainForm_Load(object sender, EventArgs e)
        {
            CarregarArtistas();

            // 1. Bind your data source first (assuming employeeBindingList is a BindingList<Employee>)
            dataGridView1.DataSource = artistas;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;

            // 3. Create and add the Delete button column
            DataGridViewButtonColumn viewColumn = new DataGridViewButtonColumn();
            viewColumn.Name = "ViewColumn";
            viewColumn.HeaderText = "";
            viewColumn.Text = "Ver";
            viewColumn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(viewColumn);

            // 2. Create and add the Edit button column
            DataGridViewButtonColumn editColumn = new DataGridViewButtonColumn();
            editColumn.Name = "EditColumn";
            editColumn.HeaderText = "";
            editColumn.Text = "Editar"; // The text that appears on the button
            editColumn.UseColumnTextForButtonValue = true; // Forces all buttons to show the .Text value
            dataGridView1.Columns.Add(editColumn);

            // 3. Create and add the Delete button column
            DataGridViewButtonColumn deleteColumn = new DataGridViewButtonColumn();
            deleteColumn.Name = "DeleteColumn";
            deleteColumn.HeaderText = "";
            deleteColumn.Text = "Remover";
            deleteColumn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(deleteColumn);
        }

        // Metodo para carregar os artistas do banco de dados
        private void CarregarArtistas()
        {
            artistas.Clear();
            var novoArtistas = Database.ListarArtistas();
            foreach (var artista in novoArtistas)
            {
                artistas.Add(artista);
            }
            dataGridView1.Refresh();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // 1. Make sure the user didn't click the column header (RowIndex will be -1)
            if (e.RowIndex >= 0)
            {
                // 2. Get the column name that was clicked
                string columnName = dataGridView1.Columns[e.ColumnIndex].Name;

                // 3. Get the bound object for the row that was clicked
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                Artista artistaSelecionado = (Artista)row.DataBoundItem;

                switch (columnName)
                {
                    case "ViewColumn":
                        VerArtistaForm artistaForm = new VerArtistaForm(artistaSelecionado);
                        artistaForm.Show();
                        break;
                    case "EditColumn":
                        AbrirGerirArtistaForm(artistaSelecionado);
                        break;
                    case "DeleteColumn":
                        // Handle Delete button click
                        DialogResult result = MessageBox.Show($"Tens a certeza que queres apagar {artistaSelecionado.Nome}?",
                                                              "Apagar Artista",
                                                              MessageBoxButtons.YesNo,
                                                              MessageBoxIcon.Warning);
                        if (result == DialogResult.Yes)
                        {
                            //Database.ApagarArtista(artistaSelecionado.Id);
                            CarregarArtistas(); // Refresh the list after deletion
                        }
                        break;
                }
            }
        }

        private void novoArtistaButton_Click(object sender, EventArgs e)
        {
            AbrirGerirArtistaForm();
        }

        private void AbrirGerirArtistaForm(Artista artista = null)
        {
            using (GerirArtistaForm novoArtistaForm = new GerirArtistaForm(artista))
            {
                // 2. Open as a Dialog. THE CODE STOPS HERE UNTIL THE FORM CLOSES.
                DialogResult result = novoArtistaForm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    CarregarArtistas(); // Refresh the list after saving
                }
            }
        }
    }
}
