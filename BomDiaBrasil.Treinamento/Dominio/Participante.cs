 namespace Dominio
{
    public class Participante : Pessoa
    {
        public Profissao Profissao { get; set; }

        public Participante(long Id, string Nome, string SobreNome, Profissao Profissao) : base(Id, Nome, SobreNome)
        {
            this.Profissao = Profissao;
        }

    }
}