

using Sea_Trips_System.DTOs;
using Sea_Trips_System.Models;
using Sea_Trips_System.Repositories;

namespace Sea_Trips_System.Services
{
    public class EventService
    {

        private EventRepository eventRepository;


        public EventService(EventRepository eventRepository)
        {
            this.eventRepository = eventRepository;
        }




       // // Get All Events
        public List<EventOutputDTO> GetAllEvents()
        {

            List<Event> events = eventRepository.GetAll();


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

            Event e = eventRepository.GetById(id);


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


            eventRepository.Add(e);


            return e.eventId;

        }





        // Update Discount Rate
        public bool UpdateDiscountRate(int eventId, decimal newRate)
        {

            Event e = eventRepository.GetById(eventId);


            if (e == null)
            {
                return false;
            }


            e.discountRate = newRate;


            eventRepository.Update();


            return true;

        }





        // Delete Event
        public bool Delete(int eventId)
        {

            Event e = eventRepository.GetById(eventId);


            if (e == null)
            {
                return false;
            }


            eventRepository.Delete(e);


            return true;

        }

    }
}