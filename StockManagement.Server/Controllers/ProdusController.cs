using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockManagement.Server.ContextModels;
using StockManagement.Server.DTOs;
using StockManagement.Server.Entities;
using StockManagement.Server.Repositories;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;


[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductRepository _productRepository;
    private readonly StockContext _stockContext;
    private readonly IMapper _autoMapper;
    private readonly IProductInStockRepository _productInStockRepository;

    public ProductController(IProductRepository productRepository,IProductInStockRepository productInStockRepository, StockContext stockContext, IMapper autoMapper)
    {
        _stockContext = stockContext;
        _productRepository = productRepository;
        _autoMapper = autoMapper;
        _productInStockRepository = productInStockRepository;
    }

    [Authorize(Roles = "Admin, AngajatTier3, AngajatTier2, AngajatTier1")]
    [HttpGet]
    public async Task<List<ProductDTO>> GetProducts() 
    {
        var products = await _productRepository.GetProductsAsync();
        var productsDTO= _autoMapper.Map<List<ProductDTO>>(products);
        return productsDTO;
    }

    [Authorize(Roles = "Admin, AngajatTier3, AngajatTier2")]
    [HttpPost("add")]    
    public async Task<ActionResult<ProductDTO>> AddProduct([FromBody]ProductDTO product)
{
    Console.WriteLine(product.Name);
    var productEntity = _autoMapper.Map<Product>(product);
    var createdProduct = await _productRepository.AddProductAsync(productEntity);
    
    var createdProductDTO = _autoMapper.Map<ProductDTO>(createdProduct);
    await _stockContext.SaveChangesAsync();

    return Ok(createdProductDTO);
}

    [Authorize(Roles = "Admin, AngajatTier3, AngajatTier2")]
    [HttpPost("addToStock")]
    public async Task<ActionResult<ProductInStockDTO>> AddProductToStock([FromBody] ProductInStockDTO inStock)
    {
        var productInStockEntity = _autoMapper.Map<ProductInStock>(inStock);
        var createdEntry = await _productInStockRepository.AddProductInStockAsync(productInStockEntity);
        var createdEntryDTO = _autoMapper.Map<ProductInStockDTO>(createdEntry);
        await _stockContext.SaveChangesAsync(); 
        return Ok(createdEntryDTO);

    }

    [Authorize(Roles = "Admin, AngajatTier3, AngajatTier2")]
    [HttpPut("{id}")]
public async Task<ActionResult<ProductDTO>> UpdateProduct(int id, [FromBody]ProductDTO product)
{
    var productEntity = _autoMapper.Map<Product>(product);
    var updatedProduct = await _productRepository.UpdateProductAsync(id, productEntity);
    var updatedProductDTO = _autoMapper.Map<ProductDTO>(updatedProduct);
    return Ok(updatedProductDTO);

}

[Authorize(Roles = "Admin, AngajatTier3")]
[HttpDelete("{id}")]
public async Task<ActionResult> DeleteProduct(int id)
{
    await _productRepository.DeleteProductAsync(id);
    return Ok();

}

    [Authorize(Roles = "Admin, AngajatTier3, AngajatTier2, AngajatTier1")]
    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDTO>> GetProduct(int id)
    {
        var product = await _productRepository.GetProductAsync(id);
        var productDTO = _autoMapper.Map<ProductDTO>(product);
        return Ok(productDTO);
    }

    


}