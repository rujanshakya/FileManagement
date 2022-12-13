using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniProjectFile.Models
{
    [Table("ProductTable")]

    public class ProductTable
    {
        [Key]
        public int Id { get; set; }
        //[ForeignKey("ImportSource.Id")]
        public int ImportSourceId { get; set; }
        //[ForeignKey("ColumnModel.Id")]
        public int ColumnId { get; set; }
        public int StoreId { get; set; }
        public int ProductId { get; set; }
        public string? Url { get; set; }
        public string? Title { get; set; }
        public int Price { get; set; }

        public string? Color { get; set; }
        public string? Size { get; set; }
    }
}
