using Microsoft.EntityFrameworkCore;
using URLShortenerTask.DAL.Repositories;
using URLShortenerTask.Domain.Entities;
using URLShortenerTask.Service.Service;

namespace URLShortenerTask.Service
{
    public class UrlShorteningService : IUrlShorteningService
    {
        public const int NumberOfCharsInShortLink = 7;
        private const string Alphabet = "23456789bcdfghjkmnpqrstvwxyzBCDFGHJKLMNPQRSTVWXYZ";

        private readonly Random _random = new();
        private readonly IBaseRepository<UrlEntity> _urlRepository;

        public UrlShorteningService(IBaseRepository<UrlEntity> urlRepository)
        {
            _urlRepository = urlRepository;
        }

        public async Task<UrlEntity> Create(string url)
        {
            var shortenedUrl =   new UrlEntity
            {
                Url = url,
                ShortUrl =  GenerateShortenUrl(),
                CreateTime = DateTime.Now
            };
            var result = await _urlRepository.Create(shortenedUrl);

            return result;
        }

        public string GenerateShortenUrl()
        {
            while (true)
            {
                var codeChars = new char[NumberOfCharsInShortLink];
                for (int i = 0; i < NumberOfCharsInShortLink; i++)
                {
                    int randomIndex = _random.Next(Alphabet.Length - 1);

                    codeChars[i] = Alphabet[randomIndex];
                }

                var shortUrl = new string(codeChars);
                if (!_urlRepository.GetAll().Any(x => x.ShortUrl == shortUrl))
                {
                    return shortUrl;
                }
            }
        }

        public async Task<IEnumerable<UrlEntity>> GetAllUrls()
        {
            var urls = await _urlRepository.GetAll().ToListAsync();
            return urls;
        }

        public async Task<UrlEntity> GetByShortUrl(string shortUrl)
        {
            var url = await _urlRepository.GetAll().FirstOrDefaultAsync(x => x.ShortUrl == shortUrl);
            if (url == null) return null;
            return url;
        }
    }
}
