namespace SeedDatabaseConsoleApplication.Models
{
    public class Name
    {
        public Guid Id { get; set; }
        public string? Use { get; set; }

        public string Family { get; set; } = string.Empty;
        public List<string>? Given { get; set; }

    }
}
