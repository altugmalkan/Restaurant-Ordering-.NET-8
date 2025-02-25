using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.BookingDto;
using SignalR.EntityLayer.Entities;

namespace SignalRAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookingController : ControllerBase
{
    private readonly IBookingService _bookingService;

    public BookingController(IBookingService bookingService)
    {
        _bookingService = bookingService;
    }
    
    //GET
    [HttpGet]
    public IActionResult BookingList()
    {
        var values = _bookingService.TGetListAll();
        return Ok(values);
    }
    
    //CREATE
    [HttpPost]
    public IActionResult CreateBooking(CreateBookingDto createBookingDto)
    {
        Booking booking = new Booking()
        {
            Name = createBookingDto.Name,
            Phone = createBookingDto.Phone,
            Email = createBookingDto.Email,
            PersonCount = createBookingDto.PersonCount,
            Date = createBookingDto.Date
        };
        
        _bookingService.TAdd(booking);
        return Ok("Booking added successfully");
    }
    
    //UPDATE 
    [HttpPut]
    public IActionResult UpdateBooking(UpdateBookingDto updateBookingDto)
    {
        Booking booking = new Booking()
        {
            BookingID = updateBookingDto.BookingID,
            Name = updateBookingDto.Name,
            Phone = updateBookingDto.Phone,
            Email = updateBookingDto.Email,
            PersonCount = updateBookingDto.PersonCount,
            Date = updateBookingDto.Date
        };
        _bookingService.TUpdate(booking);
        return Ok("Booking updated successfully");
    }
    
    //DELETE
    [HttpDelete]
    public IActionResult DeleteBooking(int id)
    {
        var booking = _bookingService.TGetById(id);
        _bookingService.TDelete(booking);
        return Ok("Booking deleted successfully");
    }
    
    //GET by id
    [HttpGet("GetBooking")]
    public IActionResult GetBooking(int id)
    {
        var value = _bookingService.TGetById(id);
        return Ok(value);
    }
    
}