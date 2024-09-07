
using Ejercicio1_5.Data;
using Ejercicio1_5.Domain;
using Ejercicio1_5.Services;

ProductManager manager = new ProductManager();

//Create new product:
var oProduct = new Articulos()
{
    Nombre = "PRODUCTO DE PRUEBA",
    //Stock = 2000,
    //Activo = true
};
if (manager.SaveProduct(oProduct))
    Console.WriteLine("PRODUCTO CREADO EXISTOSAMENTE!");

//List all product of store:
List<Articulos> lst = manager.GetProducts();
if(lst.Count == 0)
{
    Console.WriteLine("Sin productos en la base de datos");

}
else
{
    foreach(var oProducto in lst)
    {
        Console.WriteLine(oProducto);
    }
}

//Delete product cod = 1:
if (manager.DeleteProduct(1))
    Console.WriteLine("PRODUCTO ACTUALIZADO CON DATOS DE BAJA!");