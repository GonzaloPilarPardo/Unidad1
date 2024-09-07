using Ejercicio1_5.Data;
using Ejercicio1_5.Domain;

namespace Ejercicio1_5.Services
{
    public class ProductManager
    {
        private IArticuloRepository _repositorio;

        public ProductManager()
        {
            _repositorio = new ArticuloRepositoryADO();
        }

        public List<Articulos> GetProducts()
        {
            return _repositorio.GetAll();
        }

        public Articulos GetProductByCodigo(int cod)
        {
            return _repositorio.GetById(cod);
        }

        public bool SaveProduct(Articulos oProduct)
        {
            return _repositorio.Save(oProduct);
        }
        public bool DeleteProduct(int cod)
        {
            return _repositorio.Delete(cod);
        }
    }
}
