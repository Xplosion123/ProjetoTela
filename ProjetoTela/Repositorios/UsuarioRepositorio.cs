using MySql.Data.MySqlClient;
using ProjetoTela.Models;
using ProjetoTela.Repositorio;

namespace ProjetoTela.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly string _connectionString;

        public UsuarioRepositorio(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("Conexao")!;
        }

        public Login? Validar(string email, string senha)
        {
            using var conn = new MySqlConnection(_connectionString);
            conn.Open();

            var sql = "SELECT * FROM tb_Usuario WHERE Email = @e";
            var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@e", email);

            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                var hashSalvo = reader["Senha"].ToString()!;

                if (BCrypt.Net.BCrypt.Verify(senha, hashSalvo))
                {
                    return new Login
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Nome = reader["Nome"].ToString()!,
                        Email = reader["Email"].ToString()!,
                        Nivel = reader["Nivel"].ToString()!
                    };
                }
            }

            return null;
        }

        public void Adicionar(Login usuario)
        {
            using var conn = new MySqlConnection(_connectionString);
            conn.Open();

            var sql = @"INSERT INTO tb_Usuario
                        (Nome, Email, Senha, Nivel)
                        VALUES
                        (@nome, @email, @senha, @nivel)";

            var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@nome", usuario.Nome);
            cmd.Parameters.AddWithValue("@email", usuario.Email);
            cmd.Parameters.AddWithValue("@senha", usuario.Senha);
            cmd.Parameters.AddWithValue("@nivel", usuario.Nivel);

            cmd.ExecuteNonQuery();
        }
    }
}