using System.ComponentModel.DataAnnotations;

namespace ClientService.Models.Requests.FounderModels
{
    public class DeleteFounderRequest
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int Id { get; set; }
    }
}
