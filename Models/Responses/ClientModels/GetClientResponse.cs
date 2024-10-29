using ClientService.Models.Enums;
using ClientService.Models.Responses.FounderModels;

namespace ClientService.Models.Responses.ClientModels
{
    public class GetClientResponse
    {
        public int Id { get; set; }

        public required string Inn { get; set; }

        public required string Name { get; set; }

        public ClientType Type { get; set; }

        public IEnumerable<GetFounderResponse> Founders { get; set; }
    }
}
