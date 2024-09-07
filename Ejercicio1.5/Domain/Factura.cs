using Ejercicio1_5.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1_5.Domain
{
    public class Factura
    {
        public int Id { get; set; }
        public string Client { get; set; }
        public DateTime Date { get; set; }
        public FormaPago FormaPago { get; set; }

        public List<DetalleFactura> Details { get; set; }

        public Factura()
        {
                Details = new List<DetalleFactura>();
        }
        public void AddDetail(DetalleFactura detail)
        {
            Details.Add(detail);
        }
        public void RemoveDetail(int index)
        {
            Details.RemoveAt(index);
        }
        public double Total()
        {
            double total = 0;
            foreach (DetalleFactura detail in Details)
            {
                total += detail.SubTotal();
            }
            return total;
        }
    }
}
