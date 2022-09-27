using Microsoft.EntityFrameworkCore;

namespace MiniProjectFile.Models
{
    public class EntityFrameWork:DbContext
    {
        public EntityFrameWork(DbContextOptions<EntityFrameWork> options):base(options)
        {

        }
    }
}
