using Eventually.Memory;

EventRepository eventRepository = new EventRepository();
var evento = eventRepository.GetById(1L);


Console.BackgroundColor = ConsoleColor.Green;
Console.ForegroundColor = ConsoleColor.Black;
Console.WriteLine("Eventually\n");
Console.BackgroundColor = ConsoleColor.Black;
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine(
@$"Event name: {evento.Name}
Location: {evento.Location}
Start Date: {evento.StartDate}, Time: {evento.StartTime}
Finish Date: {evento.FinishDate}, Time: {evento.FinishTime})
Cost: {evento.Cost}
");
Console.WriteLine("Necessary items:");
foreach(var item in evento.Items)
{
    Console.WriteLine(item.Name);
}
Console.WriteLine($"\nParticipates({evento.Participates.Count}):");
foreach (var participate in evento.Participates)
{
    Console.WriteLine(participate.Name);
}

Console.Read();