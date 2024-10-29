using System.ComponentModel.DataAnnotations;

namespace ClientService.Models.Requests.ClientModels
{
    public class UpdateClientRequest
    {
        [Range(1, int.MaxValue)]
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(255)]
        public string Name { get; set; }
    }
}
