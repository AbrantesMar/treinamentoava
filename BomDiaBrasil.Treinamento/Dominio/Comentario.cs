using System.ComponentModel.DataAnnotations;

namespace Dominio
{
    public class Comentario
    {
        [Display(Name = "Codigo")]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Descricao { get; set; }
    }
}
