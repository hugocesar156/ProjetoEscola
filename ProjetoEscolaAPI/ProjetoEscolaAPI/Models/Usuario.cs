using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoEscolaAPI.Models
{
    [Table("usuario")]
    public class Usuario
    {
        [Column("idUsuario"), Key]
        public uint Id { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("senha"), JsonIgnore]
        public string Senha { get; set; }

        [Column("hash"), JsonIgnore]
        public string Hash { get; set; }

        [Column("dataCriacao")]
        public DateTime DataCriacao { get; set; }

        public static (string, string) GerarCriptografia(string senha)
        {
            var salt = BCrypt.Net.BCrypt.GenerateSalt(12);
            return (BCrypt.Net.BCrypt.HashPassword(senha, salt), salt);
        }

        public static bool ValidarCriptografia(string senha, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(senha, hash);
        }
    }
}
