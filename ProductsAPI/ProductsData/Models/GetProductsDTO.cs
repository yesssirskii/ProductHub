namespace ProductsData.Models
{
  public class GetProductsDTO
  {
    public int ProductId { get; set; }
    public string? Name { get; set; }
    public double Price { get; set; }
    public string? Country { get; set; }
  }
}
