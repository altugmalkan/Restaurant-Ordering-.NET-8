namespace SignalR.DtoLayer.ProductDto;

public class CreateProductDto
{
    public string ProductName { get; set; }
    
    public string Description { get; set; }
    
    public string ImageURL { get; set; }
    
    public bool ProductStatus { get; set; }
}