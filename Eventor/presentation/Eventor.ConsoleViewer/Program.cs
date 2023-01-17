
using Eventor;
using Eventor.Memory;
using Eventor.Services;


EventoService.EventoRepository
  = new EventoMemoryRepository();
bool shutdown = false;
while (!shutdown)
{
    Console.Clear();
    ShowAllEventos();

    string userInput = InputEventoIdOrNew(out shutdown);
    if (!shutdown)
    {
        if (userInput == "new")
        {
            New();
        }
        else
        {
            Console.Clear();
            try
            {
                var choosenEvento = EventoService.GetSingle(userInput);
                ShowEvento(choosenEvento);
            }
            catch(InvalidOperationException e)
            {
                Console.WriteLine("Evento not found.\nPress 'ENTER' to continue...");
            }
            
            Console.ReadKey();
        }
    }
}



static void ShowAllEventos()
{
    var eventos = EventoService.AllEventos();

    if (eventos != null)
    {
        foreach (var evento in eventos)
        {
            Console.WriteLine($"#{evento.Id} {evento.Name} {evento.BeginDate}");
        }
    }
}
static string InputEventoIdOrNew(out bool shutdown)
{
    Console.Write("input evento id or name to choose evento,\n" +
    "'new' to create new evento,\n" +
    "'shutdown' to close app,\n" +
    "and press 'ENTER' to continue...");
    string userInput;
    do
    {
        userInput = Console.ReadLine().ToLower().Trim();
    } while (userInput == null);
    shutdown = userInput == "shutdown";
    return userInput;
}

static void ShowEvento(Evento choosenEvento)
{
    Console.WriteLine($"#{choosenEvento.Id} {choosenEvento.Name}" +
        $"\n{choosenEvento.Location}" +
        $"\nbegin {choosenEvento.BeginDate} {choosenEvento.BeginTime}" +
        $"\nend {choosenEvento.EndDate} {choosenEvento.EndTime}");
    for (int i = 0; i < choosenEvento.Participates.Count(); i++)
    {
        Console.WriteLine($"#{i+1} {choosenEvento.Participates[i].Name}");
    }
    Console.WriteLine($"Total: {choosenEvento.Participates.Count}");
    Console.WriteLine();
    for (int i = 0; i< choosenEvento.Items.Count(); i++)
    {
        Console.WriteLine($"#{i+1} {choosenEvento.Items[i].Name}");
    }
    Console.WriteLine($"Cost: {choosenEvento.Cost}");

}

#region Input Evento Fields

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

#endregion

static void New()
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

    EventoService.CreateNewEvento(name, location, beginDate, beginTime, endDate, endTime, cost, participates, items);
    Console.Clear();

}