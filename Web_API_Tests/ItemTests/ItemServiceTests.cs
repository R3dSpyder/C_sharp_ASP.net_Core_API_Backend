using System.Runtime.InteropServices.JavaScript;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using NET_Website.Services.ItemsService;
using Web_API.Data;
using Web_API.Dtos.Item;
using Web_API.Models;
using Web_API.Repositories;
using Range = Moq.Range;

namespace Web_API_Tests.ServiceTests;

[TestClass]
public class ItemServiceTests
{

    private DbContextOptionsBuilder<DataContext> _optionsBuilder;
    private DataContext _context;
    private ItemRepository _repository;
    private ItemModel _details1;
    private ItemModel _details2;
    private ItemModel _details3;
    private readonly IMapper _mapper;
    private Mock<IItemService> _service;
    private List<ItemDto> _items;
    private List<ItemDto> _emptyItems;

    public ItemServiceTests()
    {

        _optionsBuilder = new DbContextOptionsBuilder<DataContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
        _optionsBuilder.EnableSensitiveDataLogging();
        _context = new DataContext(_optionsBuilder.Options);
        _repository = new ItemRepository(_context);
        _service = new Mock<IItemService>();
      //  _service.Setup(x => x.GetItemsByInteger("ItemId", It.IsInRange(0, 3, Range.Inclusive))).ReturnsAsync();
       // _service.Setup(x => x.GetItemsByInteger("ShopId", It.IsInRange(0, 3, Range.Inclusive))).ReturnsAsync();
       // _service.Setup(x => x.GetItemsByInteger("ItemCategory", It.IsInRange(0, 3, Range.Inclusive))).ReturnsAsync();
       // _service.Setup(x => x.GetItemsByInteger("InvalidString", It.IsInRange(3, 30, Range.Inclusive))).ReturnsAsync();

    }

    public bool CheckNotItemTypeAndConvertedToDto(List<ItemDto> one, ItemModel two)
    {
        var model = new ItemModel
        {
            Guid = new Guid(),
            ShopId = 5,
            ItemCategory = 10,
            ShopName = "test",
            ItemName = "testItemName",
            ItemDescription = "testItemDescription",
            Image = "someImageString",
            Extras = "someExtrasString",
            DeliveryDetails = "someDeliveryString"
        };
        /*
                foreach (var oneItem in one)
                {
                    for(int i=0; i < 8; i++)
                    if (oneItem.  == two.GetHashCode())
                    {
                        return false;
                    }

                }

                return true


            }

            [TestMethod]
            public Task GetItemsByInteger_whereIntegerExists_returnResult()
            {

        */
        return true;

    }
        
    }