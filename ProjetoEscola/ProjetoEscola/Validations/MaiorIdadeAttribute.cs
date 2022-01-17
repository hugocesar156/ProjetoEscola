using System;
using System.ComponentModel.DataAnnotations;

namespace ProjetoEscola.Validations
{
    public class MaiorIdadeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            var propriedade1 = context.ObjectType.GetProperty("IdResponsavel");
            var responsavel = (uint?)propriedade1.GetValue(context.ObjectInstance);

            var propriedade2 = context.ObjectType.GetProperty("Nascimento");
            var nascimento = (DateTime?)propriedade2.GetValue(context.ObjectInstance);

            var dataAtual = DateTime.Now;

            if (nascimento > new DateTime(dataAtual.Year - 18, dataAtual.Month, dataAtual.Day) && responsavel == null)
                return new ValidationResult("Obrigatório informar o responsável para menores de idade");

            return ValidationResult.Success;
        }
    }
}
