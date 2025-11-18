using NovaFlix.Application.Features.Profiles.Dto;
using NovaFlix.Domain.Entities;

namespace NovaFlix.Application.Common.Interfaces
{
    public interface IProfileService
    {
        Task<User> GetUserAsync();
        Task UpdateUserAsync(UpdateDto dto);
    }
}
