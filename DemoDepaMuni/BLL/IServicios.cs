using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    interface IServicios<T>
    {
        string Createe(T entity);
        List<T> Readee();
        string Updatee(T entity);
        string Deletee(int id);
        //T BuscarId(int id);
    }
}
