using System;
using System.Collections.Generic;

namespace Dominio
{
    public class Empregado : Pessoa
    {
        public List<Profissao> Profissao { get; set; }
        public DateTime DataAdm { get; set; }
        
        public Empregado(long Id, string Nome, string SobreNome, List<Profissao> Profissao) : base(Id, Nome, SobreNome)
        {
            this.Profissao = Profissao;
        }

    }
}
