using _9dars.Models;

namespace _9dars;

internal class Program
{
    static void Main(string[] args)
    {


    }

    public static void RunProgram()
    {

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
                    if (Console.ReadLine() == "end")
                    {
                        break;
                    }
                    meet.Tags.Add(Console.ReadLine());
                }

                Console.Write("Enter event attendees: ");
                while (true)
                {
                    if (Console.ReadLine() == "end")
                    {
                        break;
                    }
                    meet.Attendees.Add(Console.ReadLine());
                }
            }

            else if (option == "2")
            {
                Console.Write("Enter event id to remove: ");
                var eventIdToRemove = Guid.Parse(Console.ReadLine());


            }
        }
    }
}
