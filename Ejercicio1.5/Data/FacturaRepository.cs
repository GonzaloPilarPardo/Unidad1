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
    public class FacturaRepository : IFacturaRepository
    {
        public List<Factura> GetAll()
        {
            throw new NotImplementedException();
        }

        public Factura GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save(Factura factura)
        {
            bool result = true;

            SqlConnection cnn = null;
            SqlTransaction t = null;

            try
            {
                cnn = DataHelper.GetInstance().GetConnection();
                cnn.Open();
                t = cnn.BeginTransaction();

           
                var cmd = new SqlCommand("SP_INSERTAR_MAESTRO", cnn, t);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cliente", factura.Client);
                //cmd.Parameters.AddWithValue("@vigencia", factura.Expiration);

                SqlParameter param = new SqlParameter("@id", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();

                int budgetId = (int)param.Value;
                int detailId = 1;

                foreach (var detail in factura.Details)
                {
                    
                    var cmdDetail = new SqlCommand("SP_INSERTAR_DETALLES", cnn, t);
                    cmdDetail.CommandType = CommandType.StoredProcedure;
                    cmdDetail.Parameters.AddWithValue("@detalle", detailId);
                    cmdDetail.Parameters.AddWithValue("@presupuesto", budgetId);
                    cmdDetail.Parameters.AddWithValue("@producto", detail.Articulo.Codigo);
                    cmdDetail.Parameters.AddWithValue("@cantidad", detail.Cantidad);
                   // cmdDetail.Parameters.AddWithValue("@precio", detail.Price);

                    cmdDetail.ExecuteNonQuery(); 
                }

                t.Commit();
            }
            catch (SqlException)
            {
                if (t != null)
                    t.Rollback();

                result = false;
            }
            finally
            {
                if (cnn != null && cnn.State == System.Data.ConnectionState.Open)
                {
                    cnn.Close();
                }
            }

            return result;
        }





    }
}

