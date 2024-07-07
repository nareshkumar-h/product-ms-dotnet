
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ProductApi.Models;
using System.Collections.Generic;

namespace ProductApi.Controllers;

[ApiController]
[Route("apii/products")]
[Produces("application/json")]
public class ProductController : ControllerBase
{
    private static readonly List<Product> products = new List<Product>{
    //add some products
        new Product() { id = 1, productName = "Product 1", price = 100 },
        new Product() { id = 2, productName = "Product 2", price = 200 },
        new Product() { id = 3, productName = "Product 3", price = 300 },
        new Product() { id = 4, productName = "Product 4", price = 400 }
    };


    private readonly ILogger<ProductController> _logger;

    public ProductController(ILogger<ProductController> logger)
    {
        _logger = logger;



    }

    [HttpGet(Name = "Get all Products")]
    public List<Product> Get()
    {
        return products;
    }

    [HttpGet("{id}", Name = "Get Product By Id")]
    public Product GetProductById(int id)
    {
        var product = products.Where(p => p.id == id).FirstOrDefault();
        return product;
    }

    [HttpDelete("{id}", Name = "Delete Product By Id")]
    public string DeleteProductById(int id)
    {
        var product = products.Where(p => p.id == id).FirstOrDefault();
        if (product != null)
        {
            products.Remove(product);
        }
        return "Successfully deleted product with id: " + id;

    }

    [HttpPost(Name = "Add Products")]
    public Product addProduct(Product product)
    {
        products.Add(product);
        return product;
    }

    [HttpPut("{id}", Name = "Update Product Details for a specific product")]
    public Product updateProduct(int id, Product product)
    {
        var existingProduct = products.Where(p => p.id == id).FirstOrDefault();
        if (existingProduct != null)
        {
            existingProduct.productName = product.productName;
            existingProduct.price = product.price;
        }

        return existingProduct;

    }
}
