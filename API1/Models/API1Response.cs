namespace API1.Models
{
    public record API1Response
    {
        public DateTime API1CreatedAt { get; init; }
        public string Description { get; init; }
        public int ComingFromAPI { get; init; }
    }
}
