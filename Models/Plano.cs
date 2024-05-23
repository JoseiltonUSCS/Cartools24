using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cartools.Models
{
    public class Plano
    {

        public int PlanoId { get; set; }
        [Required(ErrorMessage = "Informe o nome do Plano")]
        [Display(Name = "Nome do Plano")]
        public string PlanoNome { get; set; }

        [Required(ErrorMessage = "Informe a descrição do Plano")]
        [Display(Name = "Descrição do Plano")]
        [MinLength(10, ErrorMessage = "A descrição deve ter ao menos {1} caracteres")]
        [MaxLength(400, ErrorMessage = "A descrição deve ter no máximo {1} caracteres")]
        public string PlanoDescricao { get; set; }
        [Display(Name = "Preço")]
        [Column(TypeName = "decimal(18,2)")]
        [Range(1, 9999.99, ErrorMessage = "O preço deve estar entre 1 e 999,99")]
        public decimal PlanoPreco { get; set; }
        public string PlanoImagem { get; set; }
        public bool IsPlanoPreferido { get; set; }
        public int TipoId { get; set; }
        public virtual Tipo Tipo { get; set; }
        public List<Oficina> Oficinas { get; set; }
        public virtual List<PedidoDetalhe> PedidoItens { get; set; }
        public virtual List<CarrinhoCompraItem> CarrinhoCompraItems { get; set; }
    }
}

