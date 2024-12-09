using System;
using System.Text;
using MySql.Data.MySqlClient;
using PersonalProjeto.Dal;
using PersonalProjeto.Models;
using PersonalProjeto.Models.Enums;

namespace PersonalProjeto.Aplicacao

{
    public class AlunoAplicacao
    {
        private readonly ConexaoMySql _conexaoMySql;

        public AlunoAplicacao(ConexaoMySql conexaoMySql)
        {
            _conexaoMySql = conexaoMySql;
        }


        public List<Aluno> ListarAluno()
        {
            try
            {
                var sql = new StringBuilder();
                sql.Append(" SELECT t1.*,t2.Nome as 'NomePersonal' FROM aluno t1 ");
                sql.Append(" left join personal t2 on t2.Id = t1.IdPersonal");

                var reader = _conexaoMySql.RetornaComando(sql.ToString());

                List<Aluno> lista = new List<Aluno>();
                while (reader.Read())
                {
                    Personal personal = new Personal
                    {
                        Nome = reader.GetString("NomePersonal")
                    };

                    Aluno aluno = new Aluno
                    {
                        Id = reader.GetInt32("Id"),
                        Nome = reader.GetString("Nome"),
                        DataNascimento = reader.GetDateTime("DataNascimento"),
                        Objetivo = (Objetivos)reader.GetInt32("Objetivo"),
                        Personal = personal
                        

                    };

                    lista.Add(aluno);
                }
                return lista;
            }
            catch
            {
                throw;
            }
        }
    }
}
