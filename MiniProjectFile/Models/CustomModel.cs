using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MiniProjectFile.Models
{
    [Keyless]
    public class CustomModel 
    {
        public List<ImportSource>? ImportSource { get; set; }
        public List<ColumnModel>? ColumnModel { get; set; }
        public List<DestinationModel>? DestinationModel{ get; set; }
        public List<ProductTable>? ProductTabs{ get; set; }
        public List<ListDropDown>? ListDropDowns { get; set; }
    }
    
    
}
