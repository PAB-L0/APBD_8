namespace Labs_8.RequestModels;

public class CreateProductRequestModel
{
    public string ProductName { get; set; } = null!;
    public decimal ProductWeight { get; set; }
    public decimal ProductWidth { get; set; }
    public decimal ProductHeight { get; set; }
    public decimal ProductDepth { get; set; }
    public IEnumerable<int>? ProductCategories { get; set; }
}