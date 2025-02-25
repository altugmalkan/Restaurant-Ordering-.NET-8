namespace SignalR.DtoLayer.DiscountDto;

public class CreateDiscountDto
{
    public string Title { get; set; }
    
    public int Amount { get; set; }
    
    public string Description { get; set; }
    
    public string ImageURL { get; set; }
}