using System;

namespace Dominio
{
    /// <summary>
    /// Olha essa class ser[a uma classe abstrata para pessoas
    /// </summary>
    public abstract class Pessoa
    {
        //como seria no Java
        /*
        */
        /// <summary>
        /// 
        /// </summary>
        //private long id;

        //public long getId()
        //{
        //    return id;
        //}

        //public void setId(long id)
        //{
        //    this.id = id;
        //}

        public long Id { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Cpf { get; set; }
        public DateTime? Idade { get; set; }

        public string NomeCompleto
        {
            get
            {
                if (Nome == "Márcio")
                    return Nome + " " + SobreNome;
                else
                {
                    if (SobreNome.Equals("Henrique"))
                        return SobreNome + ", " + Nome;
                    else return Nome;
                }
            }

            set
            {
                Nome = value;
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
