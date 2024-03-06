using System.ComponentModel.DataAnnotations;

namespace Cartools.Models
{
    public class Endereco
    {
        public int EnderecoId { get; set; }
        [Required(ErrorMessage = "Informe o cep")]
        public string CEP { get; set; }
        [Required(ErrorMessage = "Informe o nome da Rua/Avenida")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "Informe o número do endereço")]
        public int Numero { get; set; }
        public string Complemento { get; set; }

        [Required(ErrorMessage = "Informe o nome do Bairro")]
        public string Bairro { get; set;}

        [Required(ErrorMessage = "Informe o nome da Cidade")]
        public string Cidade { get; set;}

        [Required(ErrorMessage = "Informe o nome do Estado")]
        public string Estado { get; set; }
        public List<Servico> Servicos { get; set; }
    }
}
