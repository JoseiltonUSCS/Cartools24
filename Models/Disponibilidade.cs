namespace Cartools.Models
{
    public class Disponibilidade
    {
        public Disponibilidade()
        {
            HorasDisponibilidade = new List<HoraDisponibilidade>();
        }
        public int DisponibilidadeId { get; set; }
        public DateTime Data { get; set; }
        public TimeSpan HorarioInicio { get; set; }
        public TimeSpan HorarioFim { get; set; }
        public int OficinaId { get; set; }
        public Oficina Oficina { get; set; }
        public List<HoraDisponibilidade> HorasDisponibilidade { get; set; }

    }
}
