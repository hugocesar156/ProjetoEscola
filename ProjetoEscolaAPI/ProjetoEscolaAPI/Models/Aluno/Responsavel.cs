using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoEscolaAPI.Models.Aluno
{
    [Table("responsavel")]
    public class Responsavel
    {
        [Column("idResponsavel"), Key]
        public uint Id { get; set; }

        [Column("nome")]
        public string Nome { get; set; }

        [Column("cpf")]
        public string Cpf { get; set; }

        [Column("telefone1")]
        public string Telefone1 { get; set; }

        [Column("telefone2")]
        public string Telefone2 { get; set; }

        [Column("dataCriacao")]
        public DateTime DataCriacao { get; set; }

        public List<Aluno> Aluno { get; set; }
    }
}
