using discos.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace discos.Data
{
    public static class Database
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["MySqlDatabase"].ConnectionString;

        public static List<Login> ListarLogins()
        {
            var lista = new List<Login>();
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "SELECT id, username, passwrd FROM login";
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Login
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Username = reader["username"].ToString(),
                            Password = reader["passwrd"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public static List<Genero> ListarGeneros()
        {
            var lista = new List<Genero>();
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "SELECT id, nome FROM genero";
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Genero
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Nome = reader["nome"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public static List<Nacionalidade> ListarNacionalidades()
        {
            var lista = new List<Nacionalidade>();
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "SELECT id, nome FROM nacionalidade";
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Nacionalidade
                        {
                            Id = reader["id"].ToString(),
                            Nome = reader["nome"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public static void InserirArtista(Artista artista)
        {
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                string sql = @"INSERT INTO artista (nome, nacionalidade_id, dataNascimento, biografia, imagem) 
                           VALUES (@nome, @nacionalidade_id, @dataNascimento, @biografia, @imagem)";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@nome", artista.Nome);
                    cmd.Parameters.AddWithValue("@nacionalidade_id", artista.Nacionalidade?.Id ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@dataNascimento", artista.DataNascimento ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@biografia", artista.Biografia ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@imagem", artista.Imagem ?? (object)DBNull.Value);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static List<Artista> ListarArtistas()
        {
            var lista = new List<Artista>();
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "SELECT id, nome, nacionalidade_id, dataNascimento, biografia, imagem FROM artista";
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Artista
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Nome = reader["nome"].ToString(),
                            DataNascimento = reader["dataNascimento"] != DBNull.Value ? Convert.ToDateTime(reader["dataNascimento"]) : (DateTime?)null,
                            Biografia = reader["biografia"] != DBNull.Value ? reader["biografia"].ToString() : string.Empty,
                            Imagem = reader["imagem"] != DBNull.Value ? (byte[])reader["imagem"] : null,

                            Nacionalidade = reader["nacionalidade_id"] != DBNull.Value
                                            ? new Nacionalidade { Id = reader["nacionalidade_id"].ToString() }
                                            : null
                        });
                    }
                }
            }
            return lista;
        }

        public static void AtualizarArtista(Artista artista)
        {
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                string sql = @"UPDATE artista SET 
                            nome = @nome, 
                            nacionalidade_id = @nacionalidade_id, 
                            dataNascimento = @dataNascimento, 
                            biografia = @biografia, 
                            imagem = @imagem 
                           WHERE id = @id";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", artista.Id);
                    cmd.Parameters.AddWithValue("@nome", artista.Nome);
                    cmd.Parameters.AddWithValue("@nacionalidade_id", artista.Nacionalidade?.Id ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@dataNascimento", artista.DataNascimento ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@biografia", artista.Biografia ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@imagem", artista.Imagem ?? (object)DBNull.Value);

                    cmd.ExecuteNonQuery();
                }
            }
        }

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

        /// <summary>
        /// Insere o Disco, suas Faixas e vincula os Artistas tudo num único processo seguro.
        /// </summary>
        public static void InserirDiscoComFaixasEArtistas(Disco disco, List<Artista> artistasEnvolvidos)
        {
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                using (MySqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. INSERIR DISCO
                        string sqlDisco = @"INSERT INTO disco (nome, ano, letra, genero_id, imagem) 
                                        VALUES (@nome, @ano, @letra, @genero_id, @imagem);
                                        SELECT LAST_INSERT_ID();";

                        using (MySqlCommand cmd = new MySqlCommand(sqlDisco, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@nome", disco.Nome);
                            cmd.Parameters.AddWithValue("@ano", disco.Ano);
                            cmd.Parameters.AddWithValue("@letra", disco.Letra);
                            cmd.Parameters.AddWithValue("@genero_id", disco.Genero.Id);
                            cmd.Parameters.AddWithValue("@imagem", disco.Imagem ?? (object)DBNull.Value);

                            disco.Id = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        // 2. INSERIR FAIXAS (One-to-Many)
                        string sqlFaixa = "INSERT INTO faixa (nome, letra, duracao, disco_id) VALUES (@nome, @letra, @duracao, @disco_id)";
                        foreach (var faixa in disco.Faixas)
                        {
                            using (MySqlCommand cmd = new MySqlCommand(sqlFaixa, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@nome", faixa.Nome);
                                cmd.Parameters.AddWithValue("@letra", faixa.Letra);
                                cmd.Parameters.AddWithValue("@duracao", faixa.Duracao);
                                cmd.Parameters.AddWithValue("@disco_id", disco.Id);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        // 3. VINCULAR ARTISTAS AO DISCO (Many-to-Many)
                        string sqlArtistaDisco = "INSERT INTO artista_disco (artista_id, disco_id) VALUES (@artista_id, @disco_id)";
                        foreach (var artista in artistasEnvolvidos)
                        {
                            using (MySqlCommand cmd = new MySqlCommand(sqlArtistaDisco, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@artista_id", artista.Id);
                                cmd.Parameters.AddWithValue("@disco_id", disco.Id);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Erro ao salvar o disco. Tudo foi revertido.", ex);
                    }
                }
            }
        }

        public static List<Disco> ListarDiscos()
        {
            var lista = new List<Disco>();
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "SELECT id, nome, ano, letra, genero_id, imagem FROM disco";
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Disco
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Nome = reader["nome"].ToString(),
                            Ano = Convert.ToInt32(reader["ano"]),
                            Letra = reader["letra"] != DBNull.Value ? reader["letra"].ToString() : string.Empty,
                            Imagem = reader["imagem"] != DBNull.Value ? (byte[])reader["imagem"] : null,
                            Genero = new Genero { Id = Convert.ToInt32(reader["genero_id"]) }
                        });
                    }
                }
            }
            return lista;
        }

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
    }
}
