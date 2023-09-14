
using URLShortenerTask.Domain.Entities;

namespace URLShortenerTask.Service.Service
{
    public interface IUrlShorteningService
    {
        public string GenerateShortenUrl();
        public Task<IEnumerable<UrlEntity>> GetAllUrls ();

        public Task<UrlEntity> GetByShortUrl(string shortUrl);
        public Task<UrlEntity> Create(string url);
    }
}
