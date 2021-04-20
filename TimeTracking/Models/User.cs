using System.Collections.Generic;

namespace TimeTracking.Models
{
    public class User
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<Project> Projects { get; set; }
    }
}