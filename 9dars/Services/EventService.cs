using _9dars.Models;

namespace _9dars.Services;

public class EventService
{
    private List<Event> Events;
    public EventService()
    {
        Events = new List<Event>();
        DataSeed();
    }

    public Event AddEvent(Event meet)
    {
        meet.Id = Guid.NewGuid();
        Events.Add(meet);

        return meet;
    }

    public bool RemoveEvent(Guid meetId)
    {
        var eventFromDB = GetEvent(meetId);

        if (eventFromDB is null)
        {
            return false;
        }

        Events.Remove(eventFromDB);

        return true;
    }

    public bool ModifyEvent(Event modifiedEvent)
    {
        var eventFromDB = GetEvent(modifiedEvent.Id);

        if (eventFromDB is null)
        {
            return false;
        }

        var index = Events.IndexOf(eventFromDB);
        Events[index] = modifiedEvent;

        return true;
    }

    public Event GetEvent(Guid meetId)
    {
        foreach (var meet in Events)
        {
            if (meet.Id == meetId)
            {
                return meet;
            }
        }

        return null;
    }

    public List<Event> GetEvents()
    {
        return Events;
    }

    public List<Event> GetEventsByLocation(string location)
    {
        var sortedEvents = new List<Event>();
        foreach (var meet in Events)
        {
            if (meet.Location == location)
            {
                sortedEvents.Add(meet);
            }
        }

        return sortedEvents;
    }

    public Event GetPopularEvent()
    {
        var responseEvent = new Event();
        foreach (var meet in Events)
        {
            if (responseEvent.Attendees.Count < meet.Attendees.Count)
            {
                responseEvent = meet;
            }
        }

        return responseEvent;
    }

    public Event GetMaxTaggedEvent()
    {
        var responseEvent = new Event();
        foreach (var meet in Events)
        {
            if (meet.Tags.Count > responseEvent.Tags.Count)
            {
                responseEvent = meet;
            }
        }

        return responseEvent;
    }

    public bool AddPersonToEvent(string person, Guid eventId)
    {
        var meet = GetEvent(eventId);

        if (meet is null)
        {
            return false;
        }

        if (meet.Tags.Contains(person) is true)
        {
            return false;
        }

        meet.Tags.Add(person);
        Events[Events.IndexOf(meet)] = meet;

        return true;
    }

    public void GetEventAttendees()
    {
        foreach (var meet in Events)
        {
            foreach (var item in meet.Attendees)
            {
                Console.Write($"{item}, ");
            }
        }
    }

    public void GetEventTags()
    {
        foreach (var meet in Events)
        {
            foreach (var item in meet.Tags)
            {
                Console.Write($"{item}, ");
            }
        }

        Console.WriteLine();
        Console.WriteLine();
    }

    private void DataSeed()
    {
        var workshop = new Event
        {
            Id = Guid.NewGuid(),
            Title = "C# Workshop",
            Location = "Room 204",
            Date = new DateTime(2024, 12, 10, 14, 0, 0),
            Description = "Hands-on workshop to learn advanced C# features.",
            Attendees = { "Alice", "Bob", "Charlie" },
            Tags = { "C#", "Workshop", "Programming" }
        };

        var techConference = new Event
        {
            Id = Guid.NewGuid(),
            Title = "Tech Conference 2024",
            Location = "Expo Center, Cityville",
            Date = new DateTime(2024, 12, 15, 10, 0, 0),
            Description = "An annual event showcasing the latest in technology and innovation.",
            Attendees = { "Alice", "Bob", "Charlie" },
            Tags = { "Technology", "Conference", "Networking" }
        };

        var codingWorkshop = new Event
        {
            Id = Guid.NewGuid(),
            Title = "C# Coding Workshop",
            Location = "Room 101, Tech Academy",
            Date = new DateTime(2024, 11, 28, 14, 0, 0),
            Description = "A hands-on workshop to learn advanced features of C#.",
            Attendees = { "David", "Ella", "Frank" },
            Tags = { "C#", "Workshop", "Programming" }
        };

        var networkingNight = new Event
        {
            Id = Guid.NewGuid(),
            Title = "Networking Night",
            Location = "Downtown Cafe",
            Date = new DateTime(2024, 11, 30, 19, 0, 0),
            Description = "A casual event to network with other professionals.",
            Attendees = { "Grace", "Hannah", "Ian" },
            Tags = { "Networking", "Social", "Event" }
        };

        Events.Add(codingWorkshop);
        Events.Add(networkingNight);
        Events.Add(workshop);
        Events.Add(techConference);
    }
}