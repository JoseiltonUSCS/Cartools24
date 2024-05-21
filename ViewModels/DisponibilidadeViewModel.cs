namespace Cartools.Models
{
    public class DisponibilidadeViewModel
    {
        public int OficinaId { get; set; }
        public List<HoraDisponibilidadeViewModel> HorasDisponibilidade { get; set; }
    }

    public class HoraDisponibilidadeViewModel
    {
        public string Hora { get; set; }
        public bool Disponivel { get; set; }
        public string ServicoId { get; set; }
        public string NomeServico { get; set; }
    }
}
