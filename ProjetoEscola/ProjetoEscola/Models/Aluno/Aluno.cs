using ProjetoEscola.Global;
using ProjetoEscola.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjetoEscola.Models.Aluno
{
    public class Aluno
    {
        private string _nome;
        private string _telefone1;
        private string _telefone2;
        private string _deficiencia;
        private string _alergia;

        public uint IdAluno { get; set; }

        [Required(ErrorMessage = Biblioteca.CAMPO_OBRIGATORIO)]
        public string Nome
        {
            get => _nome;
            set => _nome = value?.Trim().ToUpper();
        }

        [Required(ErrorMessage = Biblioteca.CAMPO_OBRIGATORIO), Cpf]
        public string Cpf { get; set; }

        [Required(ErrorMessage = Biblioteca.CAMPO_OBRIGATORIO)]
        public DateTime? Nascimento { get; set; }

        [Required(ErrorMessage = Biblioteca.CAMPO_OBRIGATORIO)]
        public char? Sexo { get; set; }

        [EmailAddress(ErrorMessage = Biblioteca.CAMPO_INVALIDO)]
        public string Email { get; set; }

        [Required(ErrorMessage = Biblioteca.CAMPO_OBRIGATORIO)]
        public string Telefone1
        {
            get => _telefone1;
            set => _telefone1 = value?.Replace(" ", "");
        }

        public string Telefone2
        {
            get => _telefone2;
            set => _telefone2 = value?.Replace(" ", "");
        }

        public string Deficiencia
        {
            get => _deficiencia;
            set => _deficiencia = value?.Trim().ToUpper();
        }

        public string Alergia
        {
            get => _alergia;
            set => _alergia = value?.Trim().ToUpper();
        }

        public Endereco Endereco { get; set; }
        public List<Turma> Turma { get; set; }

        [MaiorIdade]
        public uint? IdResponsavel { get; set; }
        public Responsavel Responsavel { get; set; }
    }
}
