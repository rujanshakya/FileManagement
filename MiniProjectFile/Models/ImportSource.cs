namespace MiniProjectFile.Models
{
    public class ImportSource
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? FileName { get; set; }
        public string? FilePath { get; set; }
        public string? FileFormat { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }=DateTime.Now;

    }
}
