namespace ClientService.Models.Entities
{
    public class Founder
    {
        public int Id { get; set; }

        public string Inn { get; set; }

        public string FullName { get; set; }

        public Client Client { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }
    }
}
