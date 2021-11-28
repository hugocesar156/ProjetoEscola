using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoEscolaAPI.Models
{
    [Table("turma")]
    public class Turma
    {
        [Column("idTurma"), Key]
        public uint IdTurma { get; set; }

        [Column("nome")]
        public string Nome { get; set; }

        [Column("ensino")]
        public byte Ensino { get; set; }

        [Column("anoEnsino")]
        public byte AnoEnsino { get; set; }

        [Column("turno")]
        public byte Turno { get; set; }

        [Column("capacidade")]
        public byte Capacidade { get; set; }

        [Column("anoLetivo")]
        public uint AnoLetivo { get; set; }

        [Column("inicio")]
        public DateTime Inicio { get; set; }

        [Column("termino")]
        public DateTime Termino { get; set; }

        [Column("dataCriacao")]
        public DateTime DataCriacao { get; set; }
    }
}
