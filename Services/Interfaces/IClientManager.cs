using ClientService.Models.Requests.ClientModels;
using ClientService.Models.Responses.ClientModels;

namespace ClientServise.Services.Interfaces
{
    public interface IClientManager
    {
        Task<GetClientResponse> GetAsync(int id);
        Task<int> CreateAsync(CreateClientRequest clientRequest);
        Task UpdateAsync(UpdateClientRequest clientRequest);
        Task DeleteAsync(DeleteClientRequest clientRequest);
    }
}
