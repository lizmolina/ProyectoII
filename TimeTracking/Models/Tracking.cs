namespace TimeTracking.Models
{
    public class Tracking
    {


        public long Id { get; set; }
        public int UserId { get; set; }
        public int ProjectId { get; set; }
        public double Hours { get; set; }
        public string HoursDescription { get; set; }

    }
}