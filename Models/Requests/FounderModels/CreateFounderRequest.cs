using System.ComponentModel.DataAnnotations;

namespace ClientService.Models.Requests.FounderModels
{
    public class CreateFounderRequest
    {
        [Required]
        [StringLength(12)]
        public string Inn { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(100)]
        public string FullName { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int ClientId { get; set; }
    }
}
