using Microsoft.EntityFrameworkCore;

namespace HelloWorldASPCore.Common.Models
{
    //class UserContext
    public class GroupContext : DbContext
    {
        public DbSet<GroupModel> GroupModels { get; set; }
        public GroupContext(DbContextOptions<GroupContext> options) //Через параметр options в конструктор контекста данных будут передаваться настройки контекста
            : base(options)
        {
            Database.EnsureCreated(); //В конструкторе с помощью вызова Database.EnsureCreated() по определению моделей будет создаваться база данных (если она отсутствует).
        }
    }
}
