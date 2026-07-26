using Sea_Trips_System.DTOs;
using Sea_Trips_System.Models;
using Sea_Trips_System.Repositories;

namespace Sea_Trips_System.Services
{
    public class BoatService
    {
        private BoatRepo boatRepo;

        public BoatService(BoatRepo _boatRepo)
        {
            boatRepo = _boatRepo;
        }

        // ── 1. CreateBoat ────────────────────────────────────────────────────
        public BoatResponseDto CreateBoat(CreateBoatDto dto)
        {
            if (boatRepo.GetByName(dto.boatName) != null)
                return null;

            Boat boat = new Boat
            {
                boatName = dto.boatName,
                capacity = dto.capacity,
                hourlyRate = dto.hourlyRate,
                status = string.IsNullOrEmpty(dto.status) ? "Available" : dto.status
            };

            boatRepo.Add(boat);

            return new BoatResponseDto
            {
                boatId = boat.boatId,
                boatName = boat.boatName,
                capacity = boat.capacity,
                status = boat.status,
                hourlyRate = boat.hourlyRate
            };
        }

        // ── 2. GetBoatById ───────────────────────────────────────────────────
        public BoatResponseDto GetBoatById(int id)
        {
            Boat boat = boatRepo.GetById(id);
            if (boat == null)
                return null;

            return new BoatResponseDto
            {
                boatId = boat.boatId,
                boatName = boat.boatName,
                capacity = boat.capacity,
                status = boat.status,
                hourlyRate = boat.hourlyRate
            };
        }

        // ── 3. GetAllBoats ───────────────────────────────────────────────────
        public List<BoatResponseDto> GetAllBoats()
        {
            List<Boat> boats = boatRepo.GetAll();
            List<BoatResponseDto> result = new List<BoatResponseDto>();

            foreach (var boat in boats)
            {
                result.Add(new BoatResponseDto
                {
                    boatId = boat.boatId,
                    boatName = boat.boatName,
                    capacity = boat.capacity,
                    status = boat.status,
                    hourlyRate = boat.hourlyRate
                });
            }

            return result;
        }

        // ── 4. UpdateBoat ────────────────────────────────────────────────────
        public BoatResponseDto UpdateBoat(int id, UpdateBoatDto dto)
        {
            Boat boat = boatRepo.GetById(id);
            if (boat == null)
                return null;

            boat.boatName = dto.boatName;
            boat.capacity = dto.capacity;
            boat.hourlyRate = dto.hourlyRate;
            if (!string.IsNullOrEmpty(dto.status))
                boat.status = dto.status;

            boatRepo.Update();

            return new BoatResponseDto
            {
                boatId = boat.boatId,
                boatName = boat.boatName,
                capacity = boat.capacity,
                status = boat.status,
                hourlyRate = boat.hourlyRate
            };
        }

        // ── 5. DeleteBoat ────────────────────────────────────────────────────
        public bool DeleteBoat(int id)
        {
            Boat boat = boatRepo.GetById(id);
            if (boat == null)
                return false;

            boatRepo.Delete(boat);
            return true;
        }
    }
}