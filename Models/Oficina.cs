using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Cartools.Models
{
    public class Oficina
    {
        public int OficinaId { get; set; }

        [Required(ErrorMessage ="Nome da oficina é obrigatório")]
        [StringLength(50)]

        [Display(Name = "Oficina")]
        public string OficinaNome { get; set; }

        public bool IsOficinaPreferida { get; set; }

        [Required(ErrorMessage = "Telefone é obrigatório")]
        [StringLength(25)]
        [DataType(DataType.PhoneNumber)]
        public string OficinaTelefone { get; set; }

        [Required(ErrorMessage = "Informe o email.")]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])",
    ErrorMessage = "O email não possui um formato correto")]
        public string OficinaEmail { get; set; }

        [Required(ErrorMessage = "Informe o seu CEP")]
        [Display(Name = "CEP")]
        [StringLength(10, MinimumLength = 8)]
        public string OficinaCEP { get; set; }

        [Required(ErrorMessage = "Informe o seu endereço")]
        [StringLength(100)]
        [Display(Name = "Endereço")]
        public string OficinaLogradouro { get; set; }

        [Required(ErrorMessage = "Informe o número no endereço")]
        public int OficinaNumero { get; set; }
        public string OficinaComplemento { get; set; }

        [Required(ErrorMessage = "Informe o nome do Bairro")]
        public string OficinaBairro { get; set; }

        [Required(ErrorMessage = "Informe o nome da Cidade")]
        [StringLength(50)]
        public string OficinaCidade { get; set; }

        [Required(ErrorMessage = "Informe o nome do Estado")]
        [StringLength(50)]
        public string OficinaEstado { get; set; }
        public int LocalId { get; set; }
        public virtual Local Local { get; set; }
        public List<Servico> Servico { get; set; }
    }
}
