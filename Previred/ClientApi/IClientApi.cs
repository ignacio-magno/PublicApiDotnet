using Previred.Domain.ApiResponse;

namespace Previred.ClientApi;

internal interface IClientApi
{
    public Task<ImpositionFromApi> DoFromFile(string pathFile);
    public Task<ImpositionFromApi> DoFromFile(StreamContent file);
}