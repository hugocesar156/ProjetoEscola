using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoEscolaAPI.Models.Aluno
{
    [Table("aluno_endereco")]
    public class Endereco
    {
        [Column("idEndereco"), Key]
        public uint Id { get; set; }

        [Column("cep")]
        public string Cep { get; set; }

        [Column("logradouro")]
        public string Logradouro { get; set; }

        [Column("bairro")]
        public string Bairro { get; set; }

        [Column("numero")]
        public string Numero { get; set; }

        [Column("cidade")]
        public string Cidade { get; set; }

        [Column("uf")]
        public string Uf { get; set; }

        [Column("complemento")]
        public string Complemento { get; set; }
    }
}
