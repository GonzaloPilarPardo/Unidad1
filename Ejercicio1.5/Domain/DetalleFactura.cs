using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1_5.Domain
{
    public class DetalleFactura
    {
        public Articulos Articulo { get; set; }
        public int Cantidad { get; set; }
        public double SubTotal()
        {
            return (double)(Cantidad * Articulo.Price);
        }


    }
}
