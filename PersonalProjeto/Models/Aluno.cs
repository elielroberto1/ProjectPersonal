﻿using PersonalProjeto.Models.Enums;

namespace PersonalProjeto.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public Objetivos Objetivo { get; set; }
        public Personal Personal { get; set; }


        public Aluno() { }

        public Aluno(int id, string nome, DateTime dataNascimento, Objetivos objetivos, Personal personal)
        {
            Id = id;
            Nome = nome;
            DataNascimento = dataNascimento;
            Objetivo = objetivos;
            Personal = personal;
        }

    }
}
