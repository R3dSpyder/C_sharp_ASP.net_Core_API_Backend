using AutoMapper;
using Web_API.Models;

namespace Web_API;

public class AutoMapperProfile: Profile
{
    public AutoMapperProfile()
    {
        CreateMap<ItemModel, ItemDto>();
    }

    
}