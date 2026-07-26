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


        // 3. Create new staff member
        public StaffResponseDto Create(CreateStaffDto dto)
        {
            Staff staff = new Staff
            {
                name = dto.name,
                role = dto.role,
                licenseNumber = dto.licenseNumber,
                phone = dto.phone,
                isAvailable = true // الموظف يكون متاح تلقائياً عند الإضافة
            };

            staffRepo.Add(staff);
            return MapToDto(staff);
        }


        // 4. Update staff details
        public StaffResponseDto? Update(int id, UpdateStaffDto dto)
        {
            Staff? staff = staffRepo.GetById(id);
            if (staff == null)
                return null;

            staff.name = dto.name;
            staff.role = dto.role;
            staff.licenseNumber = dto.licenseNumber;
            staff.phone = dto.phone;
            staff.isAvailable = dto.isAvailable;

            staffRepo.Update();
            return MapToDto(staff);
        }

        // 5. Delete staff
        public bool Delete(int id)
        {
            Staff? staff = staffRepo.GetById(id);
            if (staff == null)
                return false;

            staffRepo.Delete(staff);
            return true;
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