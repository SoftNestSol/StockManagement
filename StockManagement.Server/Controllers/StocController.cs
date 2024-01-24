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

public class StockController : ControllerBase
{
    private readonly IStockRepository _stockRepository;

    private readonly IProductInStockRepository _produsInStocRepository;
    private readonly StockContext _stockContext;
    private readonly IMapper _autoMapper;
    public StockController(IStockRepository stockRepository, StockContext stockContext, IMapper autoMapper, IProductInStockRepository produsInStocRepository)
    {
        _stockContext = stockContext;
        _stockRepository = stockRepository;
        _autoMapper = autoMapper;
        _produsInStocRepository = produsInStocRepository;

    }

    [HttpGet]
    public async Task<List<StockDTO>> GetStocks() 
    {
        var stocks = await _stockRepository.GetStocksAsync();
        var stocksDTO= _autoMapper.Map<List<StockDTO>>(stocks);
        return stocksDTO;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<StockDTO>> GetStock(int id)
    {
        var stock = await _stockRepository.GetStockAsync(id);
        if (stock == null)
        {
            return NotFound();
        }

        var products = await _produsInStocRepository.GetProductsInStockAsync(id);
        var stockDTO = _autoMapper.Map<StockDTO>(stock);
        stockDTO.ProductInStock = _autoMapper.Map<List<ProductInStockDTO>>(products);

        return stockDTO;
    }


    [HttpPost]
public async Task<ActionResult<StockDTO>> AddStock([FromBody]StockDTO stock)
{
    
    var stockEntity = _autoMapper.Map<Stock>(stock);
    var createdStock = await _stockRepository.AddStockAsync(stockEntity);
    var createdStockDTO = _autoMapper.Map<StockDTO>(createdStock);
    await _stockContext.SaveChangesAsync();
    return Ok(createdStockDTO);
}

[HttpPut("{id}")]
public async Task<ActionResult<StockDTO>> UpdateStock(int id, [FromBody]StockDTO stock)
{
    var stockEntity = _autoMapper.Map<Stock>(stock);
    var updatedStock = await _stockRepository.UpdateStockAsync(id, stockEntity);
    var updatedStockDTO = _autoMapper.Map<StockDTO>(updatedStock);
    return Ok(updatedStockDTO);

}

[HttpDelete("{id}")]
public async Task<ActionResult> DeleteStock(int id)
{
    await _stockRepository.DeleteStockAsync(id);
    return Ok();
}



}