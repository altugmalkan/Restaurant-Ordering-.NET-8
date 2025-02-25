using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.EntityFramework;

public class EfCarouselDal: GenericRepository<Carousel>, ICarouselDal
{
    public EfCarouselDal(SignalRContext context) : base(context){}
}
