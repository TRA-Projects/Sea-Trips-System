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
