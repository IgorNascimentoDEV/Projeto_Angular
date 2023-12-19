﻿using back.Domain.Models;

namespace back.Domain.Interfaces
{
    public interface IItensRepository : IBaseRepository
    {
        Task<IEnumerable<ItensModel>> GetItensAsync();
        Task<ItensModel> GetItensByIdAsync(long id);
    }
}

