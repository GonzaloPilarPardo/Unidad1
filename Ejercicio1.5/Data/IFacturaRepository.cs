using Ejercicio1_5.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1_5.Data
{
    public interface IFacturaRepository
    {
        Factura GetById(int id);
        List<Factura> GetAll();
        bool Save(Factura budget);
    }
}
