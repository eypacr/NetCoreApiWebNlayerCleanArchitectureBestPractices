using App.Services.Products;
using App.Services.Products.Create;
using App.Services.Products.Update;
using App.Services.Products.UpdateStock;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers;
public class ProductsController(IProductService productService) : CustomBaseController
{
    [HttpGet]
    public async Task<IActionResult> GetAll() => CreateActionResult(await productService.GetAllListAsync());

    [HttpGet("{id:int}")]//https://localhost:5000/api/products?id=2
    public async Task<IActionResult> GetById(int id) => CreateActionResult(await productService.GetByIdAsync(id));

    [HttpGet("{pageNumber:int}/{pageSize:int}")]
    public async Task<IActionResult> GetPagedAll(int pageNumber, int pageSize) =>
           CreateActionResult(await productService.GetPagedAllListAsync(pageNumber, pageSize));

    [HttpPost]
    public async Task<IActionResult> Create(CreateProductRequest request)
    {
        return CreateActionResult(await productService.CreateAsync(request));
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateProductRequest request) =>
            CreateActionResult(await productService.UpdateAsync(id, request));


    //[HttpPut("UpdateStock")]
    //public async Task<IActionResult> UpdateStock(UpdateProductStockRequest request) =>
    //    CreateActionResult(await productService.UpdateStockAsync(request));


    [HttpPatch("Stock")]
    public async Task<IActionResult> UpdateStock(UpdateProductStockRequest request) =>
        CreateActionResult(await productService.UpdateStockAsync(request));


    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id) => CreateActionResult(await productService.DeleteAsync(id));
}
