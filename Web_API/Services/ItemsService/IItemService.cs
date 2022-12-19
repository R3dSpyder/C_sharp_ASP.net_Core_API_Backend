using Web_API.Dtos.Item;
using Web_API.Models;

namespace NET_Website.Services.ItemsService;

public interface IItemService
{
    public Task<ServerResponse<List<ItemDto>>> PostItem(ItemDto itemTdo, int shopId);
  
    public Task<ServerResponse<List<ItemDto>>> GetItemsByInteger(string type, int id);

    public Task<ServerResponse<List<ItemDto>>> GetItemsByString(string type, string name);

}