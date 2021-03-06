using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SpecWheels.Models.User
{

    public class ApplicationDbContext : IdentityDbContext<UserModel>
    {
        public ApplicationDbContext()
            : base("SpecWheelsConnection")
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }

    public class LoginUserModel : IdentityUser
    {
        [Required]
        [Display(Name = "Email")]
        public String Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }

    public class UserModel : IdentityUser
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [MaxLength(40)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(40)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [MaxLength(40)]
        [Display(Name = "Nickname")]
        public string Nickname { get; set; }

        [Display(Name = "Register Date")]
        public DateTime RegisterDate { get; set; }

        [Display(Name = "Inactive Date")]
        public DateTime? InactiveDate { get; set; }

        //[Display(Name = "Privacy Level")]
        //public UserPrivacyLevelEnum UserPrivacyLevel { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }

        public UserModel()
        {
            RegisterDate = DateTime.Now;
            //UserPrivacyLevel = UserPrivacyLevelEnum.User;
        }
        
        public bool isActive()
        {
            return InactiveDate == null;
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<UserModel> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}