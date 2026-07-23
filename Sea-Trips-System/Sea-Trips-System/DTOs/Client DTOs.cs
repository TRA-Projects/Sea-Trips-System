using System.ComponentModel.DataAnnotations;

namespace Sea_Trips_System.DTOs
{
    // ── Request DTOs — what the client sends ─────────────────────────────────

    /// <summary>
    /// DTO used when registering or creating a new client.
    /// </summary>
    public class CreateClientDto                                                  //CreateClientDto: لإضافة عميل جديد.
    {
        [Required(ErrorMessage = "Full name is required.")]
        [MaxLength(100, ErrorMessage = "Full name cannot exceed 100 characters.")]
        public string fullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone number is required.")]
        [MaxLength(20, ErrorMessage = "Phone number cannot exceed 20 characters.")]
        public string phone { get; set; } = string.Empty;

        [MaxLength(100, ErrorMessage = "Email cannot exceed 100 characters.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string email { get; set; } = string.Empty;
    }

    /// <summary>
    /// DTO used when updating an existing client's profile.
    /// </summary>
    public class UpdateClientDto                                                   //UpdateClientDto: لتحديث بيانات العميل.
    {
        [Required(ErrorMessage = "Full name is required.")]
        [MaxLength(100, ErrorMessage = "Full name cannot exceed 100 characters.")]
        public string fullName { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [MaxLength(20, ErrorMessage = "Phone number cannot exceed 20 characters.")]
        public string phone { get; set; }

        [MaxLength(100, ErrorMessage = "Email cannot exceed 100 characters.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string email { get; set; }
    }

    /// <summary>
    /// DTO used for client login credentials.
    /// </summary>
    public class ClientLoginDto                                                     //ClientLoginDto: لتقديم إيميل وكلمة مرور العميل في طلب التسجيل.
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string password { get; set; }
    }

    // ── Response DTOs — what the API sends back ───────────────────────────────

    /// <summary>
    /// Basic DTO returned for client details or listing queries.
    /// </summary>
    public class ClientResponseDto                               // ClientResponseDto: لاسترجاع وعرض بيانات العميل كاملة للواجهة الأمامية.
    {
        public int clientId { get; set; }
        public string fullName { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public DateTime createdAt { get; set; }
    }

    /// <summary>
    /// DTO returned after a successful login attempt containing the JWT Token.
    /// </summary>
    public class ClientLoginResponseDto                         //ClientLoginResponseDto:  المخصص عند التسجيل بنجاحTokenلإرجاع بيانات العميل مع الـ 
    {
        public string token { get; set; }
        public int clientId { get; set; }
        public string fullName { get; set; }
        public string email { get; set; }
    }
}