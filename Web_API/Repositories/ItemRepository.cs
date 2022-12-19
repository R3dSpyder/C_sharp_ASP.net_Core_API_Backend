using Microsoft.EntityFrameworkCore;
using Web_API.Data;
using Web_API.Models;

namespace Web_API.Repositories;

public class ItemRepository
{
    public static DataContext _context;

    public ItemRepository(DataContext dataContext)
    {
        _context = dataContext;
    }

    public static class Add
    {

        public static async Task<List<ItemModel>> AddModel(ItemModel model)
        { 
            var guid = model.Guid;
            _context.ItemModels.Add(model);
            await _context.SaveChangesAsync();
            return await _context.ItemModels.Where(c => c.Guid == guid).ToListAsync();
        }
    }

    public static class Find
    {
        public static async Task<List<ItemModel>> ShopId(int id)
        {
            return await _context.ItemModels.Where(c => c.ShopId == id).ToListAsync();
        }

        public static async Task<List<ItemModel>> Guid(Guid id)
        {
            return await _context.ItemModels.Where(c => c.Guid == id).ToListAsync();
        }

        public static async Task<List<ItemModel>> ItemId(int id)
        {
            return await _context.ItemModels.Where(c => c.ItemId == id).ToListAsync();
        }

        public static async Task<List<ItemModel>> ItemCategory(int id)
        {
            return await _context.ItemModels.Where(c => c.ItemCategory == id).ToListAsync();
        }

        public static async Task<List<ItemModel>> ShopName(string name)
        {
            return await _context.ItemModels.Where(c => c.ShopName == name).ToListAsync();
        }

        public static async Task<List<ItemModel>> ItemName(string name)
        {
            return await _context.ItemModels.Where(c => c.ItemName == name).ToListAsync();
        }

    }


 
}