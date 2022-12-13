using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MiniProjectFile.Models
{
    [Keyless]
    public class CustomModel 
    {
        public List<ImportSource> ImportSource { get; set; }
        public List<ColumnModel> ColumnModel { get; set; }
        public List<DestinationModel> DestinationModel{ get; set; }
        public List<ProductTable> ProductTable{ get; set; }
        public List<ListDropDown> ListDropDowns { get; set; }
    }
    public class ProductMapValue
    {
        public string key { get; set; }
        public string value { get; set; }
    }
}
