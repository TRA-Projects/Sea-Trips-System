using Microsoft.EntityFrameworkCore;
using Sea_Trips_System.Models;

namespace Sea_Trips_System.Repositories
{
    public class BoatRepo
    {
        private  SeaTripsContext context;

        public BoatRepo(SeaTripsContext _context)
        {
            context = _context;
        }

        // Find a boat by its unique ID
        public Boat GetById(int id)
        {
            return context.Boats.FirstOrDefault(b => b.boatId == id);
        }

        // Find a boat by its name (used to prevent duplicate entries since boatName has a Unique Index)
        public Boat GetByName(string boatName)
        {
            return context.Boats.FirstOrDefault(b => b.boatName == boatName);
        }

        // Retrieve all registered boats from the database
        public List<Boat> GetAll()
        {
            return context.Boats.ToList();
        }

        // إضافة قارب جديد مع تحديد اسمه وسعره
        public void AddWithPrice(string boatName, decimal price)
        {
            var boat = new Boat
            {
                boatName = boatName,
                price = price                    
            };

            context.Boats.Add(boat);
            context.SaveChanges();
        }


        // Add a new boat record to the database
        public void Add(Boat boat)
        {
            context.Boats.Add(boat);
            context.SaveChanges();
        }

        // Save changes for an existing updated boat entity
        public void Update()
        {
            context.SaveChanges();
        }

        // Remove a boat record from the database
        public void Delete(Boat boat)
        {
            context.Boats.Remove(boat);
            context.SaveChanges();
        }
    }
}