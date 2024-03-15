using System.ComponentModel.DataAnnotations;

namespace Cartools.Models
{
    public class Tipo
    {
        public int TipoId { get; set; }
        [Required(ErrorMessage = "Informe o Tipo")]
        [Display(Name = "Tipo de Plano")]
        public string TipoNome { get; set; }
        public  string TipoDescricao { get; set; }
        public List<Plano> Planos { get; set; }
    }
}
