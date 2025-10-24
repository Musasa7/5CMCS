using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5CMCS.Models
{
    public class Lecturer
    {
        public int LecturerId { get; set; }
        public string Name { get; set; } = "IC Lecturer";
        public string Email { get; set; } = "";

        public ICollection<Claim> Claims { get; set; } = new List<Claim>();
    }
}