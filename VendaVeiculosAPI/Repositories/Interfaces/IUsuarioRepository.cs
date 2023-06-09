﻿using VendaVeiculosAPI.Filters;
using VendaVeiculosAPI.Models;

namespace VendaVeiculosAPI.Repositories.Interfaces
{
    public interface IUsuarioRepository : IBaseRepository<Usuario, UsuarioFilter>
    {
        Task<Usuario> GetByNameAsync(string name, CancellationToken token);
        Task<Usuario> GetByIdAsync(Guid id, CancellationToken token);
        Task<Usuario> ToggleAsync(Guid id, CancellationToken token);
        Task DeleteUserAsync(Guid id, CancellationToken token);
    }
}