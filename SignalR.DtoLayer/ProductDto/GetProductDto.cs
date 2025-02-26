namespace SignalR.DtoLayer.ProductDto;

public class GetProductDto
{
    public int ProductID { get; set; }
    
    public string ProductName { get; set; }
    
    public string Description { get; set; }
    
    public string ImageURL { get; set; }
    
    public bool ProductStatus { get; set; }
}