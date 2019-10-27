using Microsoft.EntityFrameworkCore;

namespace HelloWorldASPCore.Common.Models
{
    //class UserContext
    public class UserContext : DbContext
    {
        public DbSet<UserModel> UserModels { get; set; }
        public UserContext(DbContextOptions<UserContext> options) //Через параметр options в конструктор контекста данных будут передаваться настройки контекста
            : base(options)
        {
            Database.EnsureCreated(); //В конструкторе с помощью вызова Database.EnsureCreated() по определению моделей будет создаваться база данных (если она отсутствует).
        }
    }
}
