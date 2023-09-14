using System.Data;

namespace URLShortenerTask.Domain.Entities
{
    public class UrlEntity
    {
        public Guid Id { get; set; }
        public string Url { get; set; } = string.Empty;
        public string ShortUrl { get; set; } = string.Empty;
        public DateTime CreateTime { get; set; }
    }
}
