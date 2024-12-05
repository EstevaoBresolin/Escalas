using Microsoft.EntityFrameworkCore;

namespace Escalas.Components.Services
{
    public class VoluntarioService
    {
        private readonly AppDbContext _context;

        public VoluntarioService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Voluntario>> CarregarVoluntariosAsync()
        {
            return await _context.Voluntarios.ToListAsync();
        }

        public async Task SalvarVoluntarioAsync(Voluntario voluntario)
        {
            _context.Voluntarios.Add(voluntario);
            await _context.SaveChangesAsync();
        }

        public async Task EditarVoluntarioAsync(Voluntario voluntario)
        {
            var voluntarioExistente = await _context.Voluntarios
                .FirstOrDefaultAsync(v => v.Id == voluntario.Id);

            if (voluntarioExistente != null)
            {
                voluntarioExistente.Nome = voluntario.Nome;
                voluntarioExistente.Contato = voluntario.Contato;
                voluntarioExistente.Funcao = voluntario.Funcao;

                await _context.SaveChangesAsync();
            }
        }

        public async Task ExcluirVoluntarioAsync(int id)
        {
            var voluntario = await _context.Voluntarios.FindAsync(id);
            if (voluntario != null)
            {
                _context.Voluntarios.Remove(voluntario);
                await _context.SaveChangesAsync();
            }
        }
    }

}
