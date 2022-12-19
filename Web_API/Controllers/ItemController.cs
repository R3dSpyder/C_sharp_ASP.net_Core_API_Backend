using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using NET_Website.Services.ItemsService;
using Web_API.Dtos.Item;
using Web_API.Models;

namespace Web_API.Controllers;

[ApiController]
[Route("api/[controller]")]

public class ItemController : ControllerBase
{
    private readonly IItemService _itemService;

    public ItemController(IItemService itemService)
    {
        _itemService = itemService;

    }

    [HttpGet("search/int")]
    public async Task<ActionResult<ItemDto>>GetItemsByInteger(string type, int id)
    {
        try
        {
            var result = await _itemService.GetItemsByInteger(type, id);
            if (result.Data == null)
            {
                return NotFound(result);
            }

            return Ok(result);
        }
        
        
        catch (Exception e)
        {
            return BadRequest($"The following unhandled exception happened: {e.Message}");
        }
    }

    
    [HttpGet("memberName")]
    public async Task<ActionResult<List<ItemDto>>> GetItemsByString([FromQuery] string type, string name)
    {

        try
        {
            var result = await _itemService.GetItemsByString(type, name);
            if (!ModelState.IsValid)
            {
                return BadRequest("memberName must be a string, groupType must be ShopName or ItemName. Example Query: api/memberName?memberName='MumAndSonCo'&groupType=ShopName");
            }
            if (result.Data == null)
            {
                return NotFound(result);
            }

            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest($"The following unhandled exception happened: {e.Message}");
        }
    }

   


}



//POST posts a new item to the items database. 



//receives item, adds item to database.