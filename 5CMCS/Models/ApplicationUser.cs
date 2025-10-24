using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5CMCS.Models
{
    public enum UserRole { Lecturer = 0, ProgrammeCoordinator = 1, AcademicManager = 2 }

    public class ApplicationUser
    {
        public int ApplicationUserId { get; set; }
        public string Username { get; set; } = "";
        public string DisplayName { get; set; } = "";
        public UserRole Role { get; set; } = UserRole.Lecturer;


        public string? PasswordHash { get; set; }
    }
}
