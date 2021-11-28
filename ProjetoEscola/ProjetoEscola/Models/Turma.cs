using ProjetoEscola.Global;
using ProjetoEscola.Validations;
using System;
using System.ComponentModel.DataAnnotations;

namespace ProjetoEscola.Models
{
    public class Turma
    {
        private string _nome;

        public uint IdTurma { get; set; }

        [Required(ErrorMessage = Biblioteca.CAMPO_OBRIGATORIO),
        MaxLength(30, ErrorMessage = Biblioteca.CAMPO_INVALIDO)]
        public string Nome 
        { 
            get => _nome; 
            set => _nome = value?.Trim().ToUpper(); 
        }

        [Required(ErrorMessage = Biblioteca.CAMPO_OBRIGATORIO)]
        public byte? Ensino { get; set; }

        [Required(ErrorMessage = Biblioteca.CAMPO_OBRIGATORIO)]
        public byte? AnoEnsino { get; set; }

        [Required(ErrorMessage = Biblioteca.CAMPO_OBRIGATORIO)]
        public byte? Turno { get; set; }

        [Required(ErrorMessage = Biblioteca.CAMPO_OBRIGATORIO),
        Range(1, 40, ErrorMessage = Biblioteca.CAMPO_INVALIDO)]
        public byte? Capacidade { get; set; }

        [Required(ErrorMessage = Biblioteca.CAMPO_OBRIGATORIO), AnoLetivo]
        public uint? AnoLetivo { get; set; }

        [Required(ErrorMessage = Biblioteca.CAMPO_OBRIGATORIO)]
        public DateTime? Inicio { get; set; }

        [Required(ErrorMessage = Biblioteca.CAMPO_OBRIGATORIO)]
        public DateTime? Termino { get; set; }
    }

    public enum Ensino
    {
        Fundamental,
        Medio
    }
}
