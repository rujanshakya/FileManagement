using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniProjectFile.Models
{
    public class ImportSource
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? FileName { get; set; }
        public string? FilePath { get; set; }
        public string? FileFormat { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }=DateTime.Now;
        [BindNever]
        public string? Column { get; set; }
        [BindNever]
        public string? TableData { get; set; }
        [BindNever]
        public List<ColumnModel>? Columns { get; set; }


    }
    public class ColumnModel
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("ImportSource.Id")]
        public int ImportSourceId { get; set; }

        public string? HeaderName { get; set; }

        
    }
}
