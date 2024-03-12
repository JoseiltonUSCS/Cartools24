using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Cartools.Models
{
    public class Oficina
    {
        public int OficinaId { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string CEP { get; set; }

        [Required(ErrorMessage = "Informe o nome da Rua/Avenida")]
        public string Logradouro { get; set; }
        [Required(ErrorMessage = "Informe o número no endereço")]
        public int Numero { get; set; }
        public string Complemento { get; set; }

        [Required(ErrorMessage = "Informe o nome do Bairro")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Informe o nome da Cidade")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Informe o nome do Estado")]
        public string Estado { get; set; }
        public int LocalId { get; set; }
        public virtual Local Local { get; set; }
        public ICollection<Servico> Servicos { get; set; }
}
}
