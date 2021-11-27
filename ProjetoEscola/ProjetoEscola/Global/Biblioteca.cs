namespace ProjetoEscola.Global
{
    public static class Biblioteca
    {
        //Constantes usadas nos métodos e acesso à API
        public const string API_BASE_URL = "https://localhost:44367/api/";
        public const string MEDIATYPE = "application/json";

        //Constantes usadas nas mensagens de validações de campos 
        public const string CAMPO_OBRIGATORIO = "Campo obrigatório";
        public const string CAMPO_INVALIDO = "Valor inválido para o campo";
        public const string EMAIL_EM_USO = "Endereço de email já em uso";
        public const string EMAIL_INVALIDO = "Informe um endereço de email válido";
        public const string USUARIO_INVALIDO = "Usuário ou senha inválidos";
        public const string SENHA_INCORRETA = "Falha ao comparar senhas";
    }
}
