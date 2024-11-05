namespace CRUDapplicationUsingLayers2.Model
{
    public class AddBookDto
    {
        public required string BookName { get; set; }
        public required string Category { get; set; }
        public int? NoOfCopy { get; set; }
        public string? AuthorName { get; set; }
    }
}
