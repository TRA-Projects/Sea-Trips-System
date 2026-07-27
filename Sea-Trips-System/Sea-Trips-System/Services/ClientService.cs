using Sea_Trips_System.DTOs;
using Sea_Trips_System.Models;
using Sea_Trips_System.Repositories;
using BCrypt.Net; // مكتبة تشفير كلمة المرور

namespace Sea_Trips_System.Services
{
    public class ClientService
    {
        private ClientRepo clientRepo;                              //private variable that save the connection of clientRepo in class..

        public ClientService(ClientRepo _clientRepo)            //recieve the connecton that's come from clientRepo and inject it to the constructor ---"Dependency injection"---
        {
            clientRepo = _clientRepo;
        }

        // ── 1. Create Client / تسجيل أو إضافة عميل جديد ─────────────────────────
        public ClientResponseDto CreateClient(CreateClientDto dto)
        {
            // Business rule: email must not already be registered
            if (clientRepo.GetClientByEmail(dto.email) != null)
            {
                return null;
            }

            if (clientRepo.GetClientByPhone(dto.phone) != null)
                return null;

            Client client = new Client();
            client.fullName = dto.fullName;
            client.phone = dto.phone;
            client.email = dto.email;
            client.createdAt = DateTime.Now;

            //  تشفير كلمة المرور قبل الحفظ في قاعدة البيانات
            client.passwordHash = BCrypt.Net.BCrypt.HashPassword(dto.password);

            clientRepo.Add(client);

            ClientResponseDto response = new ClientResponseDto();
            response.clientId = client.clientId;
            response.fullName = client.fullName;
            response.phone = client.phone;
            response.email = client.email;
            response.createdAt = client.createdAt;

            return response;
        }

        // ── 2. Client Login / تسجيل دخول العميل ──────────────────────────────
        public ClientResponseDto Login(ClientLoginDto dto)
        {
            // 1. البحث عن العميل باستخدام الإيميل
            Client client = clientRepo.GetClientByEmail(dto.email);
            if (client == null)
                return null;

            // 2. :closed_lock_with_key: التحقق من مطابقة كلمة المرور المدخلة مع المشفّرة في قاعدة البيانات
            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(dto.password, client.passwordHash);
            if (!isPasswordValid)
                return null; // كلمة المرور غير صحيحة

            ClientResponseDto response = new ClientResponseDto();
            response.clientId = client.clientId;
            response.fullName = client.fullName;
            response.phone = client.phone;
            response.email = client.email;
            response.createdAt = client.createdAt;

            return response;
        }

        // ── 3. Get Client By ID / جلب بيانات عميل معين ─────────────────────────
        public ClientResponseDto GetById(int id)
        {
            Client client = clientRepo.GetClientById(id);
            if (client == null)
                return null;

            ClientResponseDto response = new ClientResponseDto();
            response.clientId = client.clientId;
            response.fullName = client.fullName;
            response.phone = client.phone;
            response.email = client.email;
            response.createdAt = client.createdAt;

            return response;
        }

        // ── 4. Update Client / تحديث بيانات العميل الشخصية ────────────────────
        public ClientResponseDto Update(int id, UpdateClientDto dto)
        {
            Client client = clientRepo.GetClientById(id);
            if (client == null)
                return null;

            client.fullName = dto.fullName;
            client.phone = dto.phone;
            client.email = dto.email;

            clientRepo.Update();

            ClientResponseDto response = new ClientResponseDto();
            response.clientId = client.clientId;
            response.fullName = client.fullName;
            response.phone = client.phone;
            response.email = client.email;
            response.createdAt = client.createdAt;

            return response;
        }

        // ── 5. Delete Client / حذف حساب العميل ────────────────────────────────
        public bool Delete(int id)
        {
            Client client = clientRepo.GetClientById(id);
            if (client == null)
                return false;

            clientRepo.Delete(client);
            return true;
        }
    }
}