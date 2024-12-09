using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace PersonalProjeto.Dal
{
    public class ConexaoMySql : IDisposable
    {
        private readonly MySqlConnection conn;

        public ConexaoMySql(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("MySql");
            conn = new MySqlConnection(connectionString);

            if (conn.State == ConnectionState.Closed)
                conn.Open();
        }

        // Executa um comando
        public void ExecutaComando(string strQuery)
        {
            var cmdComando = new MySqlCommand(strQuery, conn);
            cmdComando.ExecuteNonQuery();
        }

        // Retorna um Reader
        public MySqlDataReader RetornaComando(string strQuery)
        {
            var cmdComando = new MySqlCommand(strQuery, conn);
            return cmdComando.ExecuteReader();
        }

        // Fecha a conexão
        public void Dispose()
        {
            GC.SuppressFinalize(this);
            if (conn.State == ConnectionState.Open)
                conn.Close();
        }

    }
}
