using ClientService.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace ClientService.Models.Requests.ClientModels
{
    public class CreateClientRequest
    {
        [Required]
        [StringLength(12)]
        public string Inn { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        public ClientType ClientType { get; set; }
    }
}
