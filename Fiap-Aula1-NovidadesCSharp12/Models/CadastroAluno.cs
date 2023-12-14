namespace NovidadesCSharp12.Models
{
    //Primary Construtor escrito na classe
    public class CadastroAluno(string nome, string idade, string telefone, string situacao = "Em Validacao")
    {
        public CadastroAluno(string nome) : 
            this(nome, string.Empty, string.Empty) { } //Executa o Primary Constructor

        public string Nome => nome;
        public string Idade => idade;
        public string Telefone => telefone;
        public string Situacao => situacao;
    }
}
