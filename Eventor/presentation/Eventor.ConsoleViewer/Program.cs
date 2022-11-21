
using Eventor;
using Eventor.Memory;
bool shutdown = false;

IEventoRepository eventoRepository = new EventoRepository();
while(!shutdown)
{
    Console.Clear();
    string userInput = ShowAllEventos(eventoRepository, out shutdown);

    if (int.TryParse(userInput, out var id))
    {
        var choosenEvento = eventoRepository.GetById(id);
        Console.Clear();
        ShowEvento(choosenEvento);
        Console.ReadKey();
    }
    else if (userInput.ToLower().Trim() == "new")
    {
        Evento evento = CreateNewEvento(eventoRepository);
        ShowEvento(evento);

        Console.ReadKey();
    }
}


static DateOnly InputDate()
{
    string inputYear;
    int year;
    do
    {
        Console.Write("YYYY:");
        inputYear = Console.ReadLine() ?? "";

    } while (inputYear.Count() != 4 || !int.TryParse(inputYear, out year));
    string inputMonth;
    int month;
    do
    {
        Console.Write("MM:");
        inputMonth = Console.ReadLine() ?? "";

    } while (inputMonth.Count() != 2 || !int.TryParse(inputMonth, out month));
    string inputDay;
    int Day;
    do
    {
        Console.Write("DD:");
        inputDay = Console.ReadLine() ?? "";

    } while (inputMonth.Count() != 2 || !int.TryParse(inputDay, out Day));
    return new DateOnly(year, month, Day);
}

static TimeOnly InputTime()
{
    string inputHour;
    int hour;
    do
    {
        Console.Write("hh:");
        inputHour = Console.ReadLine() ?? "";

    } while (inputHour.Count() != 2 || !int.TryParse(inputHour, out hour));
    string inputMinute;
    int minute;
    do
    {
        Console.Write("mm:");
        inputMinute = Console.ReadLine() ?? "";

    } while (inputMinute.Count() != 2 || !int.TryParse(inputMinute, out minute));
    return new TimeOnly(hour, minute);
}

static string ShowAllEventos(IEventoRepository eventoRepository,out bool shutdown)//TODO separate method
{
    var eventos = eventoRepository.GetAll();

    if (eventos != null)
    {
        foreach (var evento in eventos)
        {
            Console.WriteLine($"#{evento.Id} {evento.Name} {evento.BeginDate}");
        }
    }
    Console.WriteLine("input evento id to choose evento," +
        "'new' to create new evento and press enter" +
        "'shutdown' to close app");
    string userInput;
    do
    {
        userInput = Console.ReadLine();
    } while (userInput == null);
    shutdown = userInput.ToLower() == "shutdown";
    return userInput;
}

static string InputName()
{
    Console.WriteLine("enter data and press enter.");
    Console.Write("Name: ");
    string name = Console.ReadLine() ?? "default evento";
    return name;
}

static string InputLocation()
{
    Console.Write("Location: ");
    string location = Console.ReadLine() ?? "uknown location";
    return location;
}

static decimal InputCost()
{
    Console.Write("Cost: ");
    decimal inputCost;
    bool isDecimal = decimal.TryParse(Console.ReadLine(), out inputCost);
    return inputCost;
}

static List<Participate> InputParticipates()
{
    Console.WriteLine("Participates: ");
    Console.WriteLine("(press Enter to finish input)");
    var participates = new List<Participate>();
    bool isParticipate;
    do
    {
        string inputParticipate = Console.ReadLine();
        if (isParticipate = !string.IsNullOrEmpty(inputParticipate))
        {
            participates.Add(new Participate(inputParticipate));
        }
    } while (isParticipate);
    return participates;
}

static List<Item> InputItems()
{
    Console.WriteLine("Items: ");
    Console.WriteLine("(press Enter to finish input)");
    var items = new List<Item>();
    bool isItem;
    do
    {
        string
        inputItem = Console.ReadLine();
        if (isItem = !string.IsNullOrEmpty(inputItem))
        {
            items.Add(new Item(inputItem));
        }
    } while (isItem);
    return items;
}

static void ShowEvento(Evento choosenEvento)
{
    Console.WriteLine($"{choosenEvento.Id} {choosenEvento.Name}" +
        $"\n{choosenEvento.Location}" +
        $"\nbegin {choosenEvento.BeginDate} {choosenEvento.BeginTime}" +
        $"\nend {choosenEvento.EndDate} {choosenEvento.EndTime}");
    foreach (var participate in choosenEvento.Participates)
    {
        Console.WriteLine($"{participate.Id} {participate.Name}");
    }
    Console.WriteLine($"Total: {choosenEvento.Participates.Count}");
    Console.WriteLine();
    foreach (var item in choosenEvento.Items)
    {
        Console.WriteLine($"{item.Id} {item.Name}");
    }
    Console.WriteLine($"Cost: {choosenEvento.Cost}");

}

static Evento CreateNewEvento(IEventoRepository eventoRepository)
{
    Console.Clear();
    var name = InputName();
    var location = InputLocation();
    Console.WriteLine("Begin: ");
    DateOnly beginDate = InputDate();
    TimeOnly beginTime = InputTime();
    Console.WriteLine("End: ");
    DateOnly endDate = InputDate();
    TimeOnly endTime = InputTime();
    var participates = InputParticipates();
    var items = InputItems();
    var cost = InputCost();

    var evento = new Evento(name, location, beginDate, beginTime, endDate, endTime, cost, participates, items);
    eventoRepository.AddEvento(evento);
    Console.Clear();
    return evento;
}