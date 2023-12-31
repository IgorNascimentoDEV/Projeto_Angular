using back.Domain.Interfaces;
using back.Domain.Models;
using back.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Eventing.Reader;

namespace back.Infrastructure.Repositories
{
    public class ItensRepository : BaseRepository, IItensRepository
    {
        private readonly ApplicationDbContext _context;
        public ItensRepository(ApplicationDbContext context) : base(context)
        {
            this._context = context;    
        }

        public async Task<IEnumerable<ItensModel>> GetItensAsync()
        {
            return await _context.Itens.ToListAsync();
        }

        public async Task<ItensModel> GetItensByIdAsync(long id)
        {
            return await _context.Itens.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<ItensModel> GetItensByCodigoAsync(long codigo)
        {
            return await _context.Itens.Where(x => x.Codigo == codigo).FirstOrDefaultAsync();
        }
    }
}
