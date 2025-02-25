using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Concrete;

public class CarouselManager : ICarouselService
{
    private readonly ICarouselDal _carouselDal;

    public CarouselManager(ICarouselDal carouselDal)
    {
        _carouselDal = carouselDal;
    }

    public void TAdd(Carousel entity)
    {
        _carouselDal.Add(entity);
    }

    public void TDelete(Carousel entity)
    {
        _carouselDal.Delete(entity);
    }

    public void TUpdate(Carousel entity)
    {
        _carouselDal.Update(entity);
    }

    public List<Carousel> TGetListAll()
    {
        return _carouselDal.GetListAll();
    }

    public Carousel TGetById(int id)
    {
        return _carouselDal.GetById(id);
    }
}