using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Cartools.Models
{
    public class Plano
    {
        public int PlanoId { get; set; }
        [Required(ErrorMessage = "Informe o tipo do plano")]
        [Display(Name = "Plano")]
        public string PlanoTipo { get; set; }

        [Required(ErrorMessage = "Informe o preço do plano")]
        [Display(Name = "Preço")]
        [Column(TypeName = "decimal(18,2)")]
        [Range(1, 9999.99, ErrorMessage = "O preço deve estar entre 1 e 9.999,99")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "Informe uma descrição curta")]
        [Display(Name = "Descrição curta: ")]
        [MinLength(10, ErrorMessage = "Descrição curta deve ter no mínimo {1} caractere")]
        [MaxLength(200, ErrorMessage = "Descrição curta pode exceder {1} caractere")]
        public string DescricaoCurta { get; set; }
        public int OficinaId { get; set; }
        public virtual Oficina Oficina { get; set; }

    }
}
