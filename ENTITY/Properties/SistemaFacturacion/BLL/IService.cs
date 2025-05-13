// BLL/IService.cs
using System.Collections.Generic;

namespace BLL
{
    public interface IService<T>
    {
        string Guardar(T entity);
        string Modificar(T entity);
        List<T> Consultar();
    }
}