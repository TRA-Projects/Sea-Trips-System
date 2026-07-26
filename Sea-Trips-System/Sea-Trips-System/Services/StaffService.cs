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