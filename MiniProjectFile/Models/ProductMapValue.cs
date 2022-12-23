using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniProjectFile.Models
{
    
        public class ProductMapValue
        {
            [Key]
            public int Id { get; set; }
            
        public int ImportSourceId { get; set; }
            public int ColumnId { get; set; }
            
            public string? ProductHeader { get; set; }
        }
    
}
