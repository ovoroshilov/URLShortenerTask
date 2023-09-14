using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using URLShortenerTask.DAL.Repositories;
using URLShortenerTask.Domain.Entities;
using URLShortenerTask.Service.Service;

namespace URLShortenerTask.Controllers
{
    public class ShortURLController : Controller
    {
        private readonly IUrlShorteningService _urlShrteningService;


        public ShortURLController(IUrlShorteningService urlShrteningService)
        {
            _urlShrteningService = urlShrteningService;

        }

        [HttpGet]

        public IActionResult CreateShortUrl()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateShortUrl(string url)
        {
            await _urlShrteningService.Create(url);
            return View();
        }

        [HttpGet("/ShortURL/RedirectUsingShortUrl/{shortUrl:required}", Name = "ShortUrls_RedirectUsingShortUrl")]
        public async Task<IActionResult> RedirectUsingShortUrl(string shortUrl)
        {
            var urlMap = await _urlShrteningService.GetByShortUrl(shortUrl);

            if (urlMap == null) return View("NotFound");


            return Redirect(urlMap.Url);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUrls()
        {
            var urls = await _urlShrteningService.GetAllUrls();
            return View(urls);
        }
    }
}
