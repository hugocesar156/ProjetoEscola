namespace ProjetoEscola.Models
{
    public class Notificacao
    {
        public Tipo Tipo { get; set; }
        public string Mensagem { get; set; }


        public const string CADASTRO_SUCESSO = "Cadastro de registro realizado com sucesso.";
        public const string CADASTRO_FALHA = "Ocorreu algum erro durante o cadastro de registro, tente novamente.";
    }

    public enum Tipo
    {
        Sucesso,
        Falha,
        Aviso,
        Informacao
    }
}
