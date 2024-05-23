namespace Cartools.Models
{
    public class HoraDisponibilidade
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public TimeSpan Horario { get; set; }
        public int DisponibilidadeId { get; set; }
        public Disponibilidade Disponibilidade { get; set; }
    }

}
