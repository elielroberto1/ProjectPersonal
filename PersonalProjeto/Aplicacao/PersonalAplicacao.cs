using System;
using System.Text;
using MySql.Data.MySqlClient;
using PersonalProjeto.Dal;
using PersonalProjeto.Models;

namespace PersonalProjeto.Aplicacao
{
    public class PersonalAplicacao
    {
        private readonly ConexaoMySql _conexaoMySql;

        public PersonalAplicacao(ConexaoMySql conexaoMySql)
        {
            _conexaoMySql = conexaoMySql;
        }

        public List<Personal> ListarPersonal()
        {
            try
            {
                var sql = new StringBuilder();
                sql.Append(" select * from ");
                sql.Append(" personalprojeto.personal");

                var reader = _conexaoMySql.RetornaComando(sql.ToString());

                List<Personal> lista = new List<Personal>();
                while (reader.Read())
                {
                    Personal personal = new Personal
                    {
                        Id = reader.GetInt32("Id"),
                        Nome = reader.GetString("Nome"),
                        Cref = reader.GetString("Cref"),
                        Experiencia = reader.GetString("Experiencia")
                    };

                    lista.Add(personal);
                }
                return lista;
            }
            catch
            {
                throw;
            }


        }
        public void CreatePersonal(Personal personal)
        {
            try
            {
                var sql = new StringBuilder();
                sql.AppendFormat(" INSERT INTO `personalprojeto`.`personal` (`Nome`, `Cref`, `Experiencia`) VALUES ('{0}', '{1}', '{2}'); ", personal.Nome, personal.Cref, personal.Experiencia);


                _conexaoMySql.ExecutaComando(sql.ToString());
            }
            catch
            {
                throw;
            }
        }
        public void RemovePersonal(int id)
        {
            try
            {
                var sql = new StringBuilder();
                sql.AppendFormat("DELETE FROM personalprojeto.personal WHERE Id = {0};", id);

                _conexaoMySql.ExecutaComando(sql.ToString());
               
            }
            catch
            {
                throw;
            }
        }

        public Personal ObterPersonalPorId(int id)
        {
            try
            {
                var sql = new StringBuilder();
                sql.AppendFormat("SELECT * FROM personalprojeto.personal WHERE Id = {0};", id);

                var reader = _conexaoMySql.RetornaComando(sql.ToString());

                if (reader.Read())
                {
                    return new Personal
                    {
                        Id = reader.GetInt32("Id"),
                        Nome = reader.GetString("Nome"),
                        Cref = reader.GetString("Cref"),
                        Experiencia = reader.GetString("Experiencia")
                    };
                }

                return null; // Retorna null caso não encontre o "personal"
            }
            catch
            {
                throw;
            }
        }

        public void AtualizarPersonal(Personal personal)
        {
            try
            {
                var sql = new StringBuilder();
                sql.AppendFormat("UPDATE personalprojeto.personal SET Nome = '{0}', Cref = '{1}', Experiencia = '{2}' WHERE Id = {3};",
                    personal.Nome, personal.Cref, personal.Experiencia, personal.Id);

                _conexaoMySql.ExecutaComando(sql.ToString());
            }
            catch
            {
                throw;
            }
        }

    }
}