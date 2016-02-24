using System;
using System.Collections.Generic;

namespace Dominio
{
    public class Reportagem
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public eEstado Estado { get; set; }
        public List<Empregado> Equipe { get; set; }
        public string Resumo { get; set; }
        public DateTime DataDaPublicacao { get; set; }
        public string Titulo { get; set; }
        public string Tags { get; set; }
        public string urlVideo { get; set; }
        public List<Comentario> Comentarios { get; set; }
        public List<Participante> Participantes { get; set; }
    }
}
