using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.DiscountDto;
using SignalR.DtoLayer.ProductDto;
using SignalR.EntityLayer.Entities;

namespace SignalRAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductContoller : ControllerBase
{
    private readonly IProductService _productService;
    private readonly IMapper _mapper;

    public ProductContoller(IProductService productService, IMapper mapper)
    {
        _productService = productService;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetProductList()
    {
        var values = _mapper.Map<List<ResultProductDto>>(_productService.TGetListAll());
        return Ok(values);
    }

    [HttpGet("GetProduct")]
    public IActionResult GetProduct(int id)
    {
        var value = _productService.TGetById(id);
        return Ok(value);
    }

    [HttpPost]
    public IActionResult CreateProduct(CreateProductDto createProductDto)
    {
        _productService.TAdd(new Product()
        {
            Description = createProductDto.Description,
            ProductName = createProductDto.ProductName,
            ProductStatus = createProductDto.ProductStatus,
            ImageURL = createProductDto.ImageURL
        });
        return Ok("Product created succesfully");
    }

    [HttpPut]
    public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
    {
        _productService.TUpdate(new Product()
        {
            ProductID = updateProductDto.ProductID,
            ProductName = updateProductDto.ProductName,
            ProductStatus = updateProductDto.ProductStatus,
            Description = updateProductDto.Description,
            ImageURL = updateProductDto.ImageURL
        });
        return Ok("Product updated succesfully");
    }

    [HttpDelete]
    public IActionResult DeleteProduct(int id)
    {
        var value = _productService.TGetById(id);
        _productService.TDelete(value);
        return Ok("Product deleted succesfully");
    }
    
}