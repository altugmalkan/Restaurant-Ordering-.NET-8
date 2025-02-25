using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.AboutDto;
using SignalR.EntityLayer.Entities;

namespace SignalRAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AboutController : ControllerBase
{
    private readonly IAboutService _aboutService;
    
    public AboutController(IAboutService aboutService)
    {
        _aboutService = aboutService;
    }
    
    //GET 
    [HttpGet]
    public IActionResult AboutList()
    {
        var values = _aboutService.TGetListAll();
        return Ok(values);
    }
    
    //POST
    [HttpPost]
    public IActionResult CreateAbout(CreateAboutDto createAboutDto)
    {
        About about = new About()
        {
            Title = createAboutDto.Title,
            Description = createAboutDto.Description,
            ImageURL = createAboutDto.ImageURL,
        };
        _aboutService.TAdd(about);
        return Ok("About section added successfully");
    }
    
    //DELETE
    [HttpDelete]
    public IActionResult DeleteAbout(int id)
    {
        var value = _aboutService.TGetById(id);
        _aboutService.TDelete(value);
        return Ok("About section deleted successfully");
    }
    
    //UPDATE
    [HttpPut]
    public IActionResult UpdateAbout(UpdateAboutDto updateAboutDto)
    {
        About about = new About()
        {
            AboutID = updateAboutDto.AboutID,
            Title = updateAboutDto.Title,
            Description = updateAboutDto.Description,
            ImageURL = updateAboutDto.ImageURL,
        };
        _aboutService.TUpdate(about);
        return Ok("About section updated successfully");
    }
    
    //GET by id
    [HttpGet("GetAbout")]
    public IActionResult GetAbout(int id)
    {
        var value = _aboutService.TGetById(id);
        return Ok(value);
    }



}