using _9dars.Models;
using _9dars.Services;

namespace _9dars;

internal class Program
{
    static void Main(string[] args)
    {
        RunEventProgram();
    }

    public static void RunEventProgram()
    {
        var eventService = new EventService();

        while (true)
        {
            Console.WriteLine("1. Add event: ");
            Console.WriteLine("2. Remove event: ");
            Console.WriteLine("3. Modify event: ");
            Console.WriteLine("4. Get all events: ");
            Console.WriteLine("5. Get event: ");
            Console.WriteLine("6. Get event by location: ");
            Console.WriteLine("7. Get popular event: ");
            Console.WriteLine("8. Get max tagged event: ");
            Console.WriteLine("9. Add person to event: ");
            Console.Write("Choose option: ");
            var option = Console.ReadLine();

            if (option == "1")
            {
                var meet = new Event();
                Console.Write("Enter event title: ");
                meet.Title = Console.ReadLine();

                Console.Write("Enter event location: ");
                meet.Location = Console.ReadLine();

                Console.Write("Enter event description: ");
                meet.Description = Console.ReadLine();

                Console.Write("Enter event time: ");
                meet.Date = DateTime.Parse(Console.ReadLine());

                Console.Write("Enter event tags: ");
                while (true)
                {
                    var input = Console.ReadLine();
                    if (input == "end") break;
                    meet.Tags.Add(input);
                }

                Console.Write("Enter event attendees: ");
                while (true)
                {
                    var input = Console.ReadLine();
                    if (input == "end") break;
                    meet.Attendees.Add(input);
                }

                eventService.AddEvent(meet);
            }

            else if (option == "2")
            {
                Console.Write("Enter event id to remove: ");
                var eventIdToRemove = Guid.Parse(Console.ReadLine());
                var eventRemoved = eventService.RemoveEvent(eventIdToRemove);
                Console.WriteLine(eventRemoved ? "Removed" : "Error");
            }

            else if (option == "3")
            {
                var meet = new Event();
                Console.Write("Enter id to modify event: ");
                meet.Id = Guid.Parse(Console.ReadLine());

                Console.Write("Enter event title: ");
                meet.Title = Console.ReadLine();

                Console.Write("Enter event location: ");
                meet.Location = Console.ReadLine();

                Console.Write("Enter event description: ");
                meet.Description = Console.ReadLine();

                Console.Write("Enter event time: ");
                meet.Date = DateTime.Parse(Console.ReadLine());

                Console.Write("Enter event tags: ");
                while (true)
                {
                    var input = Console.ReadLine();
                    if (input == "end") break;
                    meet.Tags.Add(input);
                }

                Console.Write("Enter event attendees: ");
                while (true)
                {
                    var input = Console.ReadLine();
                    if (input == "end") break;
                    meet.Attendees.Add(input);
                }

                var modifiedEvent = eventService.ModifyEvent(meet);
                Console.WriteLine(modifiedEvent ? "Modified" : "Error");
            }

            else if (option == "4")
            {
                var events = eventService.GetEvents();

                foreach (var meet in events)
                {
                    var info = $"ID:  {meet.Id},   TITLE: {meet.Title},   DESCRIPTION: {meet.Description},   " +
                        $"LOCATION: {meet.Location},   DATE: {meet.Date.Date}";

                    Console.Write($"{info}");

                    Console.Write(",   ATTENDEES: ");
                    eventService.GetEventAttendees();

                    Console.Write("   TAGS: ");
                    eventService.GetEventTags();
                }
            }

            else if (option == "5")
            {
                Console.Write("Enter id to get event: ");
                var id = Guid.Parse(Console.ReadLine());

                var meet = eventService.GetEvent(id);
                var info = $"ID:  {meet.Id},   TITLE: {meet.Title},   DESCRIPTION: {meet.Description},   " +
                        $"LOCATION: {meet.Location},   DATE: {meet.Date.Date}";

                Console.Write($"{info}");

                Console.Write(",   ATTENDEES: ");
                eventService.GetEventAttendees();

                Console.Write("   TAGS: ");
                eventService.GetEventTags();
            }

            else if (option == "6")
            {
                Console.Write("Enter location to get event: ");
                var location = Console.ReadLine();

                var events = eventService.GetEventsByLocation(location);
                foreach (var meet in events)
                {
                    var info = $"ID:  {meet.Id},   TITLE: {meet.Title},   DESCRIPTION: {meet.Description},   " +
                        $"LOCATION: {meet.Location},   DATE: {meet.Date.Date}";

                    Console.Write($"{info}");

                    Console.Write(",   ATTENDEES: ");
                    eventService.GetEventAttendees();

                    Console.Write("   TAGS: ");
                    eventService.GetEventTags();
                }
            }

            else if (option == "7")
            {
                var popularEvent = eventService.GetPopularEvent();

                var info = $"ID:  {popularEvent.Id},   TITLE: {popularEvent.Title},   DESCRIPTION: {popularEvent.Description},   " +
                        $"LOCATION: {popularEvent.Location},   DATE: {popularEvent.Date.Date}";

                Console.Write($"{info}");

                Console.Write(",   ATTENDEES: ");
                eventService.GetEventAttendees();

                Console.Write("   TAGS: ");
                eventService.GetEventTags();
            }

            else if (option == "8")
            {
                var maxTaggedEvent = eventService.GetMaxTaggedEvent();

                var info = $"ID:  {maxTaggedEvent.Id},   TITLE: {maxTaggedEvent.Title},   DESCRIPTION: {maxTaggedEvent.Description},   " +
                        $"LOCATION: {maxTaggedEvent.Location},   DATE: {maxTaggedEvent.Date.Date}";

                Console.Write($"{info}");

                Console.Write(",   ATTENDEES: ");
                eventService.GetEventAttendees();

                Console.Write("   TAGS: ");
                eventService.GetEventTags();
            }

            else if (option == "9")
            {
                Console.Write("Enter person name to add: ");
                var person = Console.ReadLine();

                Console.Write("Enter event id: ");
                var id = Guid.Parse(Console.ReadLine());

                var response = eventService.AddPersonToEvent(person, id);
                Console.WriteLine(response ? "Added" : "Error");
            }

            Console.ReadKey();
            Console.Clear();
        }
    }

}
