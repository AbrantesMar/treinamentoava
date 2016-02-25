using System.ComponentModel.DataAnnotations;

namespace Dominio
{
    public class Comentario
    {
        #region Properts
        [Display(Name = "Codigo")]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Descricao { get; set; }
        #endregion

        #region Metodos
        public void Teste()
        {

        }
        #endregion
    }
}
