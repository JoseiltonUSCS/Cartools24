using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;


namespace Cartools.Models
{
    public class Oficina
    {
        public int OficinaId { get; set; }
        [Required(ErrorMessage = "Nome da oficina é obrigatório")]
        public string OficinaNome { get; set; }
        public bool IsOficinaPreferida { get; set; }
        public string OficinaTelefone { get; set; }
        public string OficinaEmail { get; set; }
        public string OficinaCEP { get; set; }

        [Required(ErrorMessage = "Informe o nome da Rua/Avenida")]
        public string OficinaLogradouro { get; set; }
        [Required(ErrorMessage = "Informe o número no endereço")]
        public int OficinaNumero { get; set; }
        public string OficinaComplemento { get; set; }

        [Required(ErrorMessage = "Informe o nome do Bairro")]
        public string OficinaBairro { get; set; }

        [Required(ErrorMessage = "Informe o nome da Cidade")]
        public string OficinaCidade { get; set; }

        [Required(ErrorMessage = "Informe o nome do Estado")]
        public string OficinaEstado { get; set; }
        public int LocalId { get; set; }
        public virtual Local Local { get; set; }
        public int PlanoId { get; set; }
        public virtual Plano Plano { get; set; }
        public List<Servico> Servico { get; set; }
        public string UserId { get; set; }
        public virtual IdentityUser User { get; set; }
    }
}
