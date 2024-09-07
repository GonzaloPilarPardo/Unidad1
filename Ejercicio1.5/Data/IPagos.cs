using Ejercicio1_5.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ejercicio1_5.Data.IPagos;

namespace Ejercicio1_5.Data
{
   public interface IPagos
    {
        public interface IPayment_Methods
        {
            List<FormaPago> GetAll();
        }
    }
}
