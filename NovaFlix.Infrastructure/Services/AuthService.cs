using NovaFlix.Application.Common.Interfaces;
using NovaFlix.Application.Features.Auth.Dto;
using NovaFlix.Infrastructure.Persistance;

namespace NovaFlix.Infrastructure.Services
{
    public class AuthService(DatabaseContext db) : IAuthService
    {
        private readonly DatabaseContext _db = db;
        public async Task<TokenDto> LoginAsync(LoginDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task<TokenDto> RegisterAsync(RegisterDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
