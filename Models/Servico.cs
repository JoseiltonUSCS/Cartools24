﻿using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.X509Certificates;

namespace Cartools.Models
{
    [Table("Servicos")]
    public class Servico
    {
        [Key]
        public int ServicoId { get; set; }

        [Required(ErrorMessage="O nome do serviço deve ser informado")]
        [Display(Name = "Nome do serviço  ")]
        [StringLength(80, MinimumLength = 4, ErrorMessage = "O {0} deve ter no máximo {1} e no  mínimo  {2}")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe a descrição curta")]
        [Display(Name = "Descrição:  ")]
        [MinLength(4, ErrorMessage = "Descrição curta deve ter no mínimo {1} caractere")]
        [MaxLength(200, ErrorMessage = "Descrição curta não pode exceder {1} caractere")]
        public string DescricaoCurta { get; set; }

       
        [Required(ErrorMessage = "A descrição detalhada do servico deve ser informado")]
        [Display(Name = "Descrição detalhada do serviço")]
        [MinLength(7, ErrorMessage = "Descrição detalhada deve ter no mínimo {1} caractere")]
        [MaxLength(600, ErrorMessage = "Descrição detalhada não pode exceder {1} caractere")] 
        public string DescricaoDetalhada { get; set; }       


        [Required(ErrorMessage = "Informe o preço do serviço")]
        [Display(Name = "Preço")]
        [Column(TypeName = "decimal(18,2)")]
        [Range(1,999.99, ErrorMessage ="O preço deve estar entre 1 e 999,99")]
        public decimal Preco { get; set; }


        [Display(Name = " Imagem")]
        [StringLength(200, ErrorMessage = "O {0} deve ter no máximo {1} caractere")]
        public string ImagemUrl { get; set; }

        [Display(Name = " Caminho Imagem Normal")]
        [StringLength(200, ErrorMessage = "O {0} deve ter no máximo {1} caractere")]
        public string ImagemThumbnailUrl { get; set; }
        [Display(Name = " Preferido/Anúncio")]
        public bool IsServicoPreferido { get; set; }
        public string EmEstoque { get; set; }
        public List<Agendamento> Agendamentos { get; set; }
        public virtual List<PedidoDetalhe> PedidoItens { get; set; }
        public int CategoriaId { get; set;}
        public virtual Categoria Categoria { get; set; }

        [Display(Name = " Local")]
        public int LocalId { get; set; }
        public virtual Local Local { get; set; }

        [Display(Name = " Oficina")]
        public int OficinaId { get; set; }
        public virtual Oficina Oficina { get; set; }
    }
}
