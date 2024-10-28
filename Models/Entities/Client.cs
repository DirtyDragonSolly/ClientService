using ClientService.Models.Enums;

namespace ClientService.Models.Entities
{
    public class Client
    {
        public int Id { get; set; }

        public string Inn { get; set; }

        public string Name { get; set; }

        public ClientType Type { get; set; }

        public List<Founder> Founders { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }
    }
}
