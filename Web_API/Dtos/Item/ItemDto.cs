using Web_API.Models;

namespace Web_API.Dtos.Item;

public class ItemDto
{
    public int ShopId { get; set; }
    public int ItemCategory { get; set; }
    public string ShopName { get; set; } 
    public string ItemName { get; set; }
    public string ItemDescription { get; set; } 
    public string Image { get; set; } 
    public string Extras { get; set; } 
    public string DeliveryDetails { get; set; }

    public static implicit operator ItemDto(List<ItemModel> v)
    {
        throw new NotImplementedException();
    }
}