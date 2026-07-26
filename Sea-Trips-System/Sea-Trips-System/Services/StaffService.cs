using static Sea_Trips_System.Models.StaffDTOs;

namespace Sea_Trips_System.Models
{
    public class StaffService
    {
        private StaffRepo staffRepo;
        public StaffService(StaffRepo _staffRepo)
        {
            staffRepo = _staffRepo;
        }

        // 1. Get all staff
        public List<StaffResponseDto> GetAll()
        {
            List<Staff> staffList = staffRepo.GetAll();
            List<StaffResponseDto> dtoList = new List<StaffResponseDto>();

            foreach (Staff staff in staffList)
            {
                dtoList.Add(MapToDto(staff));
            }

            return dtoList;
        }



        // 2. Get staff by ID
        public StaffResponseDto? GetById(int id)
        {
            Staff? staff = staffRepo.GetById(id);
            if (staff == null)
                return null;

            return MapToDto(staff);
        }







        // ──*** Private Helper: Mapper ──***
        private StaffResponseDto MapToDto(Staff staff)
        {
            return new StaffResponseDto
            {
                staffId = staff.staffId,
                name = staff.name,
                role = staff.role,
                licenseNumber = staff.licenseNumber,
                isAvailable = staff.isAvailable,
                phone = staff.phone
            };

        }
    }
}