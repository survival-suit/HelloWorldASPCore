using Microsoft.EntityFrameworkCore;
using HelloWorldASPCore.Common.Models;

namespace HelloWorldASPCore.Common.Context
{
    public class DataBaseContext : DbContext
    {
        public DbSet<GroupModel> GroupModels { get; set; }
        public DbSet<UserModel> UserModels { get; set; }
        public DataBaseContext() //Через параметр options в конструктор контекста данных будут передаваться настройки контекста
            : base(GetDbContextOptionsBuilder())
        {
            Database.EnsureCreated(); //В конструкторе с помощью вызова Database.EnsureCreated() по определению моделей будет создаваться база данных (если она отсутствует).
        }

        protected static DbContextOptions<DataBaseContext> GetDbContextOptionsBuilder()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataBaseContext>();
            {
                var options = optionsBuilder
                    .UseSqlite("Data Source=HelloWorldASPCoreDB.db")
                    .Options;
                return options;
            }


        }
    }
}
