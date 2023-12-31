using back.Domain.Interfaces;
using back.Domain.Models;
using back.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace back.Infrastructure.Repositories
{
    public class SolicitacoesRepository : BaseRepository, ISolicitacoesRepository
    {
        private readonly ApplicationDbContext _context;
        public SolicitacoesRepository(ApplicationDbContext context) : base(context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<SolicitacoesModel>> GetSolicitacoesAsync()
        {
            return await _context.Solicitacoes.Include(x => x.Item).ToListAsync();
        }

        public async Task<SolicitacoesModel> GetSolicitacoesByIdaAsync(long id)
        {
            return await _context.Solicitacoes.Include(x => x.Item).Where(s => s.Id == id).FirstOrDefaultAsync();
        }
    }
}
