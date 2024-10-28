using ClientService.Models.Entities;
using ClientServise.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClientServise.Services.Implementations
{
    public class ClientService : IClientService
    {
        private readonly DbContext _db;

        public async Task<int> CreateAsync(Client client)
        {
            return int.MaxValue;
        }

        public async Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Client> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Client client) 
        {
            throw new NotImplementedException();
        }
    }
}
