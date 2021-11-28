using System.ComponentModel.DataAnnotations;

namespace ProjetoEscola.Validations
{
    public class AnoLetivoAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            var propriedade = context.ObjectType.GetProperty("AnoLetivo");
            var valor = (uint?)propriedade.GetValue(context.ObjectInstance) ?? (uint?)0;

            if (valor >= (uint)System.DateTime.Now.Year)
                return ValidationResult.Success;

            return new ValidationResult("Ano letivo inválido");
        }
    }
}
