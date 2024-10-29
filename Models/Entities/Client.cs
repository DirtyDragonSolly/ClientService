using ClientService.Models.Enums;

namespace ClientService.Models.Entities
{
    public class Client
    {
        public int Id { get; set; }

        public required string Inn { get; set; }

        public required string Name { get; set; }

        public ClientType Type { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public bool IsActive { get; set; } = true;


        public IEnumerable<Founder> Founders { get; set; }
    }
}
