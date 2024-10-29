namespace ClientService.Models.Entities
{
    public class Founder
    {
        public int Id { get; set; }

        public required string Inn { get; set; }

        public required string FullName { get; set; }

        public int ClientId { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public bool IsActive { get; set; }


        public Client Client { get; set; }
    }
}
