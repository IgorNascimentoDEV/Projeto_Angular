using back.Domain.Models;

namespace back.Domain.Interfaces
{
    public interface ISolicitacoesRepository : IBaseRepository
    {
        Task<IEnumerable<SolicitacoesModel>> GetSolicitacoesAsync();
        Task<SolicitacoesModel> GetSolicitacoesByIdaAsync(long id);
    }
}
