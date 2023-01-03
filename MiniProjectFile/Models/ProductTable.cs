using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;

namespace MiniProjectFile.Models
{
    public class ProductTable
    {

        [Key]
        public int Id { get; set; }
        [ForeignKey("ImportSource.Id")]
        public int ImportSourceId { get; set; }

        public string? ProductId { get; set; }
        public string? Link { get; set; }
        public string? Title { get; set; }

        public string? Description { get; set; }
        [AllowNull]
        public double Price { get; set; }
        [AllowNull]
        public double SalePrice { get; set; }
        public string? ImageLink { get; set; }
        public string? Brand { get; set; }
        public string? Color { get; set; }
        public string? Size { get; set; }
    }
}
