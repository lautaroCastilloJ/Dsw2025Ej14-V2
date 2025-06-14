using Dsw2025Ejercicio14.Api.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Dsw2025Ejercicio14.Api.Controllers;

[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IPersistencia? _persistencia;
    public ProductsController(IPersistencia persistencia) // ctor + TAB o ENTER construye un constructor vacío automaticamente
    {
        _persistencia = persistencia;
    }

    [HttpGet("api/products")]
    public IActionResult GetActiveProducts()
    {
        var products = _persistencia?.GetProducts(); // GetProducts es el metodo para obtener todos los productos activos del JSON
        if(products is null || products.Count==0) 
            return NoContent(); // products.Any() es true si hay al menos un elemento; false si está vacía. Se le pone el ! porque if interpreta que es true
        
        return Ok(products);
    }

    [HttpGet("api/products/{sku}")]
    public IActionResult GetProductBySku(string sku)
    {
        var product = _persistencia?.GetProductBySku(sku);
        if(product is null) return NotFound();
        return Ok(product);
    }

}
