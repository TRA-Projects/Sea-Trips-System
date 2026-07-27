using Sea_Trips_System.DTOs;
using Sea_Trips_System.Models;
using Sea_Trips_System.Repositories;

namespace Sea_Trips_System.Services
{
    public class AppointmentStaffServices
    {

        private AppointmentStaffRepo appointmentStaffRepo;
        private AppointmentRepo appointmentRepo;
        private StaffRepo staffRepo;


        public AppointmentStaffServices(AppointmentStaffRepo _appointmentStaffRepo,
                                         AppointmentRepo _appointmentRepo,
                                         StaffRepo _staffRepo)

        {
            appointmentStaffRepo = _appointmentStaffRepo;
            appointmentRepo = _appointmentRepo;
            staffRepo = _staffRepo;

        }


        // 1. Get all staff assigned to appointments
        public List<AppointmentStaffResponseDto> GetAll()
        {
            List<AppointmentStaff> list = appointmentStaffRepo.GetAll();
            List<AppointmentStaffResponseDto> dtoList = new List<AppointmentStaffResponseDto>();

            foreach (AppointmentStaff item in list)
            {
                dtoList.Add(MapToDto(item));
            }

            return dtoList;
        }


        // 2. Get assigned staff by appointment ID
        public List<AppointmentStaffResponseDto> GetByAppointmentId(int appointmentId)
        {
            List<AppointmentStaff> list = appointmentStaffRepo.GetByAppointmentId(appointmentId);
            List<AppointmentStaffResponseDto> dtoList = new List<AppointmentStaffResponseDto>();

            foreach (AppointmentStaff item in list)
            {
                dtoList.Add(MapToDto(item));
            }

            return dtoList;
        }



        // 3. Assign staff member to an appointment
        public AppointmentStaffResponseDto? AssignStaff(AssignStaffDto dto)
        {
            // A) التأكد من وجود الحجز
            Appointment? appointment = appointmentRepo.GetById(dto.appointmentId);
            if (appointment == null)
                return null;

            // B) التأكد من وجود الموظف
            Staff? staff = staffRepo.GetById(dto.staffId);
            if (staff == null)
                return null;

            // C) منع التكرار: التأكد أن الموظف غير معين مسبقاً بنفس هذا الحجز
            if (appointmentStaffRepo.IsAlreadyAssigned(dto.appointmentId, dto.staffId))
                return null;

            // D) Create and save new assignment
            AppointmentStaff appointmentStaff = new AppointmentStaff
            {
                appointmentId = dto.appointmentId,
                staffId = dto.staffId,
                assignedRole = dto.assignedRole ?? staff.role // Fallback to staff's default role if unassigned
            };

            appointmentStaffRepo.Add(appointmentStaff);

            // Fetch created record with includes to project onto DTO
            AppointmentStaff? savedItem = appointmentStaffRepo.GetById(appointmentStaff.appointmentStaffId);
            return savedItem != null ? MapToDto(savedItem) : null;
        }


        // 4. Remove staff assignment from an appointment
        public bool RemoveStaffAssignment(int id)
        {
            AppointmentStaff? item = appointmentStaffRepo.GetById(id);
            if (item == null)
                return false;

            appointmentStaffRepo.Delete(item);
            return true;
        }



        // ── Helper: Mapper ──────────────────────────────────────────
        private AppointmentStaffResponseDto MapToDto(AppointmentStaff item)
        {
            return new AppointmentStaffResponseDto
            {
                appointmentStaffId = item.appointmentStaffId,
                appointmentId = item.appointmentId,
                staffId = item.staffId,
                staffName = item.Staff?.name,
                staffRole = item.Staff?.role,
                assignedRole = item.assignedRole
            };

        }
    }
}
