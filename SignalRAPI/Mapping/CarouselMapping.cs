using AutoMapper;
using SignalR.DtoLayer.CarouselDto;
using SignalR.EntityLayer.Entities;

namespace SignalRAPI.Mapping;

public class CarouselMapping: Profile
{
    public CarouselMapping()
    {
        CreateMap<Carousel, GetCarouselDto>().ReverseMap();
        CreateMap<Carousel, ResultCarouselDto>().ReverseMap();
        CreateMap<Carousel, UpdateCarouselDto>().ReverseMap();
        CreateMap<Carousel, CreateCarouselDto>().ReverseMap();
    }
}