
using Microsoft.EntityFrameworkCore;

using Web_API.Data;

using Web_API.Models;

using Web_API.Repositories;


namespace Web_API_Tests.ServiceTests;

[TestClass]
public class ItemRepositoryTests
{
    private DbContextOptionsBuilder<DataContext> _optionsBuilder;
    private DataContext _context;
    private ItemRepository _repository;
    private ItemModel _details1;
    private ItemModel _details2;
    private ItemModel _details3;
    

    public ItemRepositoryTests()
    {
        _optionsBuilder = new DbContextOptionsBuilder<DataContext>().UseInMemoryDatabase(Guid.NewGuid().ToString());
        _optionsBuilder.EnableSensitiveDataLogging();
         _context = new DataContext(_optionsBuilder.Options);
         _repository = new ItemRepository(_context);
         
        
    }

    public bool ShouldBeEquivalent(List<ItemModel> one, ItemModel two)
    {
        foreach (ItemModel oneItem in one)
        {
            if (oneItem != two)
            {
                return false;
            }

        }

        return true;
    }

    [TestInitialize]
    public void SetUp()
    {

        _details1 = new ItemModel
        {
            ShopId = 1,
            ItemName = "testName1",
            ItemCategory = 1,
            ShopName = "Test_store1",
            ItemDescription = "This is a test item",
            Image = "some_image",
            Extras = "some Extras",
            DeliveryDetails = "Some delivery details"

        };

        _details2 = new ItemModel
        {
            ShopId = 2,
            ItemName = "testName2",
            ItemCategory = 2,
            ShopName = "Test_store2",
            ItemDescription = "This is a test item",
            Image = "some_image",
            Extras = "some Extras",
            DeliveryDetails = "Some delivery details"

        };

        _details3 = new ItemModel
        {
            ShopId = 3,
            ItemName = "testName3",
            ItemCategory = 3,
            ShopName = "Test_store3",
            ItemDescription = "This is a test item",
            Image = "some_image",
            Extras = "some Extras",
            DeliveryDetails = "Some delivery details"

        };

        var insert1 = ItemRepository.Add.AddModel(_details1);
        var insert2 = ItemRepository.Add.AddModel(_details2);
        var inser3 = ItemRepository.Add.AddModel(_details3);
        _context.SaveChanges();
    }

    [TestMethod]
    //descriptive : scenario : expected behavior
    public async Task FindItemById_WhereIdExists_ReturnsResult()
    {

        var testOne = await ItemRepository.Find.ItemId(1);
        var testTwo = await ItemRepository.Find.ItemId(2);
        var testThree = await ItemRepository.Find.ItemId(3);

       foreach(var model in testOne)
       {
           Assert.IsTrue(model.ItemId == 1);
           Assert.IsTrue(model.ItemName == "testName1");
           Assert.IsTrue(model.ItemCategory == 1);

        }
       foreach (var model in testTwo)
       {
           Assert.IsTrue(model.ItemId == 2);
           Assert.IsTrue(model.ItemName == "testName2");
           Assert.IsTrue(model.ItemCategory == 2);

        }
       foreach (var model in testThree)
       {
           Assert.IsTrue(model.ItemId == 3);
           Assert.IsTrue(model.ItemName == "testName3");
           Assert.IsTrue(model.ItemCategory == 3);


        }

      
    }

    [TestMethod]
    public async Task FindItemById_WhereIdNotExists_ReturnsEmptyList()
    {
        var testOne = await ItemRepository.Find.ItemId(4);
        Assert.IsTrue(testOne.Count ==0);

    }

    [TestMethod]
    public async Task FindItemByShopId_WhereIdExists_ReturnsResult()
    {

        var testOne = await ItemRepository.Find.ShopId(1);
        var testTwo = await ItemRepository.Find.ShopId(2);
        var testThree = await ItemRepository.Find.ShopId(3);

       Assert.IsTrue(ShouldBeEquivalent(testOne, _details1));
       Assert.IsTrue(ShouldBeEquivalent(testTwo, _details2));
       Assert.IsTrue(ShouldBeEquivalent(testThree, _details3));


    }

    [TestMethod]
    public async Task FindItemByShopId_WhereIdNotExists_ReturnsEmptyList()
    {
        var testOne = await ItemRepository.Find.ShopId(4);
        Assert.IsTrue(testOne.Count ==0);

    }


    [TestMethod]
    public async Task FindItemByName_WhereNameExists_ReturnsResult()
    {
        var testOne = await ItemRepository.Find.ItemName("testName1");
        var testTwo = await ItemRepository.Find.ItemName("testName2");
        var testThree = await ItemRepository.Find.ItemName("testName3");

        Assert.IsTrue(ShouldBeEquivalent(testOne, _details1));
        Assert.IsTrue(ShouldBeEquivalent(testTwo, _details2));
        Assert.IsTrue(ShouldBeEquivalent(testThree, _details3));
    }

    [TestMethod]
    public async Task FindItemByName_WhereNameNotExists_ReturnsEmptyList()
    {
        var testOne = await ItemRepository.Find.ItemName("testsAreGreat");
        Assert.IsTrue(testOne.Count == 0);

    }
    [TestMethod]
    public async Task FindItemByCategory_WhereCategoryExists_ReturnsResult()
    {
        var testOne = await ItemRepository.Find.ItemCategory(1);
        var testTwo = await ItemRepository.Find.ItemCategory(2);
        var testThree = await ItemRepository.Find.ItemCategory(3);

        Assert.IsTrue(ShouldBeEquivalent(testOne, _details1));
        Assert.IsTrue(ShouldBeEquivalent(testTwo, _details2));
        Assert.IsTrue(ShouldBeEquivalent(testThree, _details3));
    }
    [TestMethod]
    public async Task FindItemByCategory_WhereCategoryNotExists_ReturnsEmptyList()
    {
        var testOne = await ItemRepository.Find.ItemName("testsAreGreat");
        Assert.IsTrue(testOne.Count == 0);

    }

    [TestMethod]
    public async Task FindItemByShopName_WhereShopNameExists_ReturnsResult()
    {
        var testOne = await ItemRepository.Find.ShopName("Test_store1");
        var testTwo = await ItemRepository.Find.ShopName("Test_store2");
        var testThree = await ItemRepository.Find.ShopName("Test_store3");

        Assert.IsTrue(ShouldBeEquivalent(testOne, _details1));
        Assert.IsTrue(ShouldBeEquivalent(testTwo, _details2));
        Assert.IsTrue(ShouldBeEquivalent(testThree, _details3));
    }

    public async Task FindItemByShopName_WhereShopNameNotExists_ReturnsEmptyList()
    {
        var testOne = await ItemRepository.Find.ShopName("testsAreGreat");
        Assert.IsTrue(testOne.Count == 0);

    }

}