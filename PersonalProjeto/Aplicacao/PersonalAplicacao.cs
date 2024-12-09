using System;
using System.Text;
using PersonalProjeto.Dal;
using PersonalProjeto.Models;

namespace PersonalProjeto.Aplicacao
{
    public class PersonalAplicacao
    {
        public List<Personal> ListarPersonal()
        {
            try
            {
                using (var conn = new ConexaoMySql())
                {
                    var sql = new StringBuilder();
                    sql.Append(" select * from ");
                    sql.Append(" personalprojeto.personal");

                    var reader = conn.RetornaComando(sql.ToString());
                    
                    List<Personal> lista = new List<Personal>();
                    while (reader.Read())
                    {
                        Personal personal = new Personal();
                        personal.Id = reader.GetInt32("Id");
                        personal.Name = reader.GetString("Nome");
                        personal.Cref = reader.GetString("Cref");
                        personal.Experiencia = reader.GetString("Experiencia");

                        lista.Add(personal);
                        
                    }
                    return lista;

                }
            }
            catch 
            {
                throw;
            }
        }
    }
}
