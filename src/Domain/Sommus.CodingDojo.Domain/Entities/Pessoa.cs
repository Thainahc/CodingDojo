namespace Sommus.CodingDojo.Domain.Entities
{
    public class Pessoa
    {
        private int _pessoaId;
        private string _nome;
        private string _cpf;

        public int PessoaId
        {
            get { return _pessoaId; }
            set { _pessoaId = value; }
        }
        public string Nome
        {
            get { return _nome ?? string.Empty; }
            set { _nome = value; }
        }
        public string CPF
        {
            get { return _cpf ?? string.Empty; }
            set { _cpf = value; }
        }
    }
}