using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using NET_Website.Services.ItemsService;
using Web_API.Controllers;
using Web_API.Data;
using Web_API.Dtos.Item;
using Web_API.Models;
using Web_API.Repositories;

namespace Web_API.Services.ItemsService;

public class ItemService : IItemService
{
    private readonly IMapper _mapper;
    private readonly DataContext _context;
    private ItemRepository _repo;
  

    public ItemService(IMapper mapper, DataContext context)
    {
        _mapper = mapper;
        _context = context;
        _repo = new ItemRepository(_context);


    }

    public async Task<ServerResponse<List<ItemDto>>> GetItemsByInteger(string type, int id)
    {
        
        try
        {
            List<ItemDto> result;

            switch (type.ToLower())
            {
                case "itemid":
                    var idData = await ItemRepository.Find.ItemId(id);
                    result = idData.Select(c => _mapper.Map<ItemDto>(c)).ToList();
                    break;
                case "shopid":
                    var shopData = await ItemRepository.Find.ShopId(id);
                    result = shopData.Select(c => _mapper.Map<ItemDto>(c)).ToList();
                    break;
                case "itemcategory": 
                    var idCategory = await ItemRepository.Find.ItemCategory(id);
                    result = idCategory.Select(c => _mapper.Map<ItemDto>(c)).ToList();
                    break;
                default:
                    result = new List<ItemDto>();
                    break;
            }

                var serverResponse = new ServerResponse<List<ItemDto>>
                {
                    Success = true,
                    Message = (result.Count > 0) ? "Operation Successful": $"Could not match an id of {id} in type {type}",
                    Data =(result.Count >0)? result: null

                };
                return serverResponse;


        }catch(Exception e)
        {
            var serverResponse = new ServerResponse<List<ItemDto>>
            {
                Success = false,
                Message = $"An unknown error has occured. Error message: {e.Message}",
                Data = null
            };

            return serverResponse;
        }
    }

    

    //groups for strings are: shopName, itemName.
    public async Task<ServerResponse<List<ItemDto>>> GetItemsByString(string type, string name)
    {
        try
        {
            List<ItemDto> result;

            switch (type.ToLower())
            {
                case "shopname":
                    var shopData = await ItemRepository.Find.ShopName(name);
                    result = shopData.Select(c => _mapper.Map<ItemDto>(c)).ToList();
                    break;
                case "itemname":
                    var itemData = await ItemRepository.Find.ItemName(name);
                    result = itemData.Select(c => _mapper.Map<ItemDto>(c)).ToList();
                    break;
                default:
                    result = new List<ItemDto>();
                    break;
            }

            var serverResponse = new ServerResponse<List<ItemDto>>
            {
                Success = true,
                Message = (result.Count > 0) ? "Operation Successful" : $"Could not match a name of {name} in type{type}",
                Data = (result.Count > 0) ? result : null

            };
            return serverResponse;


        }
        catch (Exception e)
        {
            var serverResponse = new ServerResponse<List<ItemDto>>
            {
                Success = false,
                Message = $"An unknown error has occured. Error message: {e.Message}",
                Data = null
            };

            return serverResponse;
        }

    }

    public async Task<ServerResponse<List<ItemDto>>> PostItem(ItemDto itemTdo,int shopId)
    {
        try
        {
            
            var item= _mapper.Map<ItemModel>(itemTdo);
            item.ShopId = shopId;
            item.Guid = new Guid();

            var data = await ItemRepository.Add.AddModel(item);
           
           

            var serverResponse = new ServerResponse<List<ItemDto>>
            {
                Success = true,
                Message ="Successfully added to the database",
                Data = data.Select(c => _mapper.Map<ItemDto>(c)).ToList()

            };

            return serverResponse;
        }
        catch(Exception e)
        {
            var serverResponse = new ServerResponse<List<ItemDto>>
            {
                Success = false,
                Message = $"failed to add item to the database.Exception message: {e}"
            };

            return serverResponse;
        }

    }

}