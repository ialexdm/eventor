namespace Eventor.Services
{
    public static class EventoService
    {
        private static IEventoRepository _eventoRepository;
        public static IEventoRepository EventoRepository { set { _eventoRepository = value; } }

        public static void CreateNewEvento(string name,
            string location,
            DateOnly beginDate,
            TimeOnly beginTime,
            DateOnly endDate,
            TimeOnly endTime,
            decimal cost,
            List<Participate> participates,
            List<Item> items)
        {
            _eventoRepository.CreateEvento(name, location, beginDate, beginTime, endDate, endTime, cost, participates, items);
        }
        public static Evento[] AllEventos() {
            return _eventoRepository.GetAll();
        }
        public static Evento GetSingle(string userInput)
        {
            Evento evento;
            if(long.TryParse(userInput, out long id))
            {
                evento = _eventoRepository.GetById(id);
            }
            else
            {
                evento = _eventoRepository.GetByName(userInput);
            }
            return evento;

        }
    }
}