using ClientService.Models.Requests.FounderModels;
using ClientService.Models.Responses.FounderModels;

namespace ClientService.Services.Interfaces
{
    public interface IFounderManager
    {
        Task<GetFounderResponse> GetAsync(int id);
        Task<int> CreateAsync(CreateFounderRequest founderRequest);
        Task DeleteAsync(DeleteFounderRequest founderRequest);
        Task UpdateAsync(UpdateFounderRequest founderRequest);
    }
}
