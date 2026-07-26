using Sea_Trips_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Sea_Trips_System.Repositories
{
    public class EventRepository
    {
        private SeaTripsContext context;


        public EventRepository(SeaTripsContext context)
        {
            this.context = context;
        }



        // Get All Events
        public List<Event> GetAll()
        {
            return context.Events
                .Include(e => e.Appointments)
                .ToList();
        }



        // Get Event By Id
        public Event GetById(int eventId)
        {
            return context.Events
                .Include(e => e.Appointments)
                .FirstOrDefault(e => e.eventId == eventId);
        }



        // Add Event
        public void Add(Event eventObj)
        {
            context.Events.Add(eventObj);
            context.SaveChanges();
        }



        // Update
        public void Update()
        {
            context.SaveChanges();
        }



        // Delete
        public void Delete(Event eventObj)
        {
            context.Events.Remove(eventObj);
            context.SaveChanges();
        }

    }
}