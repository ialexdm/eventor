using Eventor;
using Eventor.Memory;

EventoRepository eventRepository = new EventoRepository();

PrintAllEventos(eventRepository);
Console.WriteLine();
Console.WriteLine("If you want to create new evento press N.");
var userInputKey = Console.ReadKey();
if (userInputKey.Key == ConsoleKey.N)
{
    Console.Clear();
    string name = inputEventoData(nameof(name));
    string location = inputEventoData(nameof(location));
    DateTime startDate = InputDateTime(true);
    DateTime finishDate = InputDateTime(false);
    decimal cost = decimal.Parse(inputEventoData(nameof(cost)));

    LinkedList<Participate> participates = new LinkedList<Participate>();
    string inputParticipate;
    do
    {
        Console.WriteLine("Enter name of participate, or enter \"end\"");
        inputParticipate = Console.ReadLine();
        if (string.IsNullOrEmpty(inputParticipate) || inputParticipate.Count() < 3)
        {
            Console.WriteLine("Participate name mast have 3 or more letters");
            break;
        }
        participates.AddLast(new Participate(participates.Count + 1, inputParticipate));
    } while (inputParticipate != "end");
    LinkedList<Item> items = new LinkedList<Item>();
    string inputItem;
    do
    {
        Console.WriteLine("Enter name of necessary item, or enter \"end\"");
        inputItem = Console.ReadLine();
        if (string.IsNullOrEmpty(inputItem) || inputItem.Count() < 3)
        {
            Console.WriteLine("necessary name mast have 3 or more letters");
            break;
        }
        else
        {
            items.AddLast(new Item(items.Count + 1, inputItem));
        }
        
    } while (inputItem != "end");

    Evento newEvento = new Evento(
        Evento.Count +1,
        name,
        location,
        DateOnly.FromDateTime(startDate),
        DateOnly.FromDateTime(finishDate),
        TimeOnly.FromDateTime(startDate),
        TimeOnly.FromDateTime(finishDate),
        cost,
        participates,
        items);
    eventRepository.AddEvento(newEvento);
    Console.Clear();
    PrintAllEventos(eventRepository);
}
static string inputEventoData(string varName)
{
    string? result = null;
    while (string.IsNullOrEmpty(result))
    {
        Console.Write($"Input Evento {varName}: ");
        result = Console.ReadLine();
        Console.WriteLine();
    }
    return result;
}

Console.Read();

static DateTime InputDateTime(bool isStartDateTime)
{
    string startOrFinish = isStartDateTime ? "start" : "finish";
    int day = int.Parse(inputEventoData(startOrFinish + nameof(day)));
    int month = int.Parse(inputEventoData(startOrFinish + nameof(month)));
    int year = int.Parse(inputEventoData(startOrFinish + nameof(year)));
    int hour = int.Parse(inputEventoData(startOrFinish + nameof(hour)));
    int minute = int.Parse(inputEventoData(startOrFinish + nameof(minute)));

    return new DateTime(day, month, year, hour, minute, 0); ;
}

static void PrintEvento(Evento evento)
{
    Console.BackgroundColor = ConsoleColor.Green;
    Console.ForegroundColor = ConsoleColor.Black;
    Console.WriteLine("EVENTOR\n");
    Console.BackgroundColor = ConsoleColor.Black;
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(
    @$"Evento name: {evento.Name}
Location: {evento.Location}
Start Date: {evento.StartDate}, Time: {evento.StartTime}
Finish Date: {evento.FinishDate}, Time: {evento.FinishTime})
Cost: {evento.Cost}
");
    Console.WriteLine("Necessary items:");
    foreach (var item in evento.Items)
    {
        Console.WriteLine(item.Name);
    }
    Console.WriteLine($"\nParticipates({evento.Participates.Count}):");
    foreach (var participate in evento.Participates)
    {
        Console.WriteLine(participate.Name);
    }
}

static void PrintAllEventos(EventoRepository eventRepository)
{
    long count = Evento.Count;
    while (count > 0)
    {
        var evento = eventRepository.GetById(count);
        PrintEvento(evento);
        count--;
    }
}