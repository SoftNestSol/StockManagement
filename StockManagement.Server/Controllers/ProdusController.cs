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
    public ProductController(IProductRepository productRepository, StockContext stockContext, IMapper autoMapper)
    {
        _stockContext = stockContext;
        _productRepository = productRepository;
        _autoMapper = autoMapper;
    }

    [HttpGet]
    public async Task<List<ProductDTO>> GetProducts() 
    {
        var products = await _productRepository.GetProductsAsync();
        var productsDTO= _autoMapper.Map<List<ProductDTO>>(products);
        return productsDTO;
    }


    [HttpPost]
public async Task<ActionResult<ProductDTO>> AddProduct([FromBody]ProductDTO product)
{
    
    var productEntity = _autoMapper.Map<Product>(product);
    var createdProduct = await _productRepository.AddProductAsync(productEntity);
    
    var createdProductDTO = _autoMapper.Map<ProductDTO>(createdProduct);
    return Ok(createdProductDTO);
}

[HttpPut("{id}")]
public async Task<ActionResult<ProductDTO>> UpdateProduct(int id, [FromBody]ProductDTO product)
{
    var productEntity = _autoMapper.Map<Product>(product);
    var updatedProduct = await _productRepository.UpdateProductAsync(id, productEntity);
    var updatedProductDTO = _autoMapper.Map<ProductDTO>(updatedProduct);
    return Ok(updatedProductDTO);

}

[HttpDelete("{id}")]

public async Task<ActionResult> DeleteProduct(int id)
{
    await _productRepository.DeleteProductAsync(id);
    return Ok();

}


    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDTO>> GetProduct(int id)
    {
        var product = await _productRepository.GetProductAsync(id);
        var productDTO = _autoMapper.Map<ProductDTO>(product);
        return Ok(productDTO);
    }

    


}