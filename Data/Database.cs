using discos.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace discos.Data
{
    public class Database
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["MySqlDatabase"].ConnectionString;

        public static List<Login> ListarLogins()
        {
            var logins = new List<Login>();

            var query = "SELECT id, username, passwd FROM login";

            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var login = new Login(
                            reader.GetInt32(reader.GetOrdinal("Id")),
                            reader.GetString(reader.GetOrdinal("username")),
                            reader.GetString(reader.GetOrdinal("passwd"))
                        );

                        logins.Add(login);
                    }
                }
            }

            return logins;
        }

        public static List<Genero> ListarGeneros()
        {
            var generos = new List<Genero>();

            var query = "SELECT id, nome FROM generos";

            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var genero = new Genero(
                            reader.GetInt32(reader.GetOrdinal("id")),
                            reader.GetString(reader.GetOrdinal("nome"))
                        );

                        generos.Add(genero);
                    }
                }
            }

            return generos;
        }


        // -------------------------------------
        // ARTISTAS
        // -------------------------------------

        public static List<Artista> ListarArtistas()
        {
            var artistas = new List<Artista>();

            var query = "SELECT id, nome, nacionalidade, data_de_nascimento FROM artista";

            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Artista artista = new Artista(
                            reader.GetInt32("id"),
                            reader.GetString("nome"),
                            reader.GetString("nacionalidade"),
                            reader.GetDateTime("data_de_nascimento")
                        );

                        artistas.Add(artista);
                    }
                }
            }

            return artistas;
        }

        public static void InserirArtista(string nome, string nascionalidade, DateTime dataNascimento)
        {
            var query = "INSERT INTO artista (nome, nacionalidade, data_de_nascimento) VALUES (@nome,@nascionalidade,@dataNascimento)";

            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nome", nome);
                    cmd.Parameters.AddWithValue("@nascionalidade", nascionalidade);
                    cmd.Parameters.AddWithValue("@dataNascimento", dataNascimento.Date);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void ApagarArtista(int id)
        {
            var query = "DELETE FROM artista WHERE Id=@id";

            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }


        // -------------------------------------
        // DISCOS
        // -------------------------------------

        public static List<Disco> ListarDiscos(int id_artista)
        {
            var discos = new List<Disco>();

            var query = "SELECT id, nome, ano, id_genero FROM disco WHERE id=@id_artista";

            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id_artista", id_artista);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Disco disco = new Disco(
                                reader.GetInt32("id"),
                                reader.GetString("nome"),
                                reader.GetInt32("ano"),
                                reader.GetInt32("id_genero")
                            );

                            discos.Add(disco);
                        }
                    }
                }
            }

            return discos;
        }

        public static void InserirDisco(int nome, string ano, int id_genero)
        {
            var query = "INSERT INTO disco (nome, ano, id_genero) VALUES (@nome,@ano,@id_genero)";

            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nome", nome);
                    cmd.Parameters.AddWithValue("@ano", ano);
                    cmd.Parameters.AddWithValue("@id_genero", id_genero);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void ApagarDisco(int id)
        {
            var query = "DELETE FROM disco WHERE id=@id";

            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }


        // -------------------------------------
        // FAIXAS
        // -------------------------------------

        public static List<Faixa> ListarFaixas(int id_disco)
        {
            var faixas = new List<Faixa>();

            var query = "SELECT id, id_disco, descricao, duracao FROM disco WHERE id=@id_disco";

            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id_disco", id_disco);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Faixa faixa = new Faixa(
                                reader.GetInt32("id"),
                                reader.GetString("descricao"),
                                reader.GetInt32("duracao")
                            );

                            faixas.Add(faixa);
                        }
                    }
                }
                
            }

            return faixas;
        }

        public static void InserirFaixa(int id_disco, string descricao, int duracao)
        {
            var query = "INSERT INTO disco (id_disco, descricao, duracao) VALUES (@id_disco,@descricao,@duracao)";

            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id_disco", id_disco);
                    cmd.Parameters.AddWithValue("@descricao", descricao);
                    cmd.Parameters.AddWithValue("@duracao", duracao);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void ApagarFaixa(int id)
        {
            var query = "DELETE FROM faixa WHERE id=@id";

            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
