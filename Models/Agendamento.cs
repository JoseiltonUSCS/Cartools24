namespace Cartools.Models
{
    public class Agendamento
    {
        public int AgendamentoId { get; set; }
        public DateTime DiaDaSemana { get; set; }
        public DateTime Hora { get; set; }
        public string Disponibilidade { get; set; }
        public int ServicoId { get; set; }
        public virtual Servico Servico { get; set; }
    }
}
