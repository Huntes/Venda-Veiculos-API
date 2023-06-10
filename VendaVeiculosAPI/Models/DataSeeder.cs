using VendaVeiculosAPI.Enum;
using VendaVeiculosAPI.Repositories;

namespace VendaVeiculosAPI.Models
{
    public static class DataSeeder
    {
        public static void SeedAdmin(Context context)
        {
            var adminUser = new Usuario
            {
                Id = Guid.NewGuid(),
                Nome = "Admin",
                Ativo = true,
                Senha = Utils.Utils.EncryptPassword("1"),
                Email = "admin@email.com",
                TipoUser = (int)Roles.ADMIN
            };

            if (!context.Usuarios.Any(x => x.Nome == adminUser.Nome))
            {
                context.Usuarios.Add(adminUser);
            }

            context.SaveChangesAsync();
        }
    }
}
