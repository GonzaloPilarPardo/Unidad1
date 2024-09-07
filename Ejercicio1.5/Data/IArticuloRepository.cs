using Ejercicio1_5.Domain;

namespace Ejercicio1_5.Data
{
    public interface IArticuloRepository
    {
        List<Articulos> GetAll();
        Articulos GetById(int id);
        bool Save(Articulos oProduct);
        bool Delete(int id);
    }
}
