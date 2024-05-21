using Calendario.Repositories.Interfaces;
using Cartools.Models;

namespace Cartools.Repositories
{
    public class AgendamentoRepository : IAgendamentoRepository
    {
        public IEnumerable<Agendamento> Agendamentos => throw new NotImplementedException();

        public void Agendar(Agendamento agendamento)
        {
            throw new NotImplementedException();
        }

        public Agendamento GetAgendamentoById(int agendamentoId)
        {
            throw new NotImplementedException();
        }
    }
}
