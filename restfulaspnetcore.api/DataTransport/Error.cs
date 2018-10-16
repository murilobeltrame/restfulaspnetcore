namespace restfulaspnetcore.api.DataTransport
{
    public struct Erro
    {
        public int Codigo { get; private set; }
        public string Mensagem { get; private set; }

        public Erro(int codigo, string mensagem)
        {
            Codigo = codigo;
            Mensagem = mensagem;
        }
    }
}