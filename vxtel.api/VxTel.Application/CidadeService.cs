using System.Collections.Generic;
using System.Threading.Tasks;
using VxTel.Application.Interfaces;
using VxTel.Domain.Interfaces.Entities;
using VxTel.Entities.Entities;

namespace VxTel.Application
{
    public class CidadeService : ICidadeService
    {
        ICidade _cidade;
        public CidadeService(ICidade cidade)
        {
            _cidade = cidade;
        }
        public async Task Add(Cidade Objeto)
        {
            await _cidade.Add(Objeto);
        }

        public async Task Delete(int id)
        {
            await _cidade.Delete(id);
        }

        public async Task<Cidade> GetEntityById(int Id)
        {
            return await _cidade.GetEntityById(Id);
        }

        public async Task<List<Cidade>> List()
        {
            return await _cidade.List();
        }

        public async Task Update(Cidade Objeto)
        {
            await _cidade.Update(Objeto);
        }
    }
}
