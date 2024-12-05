using Escalas.Components.Classes;
using Microsoft.EntityFrameworkCore;

namespace Escalas.Components.Services
{
    public class InstituicaoService
    {
        private readonly AppDbContext _context;

        public InstituicaoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Instituicao>> Carregar()
        {
            return await _context.Instituicao.ToListAsync();
        }

        public async Task Salvar(Instituicao model)
        {
            _context.Instituicao.Add(model);
            await _context.SaveChangesAsync();
        }

        public async Task Editar(Instituicao model)
        {
            var modelExistente = await _context.Instituicao
                .FirstOrDefaultAsync(v => v.Id == model.Id);

            if (modelExistente != null)
            {
                modelExistente.Nome = model.Nome;
                modelExistente.Contato = model.Contato;

                await _context.SaveChangesAsync();
            }
        }

        public async Task Excluir(int id)
        {
            var model = await _context.Instituicao.FindAsync(id);
            if (model != null)
            {
                _context.Instituicao.Remove(model);
                await _context.SaveChangesAsync();
            }
        }
    }

}
