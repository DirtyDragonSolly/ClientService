using ClientService.Data;
using ClientService.Models.Entities;
using ClientService.Models.Requests.ClientModels;
using ClientService.Models.Responses.ClientModels;
using ClientService.Models.Responses.FounderModels;
using ClientService.Services.Implementations;
using ClientServise.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClientServise.Services.Implementations
{
    public class ClientManager : IClientManager
    {
        private readonly ClientContext _db;

        public ClientManager(ClientContext db)
        {
            _db = db;
        }

        public async Task<GetClientResponse> GetAsync(int id)
        {
            var client = await ValidateClientAsync(id);

            var result = new GetClientResponse
            {
                Id = client.Id,
                Inn = client.Inn,
                Name = client.Name,
                Type = client.Type,
                Founders = client.Founders.Select(f => 
                    new GetFounderResponse 
                    {
                        Id = f.Id,
                        Inn = f.Inn,
                        FullName = f.FullName,
                        ClientId = client.Id,
                    }).ToList()
            };

            return result;
        }

        public async Task<int> CreateAsync(CreateClientRequest clientRequest)
        {
            var clientEntity = new Client
            {
                Inn = clientRequest.Inn,
                Name = clientRequest.Name,
                Type = clientRequest.ClientType,
                CreatedAt = DateTime.UtcNow
            };

            _db.Clients.Add(clientEntity);

            await _db.SaveChangesAsync();

            return clientEntity.Id;
        }

        public async Task UpdateAsync(UpdateClientRequest clientRequest)
        {
            var client = await ValidateClientAsync(clientRequest.Id);

            if (client.Name == clientRequest.Name)
            {
                return;
            }

            await _db.Clients.Where(c => c.Id == clientRequest.Id)
                .ExecuteUpdateAsync(updates => updates
                    .SetProperty(c => c.Name, clientRequest.Name)
                    .SetProperty(c => c.UpdatedAt, DateTime.UtcNow));
        }

        public async Task DeleteAsync(DeleteClientRequest clientRequest)
        {
            await ValidateClientAsync(clientRequest.Id);

            using var transaction = await _db.Database.BeginTransactionAsync();

            try
            {
                await _db.Clients.Where(w => w.Id == clientRequest.Id)
                        .ExecuteUpdateAsync(updates => updates
                            .SetProperty(c => c.IsActive, false)
                            .SetProperty(c => c.UpdatedAt, DateTime.UtcNow));

                await _db.Founders.Where(f => f.ClientId == clientRequest.Id)
                    .ExecuteUpdateAsync(updates => updates
                        .SetProperty(f => f.IsActive, false)
                        .SetProperty(f => f.UpdatedAt, DateTime.UtcNow));

                await transaction.CommitAsync();
            }
            catch (Exception ex) 
            {
                await transaction.RollbackAsync();
                
                throw;
            }            
        }

        private async Task<Client> ValidateClientAsync(int id)
        {
            var client = await _db.Clients.Include(i => i.Founders).FirstOrDefaultAsync(c => c.Id == id);

            if (client == null)
            {
                throw new Exception("Client not found");
            }

            if (!client.IsActive)
            {
                throw new Exception("Client not active");
            }

            return client;
        }
    }
}
