using NovaFlix.Application.Common.Interfaces;
using NovaFlix.Infrastructure.Persistance;

namespace NovaFlix.Infrastructure.Services
{
    public class FilmsService(DatabaseContext db) : IFilmsService
    {
        private readonly DatabaseContext _db = db;
        public async Task CreateFilmAsync()
        {
            throw new NotImplementedException();
        }
    }
}
