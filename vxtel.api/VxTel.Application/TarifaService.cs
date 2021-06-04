using System.Collections.Generic;
using System.Threading.Tasks;
using VxTel.Application.Interfaces;
using VxTel.Domain.Interfaces.Entities;
using VxTel.Entities.Entities;

namespace VxTel.Application
{
    public class TarifaService : ITarifaService
    {
        ITarifa _tarifa;

        public TarifaService(ITarifa tarifa)
        {
            _tarifa = tarifa;
        }
        public async Task Add(Tarifa Objeto)
        {
            await _tarifa.Add(Objeto);
        }

        public async Task Delete(int id)
        {
            await _tarifa.Delete(id);
        }

        public async Task<Tarifa> GetEntityById(int Id)
        {
            return await _tarifa.GetEntityById(Id);
        }

        public async Task<List<Tarifa>> List()
        {
            return await _tarifa.List();
        }

        public async Task Update(Tarifa Objeto)
        {
            await _tarifa.Update(Objeto);
        }
    }
}
