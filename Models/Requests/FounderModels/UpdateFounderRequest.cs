using System.ComponentModel.DataAnnotations;

namespace ClientService.Models.Requests.FounderModels
{
    public class UpdateFounderRequest
    {
        [Range(1, int.MaxValue)]
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(12)]
        public string Inn { get; set; }
    }
}
