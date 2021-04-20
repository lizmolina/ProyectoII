using System.Collections.Generic;

namespace TimeTracking.Models
{
    public class Project
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
         public List<User> Users { get; set; }
    }
}