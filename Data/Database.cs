using discos.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace discos.Data
{
    public static class Database
    {
        // Vai buscar o caminho de ligação à base de dados definido nas configurações (App.config ou Web.config)
        private static string _connectionString = ConfigurationManager.ConnectionStrings["MySqlDatabase"].ConnectionString;

        /// <summary>
        /// Verifica se as credenciais inseridas existem na tabela de login.
        /// </summary>
        public static bool VerificarLogin(string username, string password)
        {
            bool loginValido = false;

            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open(); // Abrir ligação

                // CUIDADO: Usar sempre @parametros para evitar ataques de SQL Injection!
                string sql = "SELECT COUNT(*) FROM login WHERE username = @user AND passwrd = @pass";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@user", username);
                    cmd.Parameters.AddWithValue("@pass", password);

                    // ExecuteScalar devolve a primeira coluna da primeira linha. Neste caso, o COUNT.
                    int quantidade = Convert.ToInt32(cmd.ExecuteScalar());

                    if (quantidade > 0)
                    {
                        loginValido = true;
                    }
                }
            }
            return loginValido;
        }

        /// <summary>
        /// Obtém a lista com as Nacionalidades para ser usado em seleções (ex: ComboBox).
        /// </summary>
        public static List<Nacionalidade> ObterNacionalidades()
        {
            var lista = new List<Nacionalidade>();

            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "SELECT id, nome FROM nacionalidade ORDER BY nome ASC"; // ORDER BY organiza alfabeticamente

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Nacionalidade n = new Nacionalidade();
                        n.Id = reader["id"].ToString();
                        n.Nome = reader["nome"].ToString();
                        lista.Add(n);
                    }
                }
            }
            return lista;
        }

        /// <summary>
        /// Obtém o nome e os dados de uma Nacionalidade específica através do seu ID (ex: "PT").
        /// </summary>
        public static Nacionalidade ObterNacionalidadePorId(string id)
        {
            Nacionalidade nacionalidade = null; // Começa vazio

            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "SELECT id, nome FROM nacionalidade WHERE id = @id";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    // Passamos o texto (string) que representa a sigla do país
                    cmd.Parameters.AddWithValue("@id", id);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read()) // Se encontrou a nacionalidade na base de dados...
                        {
                            nacionalidade = new Nacionalidade();
                            nacionalidade.Id = reader["id"].ToString();
                            nacionalidade.Nome = reader["nome"].ToString();
                        }
                    }
                }
            }

            // Se encontrar devolve o objeto preenchido, caso contrário devolve 'null'
            return nacionalidade;
        }

        /// <summary>
        /// Obtém a lista dos Géneros Musicais.
        /// </summary>
        public static List<Genero> ObterGeneros()
        {
            var lista = new List<Genero>(); // Cria uma caixa vazia para guardar géneros

            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "SELECT id, nome FROM genero ORDER BY nome ASC";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read()) // Vai lendo uma linha do SQL de cada vez
                    {
                        Genero g = new Genero();
                        g.Id = Convert.ToInt32(reader["id"]);
                        g.Nome = reader["nome"].ToString();
                        lista.Add(g); // Põe o género na "caixa" (lista)
                    }
                }
            }
            return lista;
        }

        /// <summary>
        /// Obtém o nome de um Género Musical específico através do seu ID (ex: 1, 2, 3...).
        /// </summary>
        public static Genero ObterGeneroPorId(int id)
        {
            Genero genero = null; // Começa vazio, caso não encontre

            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "SELECT id, nome FROM genero WHERE id = @id";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id); // Adicionamos o número usado na procura

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read()) // Se o género existir na base de dados...
                        {
                            genero = new Genero();
                            genero.Id = Convert.ToInt32(reader["id"]);
                            genero.Nome = reader["nome"].ToString();
                        }
                    }
                }
            }

            // Devolve o Género com os dados preenchidos, ou "null" se o ID não existir
            return genero;
        }

        #region Artistas

        /// <summary>
        /// Devolve uma Lista com todos os Artistas da base de dados.
        /// </summary>
        public static List<Artista> ObterListaDeArtistas()
        {
            var lista = new List<Artista>();

            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "SELECT id, nome, nacionalidade_id, dataNascimento, biografia, imagem FROM artista";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read()) // Enquanto houver linhas para ler...
                    {
                        // Criamos um novo objeto artista e preenchemos os dados
                        Artista a = new Artista();
                        a.Id = Convert.ToInt32(reader["id"]);
                        a.Nome = reader["nome"].ToString();

                        // Verificações para campos que podem estar vazios (NULL na base de dados)
                        if (reader["dataNascimento"] != DBNull.Value)
                            a.DataNascimento = Convert.ToDateTime(reader["dataNascimento"]);

                        if (reader["biografia"] != DBNull.Value)
                            a.Biografia = reader["biografia"].ToString();

                        if (reader["imagem"] != DBNull.Value)
                            a.Imagem = Helpers.ByteArrayToImage((byte[])reader["imagem"]);

                        if (reader["nacionalidade_id"] != DBNull.Value)
                            a.Nacionalidade = new Nacionalidade { Id = reader["nacionalidade_id"].ToString() };

                        lista.Add(a); // Guarda o artista na nossa lista
                    }
                }
            }
            return lista;
        }

        /// <summary>
        /// Obtém os detalhes de um único artista através do seu ID.
        /// </summary>
        public static Artista ObterArtistaPorId(int id)
        {
            Artista artista = null; // Começa vazio

            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM artista WHERE id = @id";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read()) // Se encontrou o artista...
                        {
                            artista = new Artista();
                            artista.Id = Convert.ToInt32(reader["id"]);
                            artista.Nome = reader["nome"].ToString();

                            if (reader["dataNascimento"] != DBNull.Value)
                                artista.DataNascimento = Convert.ToDateTime(reader["dataNascimento"]);

                            if (reader["biografia"] != DBNull.Value)
                                artista.Biografia = reader["biografia"].ToString();

                            if (reader["imagem"] != DBNull.Value)
                                artista.Imagem = Helpers.ByteArrayToImage((byte[])reader["imagem"]);

                            if (reader["nacionalidade_id"] != DBNull.Value)
                                artista.Nacionalidade = new Nacionalidade { Id = reader["nacionalidade_id"].ToString() };
                        }
                    }
                }
            }
            return artista;
        }

        /// <summary>
        /// Insere um novo artista na base de dados.
        /// </summary>
        public static void InserirArtista(Artista artista)
        {
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                string sql = @"INSERT INTO artista (nome, nacionalidade_id, dataNascimento, biografia, imagem) 
                               VALUES (@nome, @nac_id, @data, @bio, @img)";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@nome", artista.Nome);

                    // Se a propriedade existir enviamos o valor, senão enviamos "DBNull.Value" (vazio)
                    cmd.Parameters.AddWithValue("@nac_id", artista.Nacionalidade?.Id ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@data", artista.DataNascimento ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@bio", artista.Biografia ?? (object)DBNull.Value);

                    byte[] bytesImagem = default;
                    if (artista.Imagem != null) bytesImagem = Helpers.ImageToByteArray(artista.Imagem);
                    cmd.Parameters.AddWithValue("@img", bytesImagem ?? (object)DBNull.Value);

                    cmd.ExecuteNonQuery(); // Executa o comando de Inserção
                }
            }
        }

        /// <summary>
        /// Atualiza a informação de um artista existente.
        /// </summary>
        public static void AtualizarArtista(Artista artista)
        {
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                string sql = @"UPDATE artista SET 
                                nome = @nome, 
                                nacionalidade_id = @nac_id, 
                                dataNascimento = @data, 
                                biografia = @bio, 
                                imagem = @img 
                               WHERE id = @id";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", artista.Id); // ID é necessário para saber qual atualizar
                    cmd.Parameters.AddWithValue("@nome", artista.Nome);
                    cmd.Parameters.AddWithValue("@nac_id", artista.Nacionalidade?.Id ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@data", artista.DataNascimento ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@bio", artista.Biografia ?? (object)DBNull.Value);

                    byte[] bytesImagem = default;
                    if (artista.Imagem != null) bytesImagem = Helpers.ImageToByteArray(artista.Imagem);
                    cmd.Parameters.AddWithValue("@img", bytesImagem ?? (object)DBNull.Value);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Apaga definitivamente um artista pelo ID.
        /// </summary>
        public static void ApagarArtista(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "DELETE FROM artista WHERE id = @id";
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        #endregion

        #region Discos

        /// <summary>
        /// Obtém os detalhes completos de um Disco por ID.
        /// </summary>
        public static Disco ObterDiscoPorId(int id)
        {
            Disco disco = null;

            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM disco WHERE id = @id";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read()) // Se encontrou
                        {
                            disco = new Disco();
                            disco.Id = Convert.ToInt32(reader["id"]);
                            disco.Nome = reader["nome"].ToString();
                            disco.Ano = Convert.ToInt32(reader["ano"]);

                            if (reader["letra"] != DBNull.Value)
                                disco.Letra = reader["letra"].ToString();

                            // As imagens no objeto Disco estão em byte[], logo a conversão é direta
                            if (reader["imagem"] != DBNull.Value)
                                disco.Imagem = Helpers.ByteArrayToImage((byte[])reader["imagem"]);

                            if (reader["genero_id"] != DBNull.Value)
                                disco.Genero = new Genero { Id = Convert.ToInt32(reader["genero_id"]) };
                        }
                    }
                }
            }
            return disco;
        }

        /// <summary>
        /// Obter todos os discos em que um determinado Artista participa.
        /// (Cruza a tabela 'artista_disco' com a 'disco')
        /// </summary>
        public static List<Disco> ObterDiscosDeUmArtista(int artistaId)
        {
            var lista = new List<Disco>();

            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                // Ligamos (INNER JOIN) a tabela disco com a tabela de relação para encontrar os discos do artista
                string sql = @"SELECT d.* FROM disco d
                               INNER JOIN artista_disco ad ON d.id = ad.disco_id
                               WHERE ad.artista_id = @artistaId";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@artistaId", artistaId);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Disco disco = new Disco();
                            disco.Id = Convert.ToInt32(reader["id"]);
                            disco.Nome = reader["nome"].ToString();
                            disco.Ano = Convert.ToInt32(reader["ano"]);

                            if (reader["letra"] != DBNull.Value)
                                disco.Letra = reader["letra"].ToString();

                            // As imagens no objeto Disco estão em byte[], logo a conversão é direta
                            if (reader["imagem"] != DBNull.Value)
                                disco.Imagem = Helpers.ByteArrayToImage((byte[])reader["imagem"]);

                            if (reader["genero_id"] != DBNull.Value)
                                disco.Genero = new Genero { Id = Convert.ToInt32(reader["genero_id"]) };
                            lista.Add(disco);
                        }
                    }
                }
            }
            return lista;
        }

        /// <summary>
        /// Devolve uma lista apenas com os IDs Numéricos dos artistas que participam no disco especificado.
        /// </summary>
        public static List<int> ObterIDDeArtistasDeUmDisco(int discoId)
        {
            var ids = new List<int>();

            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "SELECT artista_id FROM artista_disco WHERE disco_id = @id";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", discoId);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ids.Add(Convert.ToInt32(reader["artista_id"]));
                        }
                    }
                }
            }
            return ids;
        }

        /// <summary>
        /// Insere o Disco na base de dados.
        /// </summary>
        public static int InserirDisco(Disco disco)
        {
            int novoId = 0;

            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();

                // O "SELECT LAST_INSERT_ID();" devolve o número do ID assim que o disco é criado!
                string sql = @"INSERT INTO disco (nome, ano, letra, genero_id, imagem) 
                               VALUES (@nome, @ano, @letra, @gen_id, @img);
                               SELECT LAST_INSERT_ID();";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@nome", disco.Nome);
                    cmd.Parameters.AddWithValue("@ano", disco.Ano);
                    cmd.Parameters.AddWithValue("@letra", disco.Letra ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@gen_id", disco.Genero?.Id ?? (object)DBNull.Value);

                    byte[] bytesImagem = default;
                    if (disco.Imagem != null) bytesImagem = Helpers.ImageToByteArray(disco.Imagem);
                    cmd.Parameters.AddWithValue("@img", bytesImagem ?? (object)DBNull.Value);

                    // ExecuteScalar guarda o valor devolvido pela query (O Last Insert ID)
                    novoId = Convert.ToInt32(cmd.ExecuteScalar());
                    disco.Id = novoId; // Atualiza no objeto que foi passado
                }
            }
            return novoId;
        }

        /// <summary>
        /// Atualiza um Disco existente (não afeta as Faixas).
        /// </summary>
        public static void AtualizarDisco(Disco disco)
        {
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                string sql = @"UPDATE disco SET 
                                nome = @nome, 
                                ano = @ano, 
                                letra = @letra, 
                                genero_id = @gen_id, 
                                imagem = @img 
                               WHERE id = @id";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", disco.Id);
                    cmd.Parameters.AddWithValue("@nome", disco.Nome);
                    cmd.Parameters.AddWithValue("@ano", disco.Ano);
                    cmd.Parameters.AddWithValue("@letra", disco.Letra ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@gen_id", disco.Genero?.Id ?? (object)DBNull.Value);

                    byte[] bytesImagem = default;
                    if (disco.Imagem != null) bytesImagem = Helpers.ImageToByteArray(disco.Imagem);
                    cmd.Parameters.AddWithValue("@img", bytesImagem ?? (object)DBNull.Value);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Apaga um disco pelo ID. Graças ao 'ON DELETE CASCADE' na base de dados, as faixas também vão desaparecer!
        /// </summary>
        public static void ApagarDisco(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "DELETE FROM disco WHERE id = @id";
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Liga um Artista a um Disco. (Guarda os dois IDs na tabela artista_disco).
        /// O "INSERT IGNORE" diz à base de dados para não fazer nada caso a associação já exista, 
        /// evitando erros chatos no programa.
        /// </summary>
        public static void AssociarArtistaADisco(int artistaId, int discoId)
        {
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "INSERT IGNORE INTO artista_disco (artista_id, disco_id) VALUES (@artista_id, @disco_id)";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@artista_id", artistaId);
                    cmd.Parameters.AddWithValue("@disco_id", discoId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Remove APENAS A RELAÇÃO entre o Artista e o Disco. 
        /// A base de dados não vai apagar nem o Artista, nem o Disco propriamente ditos.
        /// </summary>
        public static void DesassociarArtistaDeDisco(int artistaId, int discoId)
        {
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "DELETE FROM artista_disco WHERE artista_id = @artista_id AND disco_id = @disco_id";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@artista_id", artistaId);
                    cmd.Parameters.AddWithValue("@disco_id", discoId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        #endregion

        #region Faixas

        /// <summary>
        /// Obtém uma lista com todas as faixas pertencentes a um determinado Disco.
        /// Na tua aplicação, podes chamar isto depois de 'ObterDiscoPorId' para preencher a lista 'Faixas' do objeto Disco!
        /// </summary>
        public static List<Faixa> ObterFaixasDeUmDisco(int discoId)
        {
            var faixas = new List<Faixa>();

            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "SELECT id, nome, letra, duracao FROM faixa WHERE disco_id = @disco_id";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@disco_id", discoId);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Faixa f = new Faixa();
                            f.Id = Convert.ToInt32(reader["id"]);
                            f.Nome = reader["nome"].ToString();
                            f.Duracao = Convert.ToInt32(reader["duracao"]);

                            if (reader["letra"] != DBNull.Value)
                                f.Letra = reader["letra"].ToString();

                            faixas.Add(f);
                        }
                    }
                }
            }
            return faixas;
        }

        /// <summary>
        /// Adiciona uma nova Faixa a um Disco. 
        /// Precisamos do ID do disco para saber onde a música vai morar!
        /// </summary>
        public static void InserirFaixa(Faixa faixa, int discoId)
        {
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                string sql = @"INSERT INTO faixa (nome, letra, duracao, disco_id) 
                               VALUES (@nome, @letra, @duracao, @disco_id)";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@nome", faixa.Nome);
                    cmd.Parameters.AddWithValue("@letra", faixa.Letra ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@duracao", faixa.Duracao);
                    cmd.Parameters.AddWithValue("@disco_id", discoId);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Apaga manualmente uma única faixa através do seu próprio ID.
        /// </summary>
        public static void ApagarFaixa(int idDaFaixa)
        {
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "DELETE FROM faixa WHERE id = @id";
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", idDaFaixa);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        #endregion
    }
}
