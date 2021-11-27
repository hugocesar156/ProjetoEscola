using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoEscolaAPI.Models
{
    [Table("professor")]
    public class Professor
    {
        [Column("idProfessor"), Key]
        public uint Id { get; set; }

        [Column("nome")]
        public string Nome { get; set; }

        [Column("cpf")]
        public string Cpf { get; set; }

        [Column("dataCriacao")]
        public DateTime DataCriacao { get; set; }

        [Column("idUsuario")]
        public uint IdUsuario { get; set; }

        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }
    }
}
