using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.DiscountDto;
using SignalR.DtoLayer.ProductDto;
using SignalR.DtoLayer.SocialMediaDto;
using SignalR.EntityLayer.Entities;

namespace SignalRAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SocialMediaController : ControllerBase
{
    private readonly ISocialMediaService _socialMediaService;
    private readonly IMapper _mapper;

    public SocialMediaController(ISocialMediaService socialMediaService, IMapper mapper)
    {
        _socialMediaService = socialMediaService;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetSocialMediaList()
    {
        var values = _mapper.Map<List<ResultSocialMediaDto>>(_socialMediaService.TGetListAll());
        return Ok(values);
    }

    [HttpGet("GetSocialMedia")]
    public IActionResult GetProduct(int id)
    {
        var value = _socialMediaService.TGetById(id);
        return Ok(value);
    }

    [HttpPost]
    public IActionResult CreateSocialMedia(CreateSocialMediaDto createSocialMediaDto)
    {
        _socialMediaService.TAdd(new SocialMedia()
        {
            Title = createSocialMediaDto.Title,
            URL = createSocialMediaDto.URL,
            Icon = createSocialMediaDto.Icon,
            
        });
        return Ok("Social Media created succesfully");
    }

    [HttpPut]
    public IActionResult UpdateSocialMedia(UpdateSocialMediaDto updateSocialMediaDto)
    {
        _socialMediaService.TAdd(new SocialMedia()
        {
            SocialMediaID = updateSocialMediaDto.SocialMediaID,
            Title = updateSocialMediaDto.Title,
            URL = updateSocialMediaDto.URL,
            Icon = updateSocialMediaDto.Icon,
            
        });
        return Ok("Social Media updated succesfully");
    }

    [HttpDelete]
    public IActionResult DeleteSocialMedia(int id)
    {
        var value = _socialMediaService.TGetById(id);
        _socialMediaService.TDelete(value);
        return Ok("Social Media deleted succesfully");
    }
    
}