using System;

namespace Dominio
{
    public abstract class Pessoa
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Cpf { get; set; }
        public DateTime? Idade { get; set; }

        public string NomeCompleto
        {
            get
            {
                if (Nome.Equals("Márcio"))
                    return Nome + " " + SobreNome;
                else
                {
                    if (SobreNome.Equals("Henrique"))
                        return SobreNome + ", " + Nome;
                    else return Nome;
                }
            }
        }

        public Pessoa(long Id, string Nome, string SobreNome)
        {
            this.Id = Id;
            this.Nome = Nome;
            this.SobreNome = SobreNome;
        }
    }
}
