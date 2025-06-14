namespace Dsw2025Ejercicio14.Api.Domain;

public interface IPersistencia
{
    public List<Product>? GetProducts();
    public Product? GetProductBySku(string sku);
    //public void LoadProducts();
}
