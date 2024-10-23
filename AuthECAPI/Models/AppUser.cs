using Microsoft.AspNetCore.Identity;

namespace AuthECAPI.Models
{
    public class AppUser : IdentityUser
    {
        [PersonalData]

        public string? FullName { get; set; }

        [PersonalData]
        public string? Gender { get; set; }


        [PersonalData]
        public DateOnly DOB { get; set; }



        [PersonalData]
        public int? LibraryID { get; set; }
    }
}
