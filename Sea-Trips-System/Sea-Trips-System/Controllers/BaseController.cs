using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Sea_Trips_System.Controllers
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        /// <summary>
        /// دالة مساعدة لاستخراج ID المستخدم الحالي من الـ JWT Token
        /// </summary>
        [NonAction]
        protected int GetCurrentUserId()
        {
            // البحث عن الـ Claim الخاص بالـ ID بالاسم المخصص أو المعياري
            var userIdClaim = User.FindFirst("userId")?.Value
                           ?? User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (int.TryParse(userIdClaim, out int userId))
            {
                return userId;
            }

            return 0; // إرجاع 0 في حال عدم العثور على الـ ID أو فشل التحويل
        }

        /// <summary>
        /// دالة مساعدة لاستخراج دور/صلاحية المستخدم الحالي (Role)
        /// </summary>
        [NonAction]
        protected string GetCurrentUserRole()
        {
            return User.FindFirst(ClaimTypes.Role)?.Value
                ?? User.FindFirst("role")?.Value
                ?? string.Empty;
        }
    }
}