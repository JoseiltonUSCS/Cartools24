using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Cartools.Models
{
    public class Plan
    {
        public int PlanId { get; set; }
        [Required(ErrorMessage = "Informe o nome do plan")]
        [Display(Name = "PlanNome")]
        public string PlanNome { get; set; }
        public string PlanTipo { get; set; }

        [Required(ErrorMessage = "Informe o preço do plan")]
        [Display(Name = "Preço")]
        [Column(TypeName = "decimal(18,2)")]
        [Range(1, 9999.99, ErrorMessage = "O preço deve estar entre 1 e 9.999,99")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "Informe uma descrição curta")]
        [Display(Name = "Descrição curta: ")]
        [MinLength(10, ErrorMessage = "Descrição curta deve ter no mínimo {1} caractere")]
        [MaxLength(200, ErrorMessage = "Descrição curta pode exceder {1} caractere")]
        public string DescricaoCurta { get; set; }
        public string DescricaoDetalhada { get; set; }
        public string ImageUrl { get; set; }
        public string ImageThumbnailUrl { get; set; }
        public bool IsPlanPreferido { get; set; }
        public string PlanStatus { get; set; }
        public int OficinaId { get; set; }
        public virtual Oficina Oficina { get; set; }
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }



    }
}

