
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Cartools.Models
{
    public class Local
    {
        [Key]

        public int LocalId { get; set; }
        [Required(ErrorMessage = "Por favor, informe a cidade!!")]
        [Display(Name = "Cidade")]
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public List<Oficina> Oficina { get; set; }
        public List<Servico> Servico { get; set; }
    }
}


