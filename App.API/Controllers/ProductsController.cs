using App.Repositories.Products;
using App.Services.Filters;
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

    [ServiceFilter(typeof(NotFoundFilter<Product, int>))]
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

    [ServiceFilter(typeof(NotFoundFilter<Product, int>))]
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateProductRequest request) =>
            CreateActionResult(await productService.UpdateAsync(id, request));


    //[HttpPut("UpdateStock")]
    //public async Task<IActionResult> UpdateStock(UpdateProductStockRequest request) =>
    //    CreateActionResult(await productService.UpdateStockAsync(request));


    [HttpPatch("Stock")]
    public async Task<IActionResult> UpdateStock(UpdateProductStockRequest request) =>
        CreateActionResult(await productService.UpdateStockAsync(request));

    [ServiceFilter(typeof(NotFoundFilter<Product, int>))]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id) => CreateActionResult(await productService.DeleteAsync(id));
}
