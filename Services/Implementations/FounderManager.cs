using ClientService.Data;
using ClientService.Models.Entities;
using ClientService.Models.Requests.FounderModels;
using ClientService.Models.Responses.FounderModels;
using ClientService.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClientService.Services.Implementations
{
    public class FounderManager : IFounderManager
    {
        private readonly ClientContext _db;

        public FounderManager(ClientContext db)
        {
            _db = db;
        }

        public async Task<GetFounderResponse> GetAsync(int id)
        {
            var founder = await ValidateFounderAsync(id);
            
            var result = new GetFounderResponse
            {
                Id = id,
                Inn = founder.Inn,
                FullName = founder.FullName,
                ClientId = founder.ClientId
            };

            return result;
        }

        public async Task<int> CreateAsync(CreateFounderRequest founderRequest)
        {
            var client = await _db.Clients.FirstOrDefaultAsync(f => f.Id == founderRequest.ClientId);
            
            if (client == null)
            {
                throw new Exception("Client doesn't exist");
            }

            if (!client.IsActive)
            {
                throw new Exception("Client not active");
            }

            if (client.Type == 0)
            {
                throw new Exception("Client type is not Legal Entity");
            }

            var founderEntity = new Founder
            {
                ClientId = client.Id,
                Inn = founderRequest.Inn,
                FullName = founderRequest.FullName,
                CreatedAt = DateTime.UtcNow
            };

            _db.Founders.Add(founderEntity);

            await _db.SaveChangesAsync();

            return founderEntity.Id;
        }

        public async Task UpdateAsync(UpdateFounderRequest founderRequest)
        {
            var founder = await ValidateFounderAsync(founderRequest.Id);

            if (founder.FullName == founderRequest.Name && founder.Inn == founderRequest.Inn)
            {
                return;
            }

            await _db.Founders.Where(f => f.Id == founderRequest.Id)
                .ExecuteUpdateAsync(updates => updates
                    .SetProperty(f => f.FullName, founderRequest.Name)
                    .SetProperty(f => f.Inn, founderRequest.Inn)
                    .SetProperty(f => f.UpdatedAt, DateTime.UtcNow));
        }

        public async Task DeleteAsync(DeleteFounderRequest founderRequest)
        {
            await ValidateFounderAsync(founderRequest.Id);

            await _db.Founders.Where(f => f.Id == founderRequest.Id)
                .ExecuteUpdateAsync(updates => updates
                    .SetProperty(f => f.IsActive, false)
                    .SetProperty(f => f.UpdatedAt, DateTime.UtcNow));
        }        

        private async Task<Founder> ValidateFounderAsync(int id)
        {
            var founder = await _db.Founders.FirstOrDefaultAsync(f => f.Id == id);
            if (founder == null)
            {
                throw new Exception("Founder not found");
            }

            if (!founder.IsActive)
            {
                throw new Exception("Founder not active");
            }            

            return founder;
        }
    }
}
