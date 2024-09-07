using Ejercicio1_5.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1_5.Data
{
    public class FormaPagoRepository : IPagos
    {
        private SqlConnection _connection;

        public FormaPagoRepository()
        {
            _connection = new SqlConnection("Data Source=DESKTOP-DDU6RHT\\SQLEXPRESS;Initial Catalog=Ejercicio1_5;Integrated Security=True");
        }

        public List<FormaPago> GetAll()
        {
            List<FormaPago> lMethods = new List<FormaPago>();

            var t = DataHelper.GetInstance().ExecuteSPQuery("SP_OBTENER_FORMAPAGO");
            foreach (DataRow row in t.Rows)
            {
                FormaPago oPayment = new FormaPago();
                oPayment.Codigo = Convert.ToInt32(row["id_forma_pago"]);
                oPayment.Nombre = row["nombre"].ToString();


                lMethods.Add(oPayment);
            }
            return lMethods;

        }
    }
}
