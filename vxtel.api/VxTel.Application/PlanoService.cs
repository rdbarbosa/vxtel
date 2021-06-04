using System.Collections.Generic;
using System.Threading.Tasks;
using VxTel.Application.Interfaces;
using VxTel.Domain.Interfaces.Entities;
using VxTel.Entities.Entities;

namespace VxTel.Application
{
    public class PlanoService : IPlanoService
    {
        IPlano _plano;

        public PlanoService(IPlano plano)
        {
            _plano = plano;
        }
        public async Task Add(Plano Objeto)
        {
            await _plano.Add(Objeto);
        }

        public async Task Delete(int id)
        {
            await _plano.Delete(id);
        }

        public async Task<Plano> GetEntityById(int Id)
        {
            return await _plano.GetEntityById(Id);
        }

        public async Task<List<Plano>> List()
        {
            return await _plano.List();
        }

        public async Task Update(Plano Objeto)
        {
            await _plano.Update(Objeto);
        }
    }
}
