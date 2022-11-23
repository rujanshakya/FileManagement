using Microsoft.EntityFrameworkCore;

namespace MiniProjectFile.Models
{
    [Keyless]
    public class CustomModel
    {
        public ImportSource ImportSource { get; set; }
        public ColumnModel ColumnModel { get; set; }
    }
}
