using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.CarouselDto;
using SignalR.EntityLayer.Entities;

namespace SignalRAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarouselController : ControllerBase
{
    private readonly ICarouselService _carouselService;
    private readonly IMapper _mapper;
    
    public CarouselController(ICarouselService carouselService, IMapper mapper)
    {
        _carouselService = carouselService;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetCarouselList()
    {
        var values = _mapper.Map<List<ResultCarouselDto>>(_carouselService.TGetListAll());
        return Ok(values);
    }

    [HttpGet("GetCarousel")]
    public IActionResult GetCarousel(int id)
    {
        var value = _carouselService.TGetById(id);
        return Ok(value);
    }

    [HttpPost]
    public IActionResult CreateCarousel(CreateCarouselDto createCarouselDto)
    {
        _carouselService.TAdd(new Carousel()
        {
            Title1 = createCarouselDto.Title1,
            Description1 = createCarouselDto.Description1,
            Title2 = createCarouselDto.Title2,
            Description2 = createCarouselDto.Description2,
            Title3 =   createCarouselDto.Title3,
            Description3 =   createCarouselDto.Description3,
        }); 
        return Ok("Carousel created succesfully");
    }

    [HttpPut]
    public IActionResult UpdateCarousel(UpdateCarouselDto updateCarouselDto)
    {
        _carouselService.TUpdate(new Carousel()
        {
            CarouselID = updateCarouselDto.CarouselID,
            Title1 = updateCarouselDto.Title1,
            Description1 = updateCarouselDto.Description1,
            Title2 = updateCarouselDto.Title2,
            Description2 = updateCarouselDto.Description2,
            Title3 =   updateCarouselDto.Title3,
            Description3 =   updateCarouselDto.Description3,
        }); 
        return Ok("Carousel updated succesfully");
    }

    [HttpDelete]
    public IActionResult DeleteCarousel(int id)
    {
        var value = _carouselService.TGetById(id);
        _carouselService.TDelete(value);
        return Ok("Carousel deleted succesfully");
    }
        
}