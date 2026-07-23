using Sea_Trips_System.Models;
using System.Threading.Channels;

namespace Sea_Trips_System.Repositories
{
    public class ClientRepo
    {
        //1. Constructor & Dependency Injection

        private SeaTripsContext context;

        public ClientRepo(SeaTripsContext _context)     
        {
            context = _context;
        }

        //------------------------------------------------------------

        //2. Read Operations (Fetching Data)
        public List<Client> GetAllClients()            //Fetches all client records from the database.
        {
            return context.Clients.ToList();
        }


        public Client GetClientById(int id)             //Finds a client by primary key (clientId)
        {
            return context.Clients.FirstOrDefault(c => c.clientId == id);
        }

        public Client GetClientByEmail(string email)             //Finds a client by unique email.
        {
            return context.Clients.FirstOrDefault(c => c.email == email);
        }

        public Client GetClientByPhone(string phone)                   //Finds a client by phone number.
        {
            return context.Clients.FirstOrDefault(c => c.phone == phone);
        }

        //---------------------------------------------------------------------
        //3. Write Operations (Mutating Data)
        public void Add(Client client)        //Inserts a new client record into the database.
        {
            context.Clients.Add(client);
            context.SaveChanges();
        }

        public void Update()       // Saves any changes made to an existing client.
        {
            context.SaveChanges();
        }

        public void Delete(Client client)           //Removes a client record from the database.
        {
            context.Clients.Remove(client);
            context.SaveChanges();
        }
    }
}