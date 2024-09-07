using Ejercicio1_5.Data.Utils;
using Ejercicio1_5.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.PortableExecutable;

namespace Ejercicio1_5.Data
{
    public class ArticuloRepositoryADO : IArticuloRepository
    {
        private SqlConnection _connection;

        public ArticuloRepositoryADO()
        {
            _connection = new SqlConnection("Data Source=DESKTOP-DDU6RHT\\SQLEXPRESS;Initial Catalog=Ejercicio1_5;Integrated Security=True");
        }


        public bool Delete(int id)
        {
            var parameters = new List<ParameterSQL>();
            parameters.Add(new ParameterSQL("@codigo", id));
            int rows = DataHelper.GetInstance().ExecuteSPDML("SP_REGISTRAR_BAJA_ARTICULO", parameters);
            return rows == 1;
        }

        public List<Articulos> GetAll()
        {
            List<Articulos> lst = new List<Articulos>();
            var helper = DataHelper.GetInstance();
            var t = helper.ExecuteSPQuery("SP_RECUPERAR_ARTICULOS", null);
            foreach (DataRow row in t.Rows)
            {
                int id = Convert.ToInt32(row["id_articulo"]);
                string nombre = row["nombre"].ToString();
                decimal precioUnitario = Convert.ToDecimal(row["precioUnitario"]);

                Articulos oArticulo = new Articulos()
                {
                    Codigo = id,
                    Nombre = nombre,
                    Price = precioUnitario,
     
                };
                lst.Add(oArticulo);
            }
            return lst;
        }

        public Articulos GetById(int id)
        {
            var parameters = new List<ParameterSQL>();
            parameters.Add(new ParameterSQL("@codigo", id));
            DataTable t = DataHelper.GetInstance().ExecuteSPQuery("SP_RECUPERAR_ARTICULO_POR_CODIGO", parameters);
            
            if(t != null && t.Rows.Count == 1)
            {
                DataRow row = t.Rows[0];
                int codigo = Convert.ToInt32(row["codigo"]);
                string nombre = row["nombre"].ToString();
                decimal precioUnitario = Convert.ToDecimal(row["precioUnitario"]);
       

                Articulos oArticulo = new Articulos()
                {
                    Codigo = codigo,
                    Nombre = nombre,
                    Price = precioUnitario,
               
                };
                return oArticulo;

            }
            return null;
        }

        public bool Save(Articulos oArticulo)
        {
            bool result = true;
            string query = "SP_GUARDAR_ARTICULO";

            try
            {
                if (oArticulo != null)
                {
                    _connection.Open();
                    var cmd = new SqlCommand(query, _connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@codigo", oArticulo.Codigo);
                    cmd.Parameters.AddWithValue("@nombre", oArticulo.Nombre);
                    cmd.Parameters.AddWithValue("@precioUnitario", oArticulo.Price);
                    result = cmd.ExecuteNonQuery() == 1; //ExecuteNonQuery: cantidad de filas afectadas!
                }
            }
            catch (SqlException sqlEx)
            {
                result = false;
            }
            finally
            {
                if (_connection != null && _connection.State == System.Data.ConnectionState.Open)
                {
                    _connection.Close();
                }
            }
            return result;
        }
    }
}
