using ClientService.Models.Entities;

namespace ClientServise.Services.Interfaces
{
    public interface IClientService
    {
        Task<int> CreateAsync(Client client);
        Task DeleteAsync(int id);
        Task<Client> GetAsync(int id);
        Task UpdateAsync(Client client);
    }
}
