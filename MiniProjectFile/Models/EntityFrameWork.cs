using Microsoft.EntityFrameworkCore;
using MiniProjectFile.Models;

namespace MiniProjectFile.Models
{
    public class EntityFrameWork:DbContext
    {
        public EntityFrameWork(DbContextOptions<EntityFrameWork> options):base(options)
        {

        }

        public DbSet<MiniProjectFile.Models.ImportSource>? ImportSource { get; set; }
        public DbSet<MiniProjectFile.Models.ColumnModel>? ColumnModel { get; set; }
        public DbSet<MiniProjectFile.Models.ProductTable>? ProductTable { get; set; }

        public DbSet<MiniProjectFile.Models.ProductMapValue> ProductMapValue { get; set; }





    }
}
