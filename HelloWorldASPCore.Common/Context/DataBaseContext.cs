using Microsoft.EntityFrameworkCore;
using HelloWorldASPCore.Common.Models;

namespace HelloWorldASPCore.Common.Context
{
    public class DataBaseContext : DbContext
    {
            public DbSet<GroupModel> GroupModels { get; set; }
            public DbSet<UserModel> UserModels { get; set; }
            public DataBaseContext(DbContextOptions<DataBaseContext> options) //Через параметр options в конструктор контекста данных будут передаваться настройки контекста
                : base(options)
            {
                Database.EnsureCreated(); //В конструкторе с помощью вызова Database.EnsureCreated() по определению моделей будет создаваться база данных (если она отсутствует).
            }
    }
}
