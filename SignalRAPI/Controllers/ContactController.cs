using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ContactDto;
using SignalR.EntityLayer.Entities;

namespace SignalRAPI.Controllers;


[Route("api/[controller]")]
[ApiController]
public class ContactController : ControllerBase
{
    private readonly IContactService _contactService;
    private readonly IMapper _mapper;
    
    public ContactController(IContactService contactService, IMapper mapper)
    {
        _contactService = contactService;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetContactList()
    {
        var values = _mapper.Map<List<ResultContactDto>>(_contactService.TGetListAll());
        return Ok(values);
    }

    [HttpPost]
    public IActionResult CreateContact(CreateContactDto createContactDto)
    {
        _contactService.TAdd(new Contact()
        {
            Location = createContactDto.Location,
            PhoneNumber = createContactDto.PhoneNumber,
            Email = createContactDto.Email,
            FooterDescription = createContactDto.FooterDescription,
        });
        return Ok("Contact created successfully");
    }

    [HttpPut]
    public IActionResult UpdateContact(UpdateContactDto updateContactDto)
    {
        _contactService.TUpdate(new Contact()
        {
            ContactID = updateContactDto.ContactID,
            Location = updateContactDto.Location,
            PhoneNumber = updateContactDto.PhoneNumber,
            Email = updateContactDto.Email,
            FooterDescription = updateContactDto.FooterDescription,
        });
        return Ok("Contact updated successfully");
    }

    [HttpDelete]
    public IActionResult DeleteContact(int id)
    {
        var value = _contactService.TGetById(id);
        _contactService.TDelete(value);
        return Ok("Contact deleted successfully");
    }

    [HttpGet("GetContact")]
    public IActionResult GetContact(int id)
    {
        var value = _contactService.TGetById(id);
        return Ok(value);
    }
}