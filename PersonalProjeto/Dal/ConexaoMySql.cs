using MySql.Data.MySqlClient;
using System.Data;



namespace PersonalProjeto.Dal
{
    public class ConexaoMySql : IDisposable
    {
        private readonly MySqlConnection conn;

        private readonly string _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Mysql"].ToString();

        public ConexaoMySql()
        {
            conn = new MySqlConnection(_connectionString);

            if (conn.State == ConnectionState.Closed) conn.Open();
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
            if (conn.State == ConnectionState.Open) conn.Close();
        }
    }
}
