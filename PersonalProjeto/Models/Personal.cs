namespace PersonalProjeto.Models
{
    public class Personal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public  string Cref { get; set; }
        public string Experiencia { get; set; }

        public List<Aluno> Alunos { get; set; } = new List<Aluno>();

        public Personal () { }

        public Personal(int id, string name, string cref, string experiencia)
        {
            Id = id;
            Name = name;
            Cref = cref;
            Experiencia = experiencia;
        }

        public void AddAluno(Aluno aluno)
        {
            Alunos.Add(aluno);
        }
    }
}
