using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.CategoryDto;
using SignalR.EntityLayer.Entities;

namespace SignalRAPI.Controllers;


[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;
    private readonly IMapper _mapper;
    
    public CategoryController(ICategoryService categoryService, IMapper mapper)
    {
        _categoryService = categoryService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public IActionResult CategoryList()
    {
        var values = _mapper.Map<List<ResultCategoryDto>>(_categoryService.TGetListAll());
        return Ok(values);
    }

    [HttpPost]
    public IActionResult CreateCategory(CreateCategoryDto createCategoryDto)
    {
        _categoryService.TAdd(new Category()
        {
            CategoryName = createCategoryDto.CategoryName,
            Status = createCategoryDto.Status
        });
        
        return Ok("Category added successfully");
    }

    [HttpPut]
    public IActionResult UpdateCategory(UpdateCategoryDto updateCategoryDto)
    {
        _categoryService.TUpdate(new Category()
        {
            CategoryID = updateCategoryDto.CategoryID,
            CategoryName = updateCategoryDto.CategoryName,
            Status = updateCategoryDto.Status
        });
        return Ok("Category updated successfully");
    }

    [HttpDelete]
    public IActionResult DeleteCategory(int id)
    {
        var value = _categoryService.TGetById(id);
        _categoryService.TDelete(value);
        return Ok("Category deleted successfully");
    }

    [HttpGet("GetCategory")]
    public IActionResult GetCategory(int id)
    {
        var value = _categoryService.TGetById(id);
        return Ok(value);
    }
    
    
}