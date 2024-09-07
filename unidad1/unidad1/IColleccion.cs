using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unidad1
{
    public interface IColleccion
    {
        public bool estaVacia();
        public object extraer();
        public object primero();
        public object añadir(object obj);
    }
}
