using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Web_API.Models;

namespace Web_API.Data;

public class DataContext:DbContext
{

    public DataContext(DbContextOptions<DataContext> options):base(options)
    {
        
    }

    //add DbSets here, needs to be virtual for mocking.
    public virtual DbSet<ItemModel> ItemModels { get; set; }

}