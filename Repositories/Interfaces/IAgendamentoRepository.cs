using Cartools.Models;

namespace Calendario.Repositories.Interfaces
{
    public interface IAgendamentoRepository
    {
        IEnumerable<Agendamento> Agendamentos { get; }
        //IEnumerable<Disponibilidade> GetDisponibilidade(DateTime data);
        Agendamento GetAgendamentoById(int agendamentoId);
        void Agendar(Agendamento agendamento);
        //void DefinirHorarios(List<HorarioDisponivel> horarios);
    }
}
