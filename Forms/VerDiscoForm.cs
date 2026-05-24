using discos.Data;
using discos.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace discos.Forms
{
    public partial class VerDiscoForm : Form
    {
        private readonly Disco _disco;
        private BindingList<Faixa> _faixas = new BindingList<Faixa>();

        public VerDiscoForm(Disco disco)
        {
            InitializeComponent();
            _disco = disco;
        }

        private void VerDiscoForm_Load(object sender, EventArgs e)
        {
            this.tituloLabel.Text = _disco.Nome;

            if (_disco.Genero != null)
            {
                this.generoLabel.Text = Database.ObterGeneroPorId(_disco.Genero.Id).Nome;
            }
            else
            {
                this.generoLabel.Visible = false;
            }

            List<Artista> artistas = Database.ObterIDDeArtistasDeUmDisco(_disco.Id).Select(id => Database.ObterArtistaPorId(id)).ToList();
            if (artistas.Count > 0)
            {
                this.artistasLabel.Text = string.Join(", ", artistas.Select(a => a.Nome));
            }
            else
            {
                this.artistasLabel.Visible = false;
            }

            if (_disco.Ano != null)
            {
                this.dataLancamentoLabel.Text = _disco.Ano.ToString();
            }
            else
            {
                this.dataLancamentoLabel.Visible = false;
            }

            if (_disco.Faixas.Count > 0)
            {
                estatisticasLabel.Text = $"{_disco.Faixas.Count} faixas - {TimeSpan.FromSeconds(_disco.DuracaoTotal()).ToString(@"mm\:ss")}";
            }
            else
            {
                this.estatisticasLabel.Visible = false;
            }

            this.pictureBox.Image = _disco.Imagem;

            _faixas = Database.ObterFaixasDeUmDisco(_disco.Id) != null ? new BindingList<Faixa>(Database.ObterFaixasDeUmDisco(_disco.Id)) : new BindingList<Faixa>();
            faixasDataGridView.DataSource = _faixas;
        }
    }
}
