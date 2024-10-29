using System.ComponentModel.DataAnnotations;

namespace ClientService.Models.Requests.ClientModels
{
    public class DeleteClientRequest
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int Id { get; set; }
    }
}
