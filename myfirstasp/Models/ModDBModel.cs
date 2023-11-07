namespace myfirstasp.Models;
using Microsoft.EntityFrameworkCore;

//combine database context class and your entity classes
public class MyModDBDbContext : DbContext
{
    public MyModDBDbContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<ModDBModel> modDBs { get; set; }
}

public class ModDBModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string TestText { get; set; }
}