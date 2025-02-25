using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.DiscountDto;
using SignalR.EntityLayer.Entities;

namespace SignalRAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DiscountController : ControllerBase
{
    private readonly IDiscountService _discountService;
    private readonly IMapper _mapper;

    public DiscountController(IDiscountService discountService, IMapper mapper)
    {
        _discountService = discountService;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetDiscountList()
    {
        var values = _mapper.Map<List<ResultDiscountDto>>(_discountService.TGetListAll());
        return Ok(values);
    }

    [HttpGet("GetDiscount")]
    public IActionResult GetDiscount(int id)
    {
        var value = _discountService.TGetById(id);
        return Ok(value);
    }

    [HttpPost]
    public IActionResult CreateDiscount(CreateDiscountDto createDiscountDto)
    {
        _discountService.TAdd(new Discount()
        {
            Description = createDiscountDto.Description,
            Amount = createDiscountDto.Amount,
            Title = createDiscountDto.Title,
            ImageURL = createDiscountDto.ImageURL
        });
        return Ok("Discount created succesfully");
    }

    [HttpPut]
    public IActionResult UpdateDiscount(UpdateDiscountDto updateDiscountDto)
    {
        _discountService.TUpdate(new Discount()
        {
            DiscountID = updateDiscountDto.DiscountID,
            Description = updateDiscountDto.Description,
            Amount = updateDiscountDto.Amount,
            Title = updateDiscountDto.Title,
            ImageURL = updateDiscountDto.ImageURL
        });
        return Ok("Discount updated succesfully");
    }

    [HttpDelete]
    public IActionResult DeleteDiscount(int id)
    {
        var value = _discountService.TGetById(id);
        _discountService.TDelete(value);
        return Ok("Discount deleted succesfully");
    }
    
}