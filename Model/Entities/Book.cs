namespace CRUDapplicationUsingLayers2.Model.Entities
{
    public class Book
    {
        public Guid Id { get; set; }
        public required string BookName { get; set; }
        public required string Category { get; set; }
        public int? NoOfCopy { get; set; }
        public string? AuthorName { get; set; }
    }
}
