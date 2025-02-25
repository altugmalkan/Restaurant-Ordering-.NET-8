using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.DiscountDto;
using SignalR.DtoLayer.ProductDto;
using SignalR.DtoLayer.SocialMediaDto;
using SignalR.DtoLayer.TestimonialDto;
using SignalR.EntityLayer.Entities;

namespace SignalRAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TestimonialController : ControllerBase
{
    private readonly ITestimonialService _testimonialService;
    private readonly IMapper _mapper;

    public TestimonialController(ITestimonialService testimonialService, IMapper mapper)
    {
        _testimonialService = testimonialService;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetTestimonialList()
    {
        var values = _mapper.Map<List<ResultTestimonialDto>>(_testimonialService.TGetListAll());
        return Ok(values);
    }

    [HttpGet("GetTestimonial")]
    public IActionResult GetTestimonial(int id)
    {
        var value = _testimonialService.TGetById(id);
        return Ok(value);
    }

    [HttpPost]
    public IActionResult CreateTestimonial(CreateTestimonialDto createTestimonialDto)
    {
        _testimonialService.TAdd(new Testimonial()
        {
            Name = createTestimonialDto.Name,
            Title = createTestimonialDto.Title,
            Comment = createTestimonialDto.Comment,
            ImageURL = createTestimonialDto.ImageURL,
            Status = createTestimonialDto.Status
        });
        return Ok("Testimonial created succesfully");
    }

    [HttpPut]
    public IActionResult UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
    {
        _testimonialService.TUpdate(new Testimonial()
        {
            TestimonialID = updateTestimonialDto.TestimonialID,
            Name = updateTestimonialDto.Name,
            Title = updateTestimonialDto.Title,
            Comment = updateTestimonialDto.Comment,
            ImageURL = updateTestimonialDto.ImageURL,
            Status = updateTestimonialDto.Status
        });
        return Ok("Testimonial updated succesfully");
    }

    [HttpDelete]
    public IActionResult DeleteTestimonial(int id)
    {
        var value = _testimonialService.TGetById(id);
        _testimonialService.TDelete(value);
        return Ok("Testimonial deleted succesfully");
    }
    
}