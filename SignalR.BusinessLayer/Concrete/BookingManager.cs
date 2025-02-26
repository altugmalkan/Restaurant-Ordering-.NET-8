using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Concrete;

public class BookingManager : IBookingService
{
    private readonly IBookingDal _bookingDal;
    
    public BookingManager(IBookingDal bookingDal)
    {
        _bookingDal = bookingDal;
    }

    public void TAdd(Booking entity)
    {
        _bookingDal.Add(entity);
    }

    public List<Booking> TGetListAll()
    {
        return _bookingDal.GetListAll();
    }

    public Booking TGetById(int id)
    {
        return _bookingDal.GetById(id);
    }

    public void TUpdate(Booking entity)
    {
        _bookingDal.Update(entity);
    }

    public void TDelete(Booking entity)
    {
        _bookingDal.Delete(entity);
    }
}