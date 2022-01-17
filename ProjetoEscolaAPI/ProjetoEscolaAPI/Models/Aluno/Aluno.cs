using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoEscolaAPI.Models.Aluno
{
    [Table("aluno")]
    public class Aluno
    {
        [Column("idAluno"), Key]
        public uint Id { get; set; }

        [Column("nome")]
        public string Nome { get; set; }

        [Column("cpf")]
        public string Cpf { get; set; }

        [Column("nascimento")]
        public DateTime Nascimento { get; set; }

        [Column("sexo")]
        public char Sexo { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("telefone1")]
        public string Telefone1 { get; set; }

        [Column("telefone2")]
        public string Telefone2 { get; set; }

        [Column("deficiencia")]
        public string Deficiencia { get; set; }

        [Column("alergia")]
        public string Alergia { get; set; }

        [Column("dataCriacao")]
        public DateTime DataCriacao { get; set; }

        [Column("idResponsavel")]
        public uint IdResponsavel { get; set; }

        [Column("IdResponsavel")]
        public Responsavel Responsavel { get; set; }

        public Endereco Endereco { get; set; }

        public List<Turma> Turma { get; set; }
    }
}
