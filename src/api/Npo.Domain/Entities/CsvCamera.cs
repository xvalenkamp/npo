using CsvHelper.Configuration.Attributes;

namespace Npo.Domain.Entities
{
    public class CsvCamera
    {
        [Index(0)]
        public string Camera { get; set; } = null!;
        [Index(1)]
        public string? Latitude { get; set; } = string.Empty;
        [Index(2)]
        public string Longitude { get; set; } = string.Empty;
    }
}
