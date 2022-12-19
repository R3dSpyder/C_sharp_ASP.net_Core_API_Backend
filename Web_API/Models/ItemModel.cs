using NET_Website.Services.ItemsService;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Web_API.Dtos.Item;

namespace Web_API.Models;

public class ItemModel
{
   
    [Key] 
    public int ItemId { get; set; }
    [Required]
    public Guid Guid { get; set; }
    [Required]
    public int ShopId { get; set; }

    [Required]
    public int ItemCategory { get; set; }

    [Required]
    [StringLength(50, ErrorMessage = "Please reduce shop name length")]
    [RegularExpression(@"^[^!]+$")]
    [DisplayName("Shop Name")]
    public string ShopName { get; set; }

    [Required]
    [StringLength(50, ErrorMessage = "Please reduce item name length")]
    [DisplayName("Item Name")]
    public string ItemName { get; set; }

    [Required]
    [StringLength(500, ErrorMessage = "Please reduce the description length")]
    [DisplayName("Item Description")]
    public string ItemDescription { get; set; }

    [Required]
    [StringLength(100, ErrorMessage = "URL too long. Consult source")]
    public string Image { get; set; }


    [Required(AllowEmptyStrings = true)]
    [StringLength(200, ErrorMessage = "Please shorten the amount of selections available")]
    public string Extras { get; set; }

    [Required]
    [StringLength(200, ErrorMessage = "Please shorten delivery details")]
    [DisplayName("Delivery Details")]
    public string DeliveryDetails { get; set; } 

}