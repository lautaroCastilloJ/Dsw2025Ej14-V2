
using Dsw2025Ejercicio14.Api.Domain;
using System.Text.Json;

namespace Dsw2025Ejercicio14.Api.Data;

public class PersistenciaEnMemoria : IPersistencia
{
    private List<Product>? _products;

    public PersistenciaEnMemoria()
    {
        LoadProducts();
    }
    public List<Product>? GetProducts()
    {
        return _products?.Where(p => p.IsActive).ToList(); // Como me marca subrayado verde, debemos hacer nulleable _products y el tipo de retorno del metodo
    }

    public Product? GetProductBySku(string sku)
    {
        return _products?.FirstOrDefault(p => p.Sku == sku); // == compara en cambio = asigna
    }
    private void LoadProducts()
    {
        var json = File.ReadAllText("Data\\products.json");
        _products = JsonSerializer.Deserialize<List<Product>>(json, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });
    }
}
