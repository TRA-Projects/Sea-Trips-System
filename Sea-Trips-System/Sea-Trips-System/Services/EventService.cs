using Sea_Trips_System.DTOs;
using Sea_Trips_System.Models;
using Sea_Trips_System.Repositories;

namespace Sea_Trips_System.Services
{
    public class EventService
    {
        // EventRepository repo = new EventRepository();

        private EventRepo eventRepository;


        public EventService(EventRepo eventRepository)
        {
            repo = _repo;
        }




       // // Get All Events
        public List<EventOutputDTO> GetAllEvents()

        {
            List<Event> events = repo.GetAll();

            return events.Select(e => new EventOutputDTO
            {
                eventId = e.eventId,
                eventName = e.eventName,
                discountRate = e.discountRate,
                isActive = e.isActive

            }).ToList();
        }




        /// Get Event By Id//
        public EventAllOutputDTO GetEventById(int id)
        {
            Event e = repo.GetById(id);

            if (e == null)
            {
                return null;
            }

            return new EventAllOutputDTO
            {
                eventId = e.eventId,
                eventName = e.eventName,
                discountRate = e.discountRate,
                isActive = e.isActive,
                Appointments = e.Appointments
            };
        }

        // Create Event
        public int Create(EventInputDTO dto)
        {
            Event e = new Event
            {
                eventName = dto.eventName,
                discountRate = dto.discountRate,
                isActive = dto.isActive
            };

            repo.Add(e);

            return e.eventId;
        }

        // Update Discount Rate
        public bool UpdateDiscountRate(int eventId, decimal newRate)
        {
            Event e = repo.GetById(eventId);

            if (e == null)
            {
                return false;
            }

            e.discountRate = newRate;

            repo.Update();

            return true;
        }

        // Delete Event
        public bool Delete(int eventId)
        {
            Event e = repo.GetById(eventId);

            if (e == null)
            {
                return false;
            }

            repo.Delete(e);

            return true;
        }
    }
}