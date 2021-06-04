﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace VxTel.Application.Interfaces
{
    public interface IGenericService<T> where T : class
    {
        Task Add(T Objeto);
        Task Update(T Objeto);
        Task Delete(int Id);
        Task<T> GetEntityById(int Id);
        Task<List<T>> List();
    }
}
