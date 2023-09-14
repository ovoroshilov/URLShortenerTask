using Microsoft.EntityFrameworkCore;
using URLShortenerTask.Domain.Entities;

namespace URLShortenerTask.DAL.Repositories
{
    public class URLRepository : IBaseRepository<UrlEntity>
    {
        private readonly URLShortenerDbContext _context;

        public URLRepository(URLShortenerDbContext context)
        {
            _context = context;
        }

        public async Task<UrlEntity> Create(UrlEntity entity)
        {
            await _context.Urls.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(UrlEntity entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public IQueryable<UrlEntity> GetAll()
        {
            return _context.Urls;
        }

        public async Task<UrlEntity> Update(UrlEntity entity)
        {
            _context.Urls.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
